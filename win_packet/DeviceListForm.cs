using System;
using System.Windows.Forms;
using SharpPcap;
using System.Collections.Generic;

namespace WinformsExample
{
	public partial class DeviceListForm : Form
	{
		// 検出したデバイスリストの一覧を取得して保存する
		List<SharpPcap.LibPcap.PcapDevice> devices;


		public DeviceListForm(List<SharpPcap.LibPcap.PcapDevice> devices)
		{
			InitializeComponent();
			this.devices = devices;
			this.devices.Clear();
		}

		private void DeviceListForm_Load(object sender, EventArgs e)
		{
			foreach (var dev in CaptureDeviceList.Instance)
			{
				var devInterface = ((SharpPcap.LibPcap.PcapDevice)dev).Interface;

				if (devInterface.Addresses.Count > 1)
				{
					string ip = "";
					foreach (var address in devInterface.Addresses)
					{
						if (address.Addr.ipAddress != null)
						{
							if (address.Addr.ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
							{
								ip = address.Addr.ipAddress.ToString();
							}
						}
					}
					var str = String.Format("{0} {1}", devInterface.FriendlyName, ip);
					deviceList.Items.Add(str);
					this.devices.Add((SharpPcap.LibPcap.PcapDevice)dev);
				}
			}
		}

		public delegate void OnItemSelectedDelegate(int itemIndex);
		public event OnItemSelectedDelegate OnItemSelected;

		public delegate void OnCancelDelegate();
		public event OnCancelDelegate OnCancel;

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			OnCancel();
		}

		private void buttonOk_Click(object sender, EventArgs e)
		{
			if (deviceList.SelectedItem != null)
			{
				OnItemSelected(deviceList.SelectedIndex);
			}
		}

		private void deviceList_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (deviceList.SelectedItem != null)
			{
				OnItemSelected(deviceList.SelectedIndex);
			}
		}
	}
}
