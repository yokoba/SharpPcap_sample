using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SharpPcap;
using PacketDotNet;
using System.Drawing;
using System.Text.RegularExpressions;

namespace WinformsExample
{
    public partial class CaptureForm : Form
    {
        /// <summary>
        /// When true the background thread will terminate
        /// </summary>
        /// <param name="args">
        /// A <see cref="string"/>
        /// </param>
        private bool BackgroundThreadStop;

        /// <summary>
        /// Object that is used to prevent two threads from accessing
        /// PacketQueue at the same time
        /// </summary>
        /// <param name="args">
        /// A <see cref="string"/>
        /// </param>
        private object QueueLock = new object();

        /// <summary>
        /// The queue that the callback thread puts packets in. Accessed by
        /// the background thread when QueueLock is held
        /// </summary>
        private List<CaptureEventArgs> PacketQueue = new List<CaptureEventArgs>();

        /// <summary>
        /// The last time PcapDevice.Statistics() was called on the active device.
        /// Allow periodic display of device statistics
        /// </summary>
        /// <param name="args">
        /// A <see cref="string"/>
        /// </param>
        private DateTime LastStatisticsOutput;

        /// <summary>
        /// Interval between PcapDevice.Statistics() output
        /// </summary>
        /// <param name="args">
        /// A <see cref="string"/>
        /// </param>
        private TimeSpan LastStatisticsInterval = new TimeSpan(0, 0, 2);

        private System.Threading.Thread backgroundThread;

        private DeviceListForm deviceListForm;
        private ICaptureDevice device;
        List<SharpPcap.LibPcap.PcapDevice> devices = new List<SharpPcap.LibPcap.PcapDevice>();


        public CaptureForm()
        {
            InitializeComponent();
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
        }

        void Application_ApplicationExit(object sender, EventArgs e)
        {
        }

        private void CaptureForm_Load(object sender, EventArgs e)
        {
            deviceListForm = new DeviceListForm(devices);
            deviceListForm.OnItemSelected += new DeviceListForm.OnItemSelectedDelegate(deviceListForm_OnItemSelected);
            deviceListForm.OnCancel += new DeviceListForm.OnCancelDelegate(deviceListForm_OnCancel);
        }

        void deviceListForm_OnItemSelected(int itemIndex)
        {
            // close the device list form
            deviceListForm.Hide();

            //StartCapture(itemIndex);
            device = devices[itemIndex];

            var interfaces = ((SharpPcap.LibPcap.PcapDevice)device).Interface;

            var addresses = interfaces.Addresses;

            foreach (var address in addresses)
            {
                if (address.Addr.ipAddress != null)
                {
                    if (address.Addr.ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        textBoxTargetInterfaceIpAddress.Text = address.Addr.ipAddress.ToString();
                        textBoxTargetInterfaceName.Text = interfaces.FriendlyName;
                    }

                }

            }




        }

        void deviceListForm_OnCancel()
        {
            Application.Exit();
        }

/*        public class PacketWrapper
        {
            public RawCapture p;

            public int Count { get; private set; }
            public PosixTimeval Timeval { get { return p.Timeval; } }
            public LinkLayers LinkLayerType { get { return p.LinkLayerType; } }
            public int Length { get { return p.Data.Length; } }

            public PacketWrapper(int count, RawCapture p)
            {
                this.Count = count;
                this.p = p;
            }
        }*/


        public class PacketWrapper
		{
            public RawCapture p;
            public int Count { get; private set; }
            public string SrcIp { get; set; }
            public string DstIp { get; set; }
            public int SrcPort { get; set; }
            public int DstPort { get; set; }
            public string Payload { get; set; }
            public int PacketLength  { get; set; }
            public uint SequenceNumber { get; set; }
            public PacketWrapper(int count, RawCapture p, System.Net.IPAddress srcIp, System.Net.IPAddress dstIp, int srcPort, int dstPort , byte[] payload, int packetLength, uint sequenceNumber)
			{
                this.Count = count;
                this.p = p;

                this.SrcIp = srcIp.ToString();
                this.DstIp = dstIp.ToString();
                this.SrcPort = srcPort;
                this.DstPort = dstPort;

                string payloadHex = BitConverter.ToString(payload);
                this.Payload = payloadHex.Replace("-", "");
                this.PacketLength = packetLength;
                this.SequenceNumber = sequenceNumber;
			}
		}



        private PacketArrivalEventHandler arrivalEventHandler;
        private CaptureStoppedEventHandler captureStoppedEventHandler;

        private void Shutdown()
        {
            if (device != null)
            {
                device.StopCapture();
                device.Close();
                device.OnPacketArrival -= arrivalEventHandler;
                device.OnCaptureStopped -= captureStoppedEventHandler;
                device = null;

                // ask the background thread to shut down
                BackgroundThreadStop = true;

                // wait for the background thread to terminate
                backgroundThread.Join();

                buttonCaptureStart.Enabled = true;
                buttonCaptureStop.Enabled = false;

            }
        }

        private void StartCapture()
        {
            packetCount = 0;
            //device = devices[itemIndex];
            packetStrings = new Queue<PacketWrapper>();
            bs = new BindingSource();
            dataGridView.DataSource = bs;
            LastStatisticsOutput = DateTime.Now;

            // start the background thread
            BackgroundThreadStop = false;
            backgroundThread = new System.Threading.Thread(BackgroundThread);
            backgroundThread.Start();

            // setup background capture
            arrivalEventHandler = new PacketArrivalEventHandler(device_OnPacketArrival);
            device.OnPacketArrival += arrivalEventHandler;
            captureStoppedEventHandler = new CaptureStoppedEventHandler(device_OnCaptureStopped);
            device.OnCaptureStopped += captureStoppedEventHandler;


            var interval = 0;
            int.TryParse(textBoxInterfaceMonitorInterval.Text, out interval);
            device.Open(DeviceMode.Normal, interval);

            // device filter add
            if(textBoxCaptureFilter.Text != "")
			{
                device.Filter = textBoxCaptureFilter.Text;
			}

            // force an initial statistics update
            captureStatistics = device.Statistics;
            UpdateCaptureStatistics();

            // start the background capture
            device.StartCapture();
        }

        void device_OnCaptureStopped(object sender, CaptureStoppedEventStatus status)
        {
            if (status != CaptureStoppedEventStatus.CompletedWithoutError)
            {
                MessageBox.Show("Error stopping capture", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Queue<PacketWrapper> packetStrings;

        private int packetCount;
        private BindingSource bs;
        private ICaptureStatistics captureStatistics;
        private bool statisticsUiNeedsUpdate = false;

        void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            // print out periodic statistics about this device
            var Now = DateTime.Now; // cache 'DateTime.Now' for minor reduction in cpu overhead
            var interval = Now - LastStatisticsOutput;
            if (interval > LastStatisticsInterval)
            {
                Console.WriteLine("device_OnPacketArrival: " + e.Device.Statistics);
                captureStatistics = e.Device.Statistics;
                statisticsUiNeedsUpdate = true;
                LastStatisticsOutput = Now;
            }

            // lock QueueLock to prevent multiple threads accessing PacketQueue at
            // the same time
            lock (QueueLock)
            {
                PacketQueue.Add(e);
            }
        }

        private void CaptureForm_Shown(object sender, EventArgs e)
        {
            deviceListForm.Show();
        }



        /// <summary>
        /// Checks for queued packets. If any exist it locks the QueueLock, saves a
        /// reference of the current queue for itself, puts a new queue back into
        /// place into PacketQueue and unlocks QueueLock. This is a minimal amount of
        /// work done while the queue is locked.
        ///
        /// The background thread can then process queue that it saved without holding
        /// the queue lock.
        /// </summary>
        private void BackgroundThread()
        {
            while (!BackgroundThreadStop)
            {
                bool shouldSleep = true;

                lock (QueueLock)
                {
                    if (PacketQueue.Count != 0)
                    {
                        shouldSleep = false;
                    }
                }

                if (shouldSleep)
                {
                    System.Threading.Thread.Sleep(250);
                }
                else // should process the queue
                {
                    List<CaptureEventArgs> ourQueue;
                    lock (QueueLock)
                    {
                        // swap queues, giving the capture callback a new one
                        ourQueue = PacketQueue;
                        PacketQueue = new List<CaptureEventArgs>();
                    }

                    Console.WriteLine("BackgroundThread: ourQueue.Count is {0}", ourQueue.Count);

                    foreach (var packetQueue in ourQueue)
                    {
                        // Here is where we can process our packets freely without
                        // holding off packet capture.
                        //
                        // NOTE: If the incoming packet rate is greater than
                        //       the packet processing rate these queues will grow
                        //       to enormous sizes. Packets should be dropped in these
                        //       cases

                        var packet = PacketDotNet.Packet.ParsePacket(packetQueue.Packet.LinkLayerType, packetQueue.Packet.Data);
                        var tcpPacket = packet.Extract<PacketDotNet.TcpPacket>();

                        if (tcpPacket != null)
                        {
                            var ipPacket = (PacketDotNet.IPPacket)tcpPacket.ParentPacket;
                            System.Net.IPAddress srcIp = ipPacket.SourceAddress;
                            System.Net.IPAddress dstIp = ipPacket.DestinationAddress;
                            int srcPort = tcpPacket.SourcePort;
                            int dstPort = tcpPacket.DestinationPort;
                            byte[] payload = tcpPacket.PayloadData;
                            int packetLength = tcpPacket.PayloadData.Length;
                            uint sequenceNumber = tcpPacket.SequenceNumber;


                            if(textBoxCaptureServerIpAddress.Text == srcIp.ToString() && textBoxCaptureServerPortNumber.Text.ToString() == srcPort.ToString())
							{
                                var packetWrapper = new PacketWrapper(packetCount, packetQueue.Packet, srcIp, dstIp, srcPort, dstPort, payload, packetLength, sequenceNumber);
                                this.BeginInvoke(new MethodInvoker(delegate
                                {
                                    packetStrings.Enqueue(packetWrapper);
                                }
                                ));

                                packetCount++;

                                var time = packetQueue.Packet.Timeval.Date;
                                var len = packetQueue.Packet.Data.Length;
                                Console.WriteLine("BackgroundThread: {0}:{1}:{2},{3} Len={4}",
                                    time.Hour, time.Minute, time.Second, time.Millisecond, len);
                            }


                        }
                    }

                    this.BeginInvoke(new MethodInvoker(delegate
                    {
                        bs.DataSource = packetStrings.Reverse();
                    }
                    ));

                    if (statisticsUiNeedsUpdate)
                    {
                        UpdateCaptureStatistics();
                        statisticsUiNeedsUpdate = false;
                    }
                }
            }
        }

        private void UpdateCaptureStatistics()
        {
            captureStatisticsToolStripStatusLabel.Text = string.Format("Received packets: {0}, Dropped packets: {1}, Interface dropped packets: {2}",
                                                       captureStatistics.ReceivedPackets,
                                                       captureStatistics.DroppedPackets,
                                                       captureStatistics.InterfaceDroppedPackets);
        }

        private void CaptureForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Shutdown();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count == 0)
                return;

            var packetWrapper = (PacketWrapper)dataGridView.Rows[dataGridView.SelectedCells[0].RowIndex].DataBoundItem;
            var packet = Packet.ParsePacket(packetWrapper.p.LinkLayerType, packetWrapper.p.Data);
            packetInfoTextbox.Text = packet.ToString(StringOutputType.VerboseColored);
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonCaptureStop_Click(object sender, EventArgs e)
        {
            if (device == null)
            {
                deviceListForm.Show();
            }
            else
            {
                Shutdown();
                deviceListForm.Show();
            }
        }

        private void buttonCaptureStart_Click(object sender, EventArgs e)
        {
            buttonCaptureStart.Enabled = false;
            buttonCaptureStop.Enabled = true;
            StartCapture();

        }

        private void textBoxInterfaceMonitorInterval_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool result = int.TryParse(textBoxInterfaceMonitorInterval.Text, out _);

            if (!result)
            {
                textBoxInterfaceMonitorInterval.BackColor = Color.Red;
                e.Cancel = true;
            }
        }

        private void textBoxInterfaceMonitorInterval_Validated(object sender, EventArgs e)
        {
            textBoxInterfaceMonitorInterval.BackColor = Color.FromKnownColor(KnownColor.Window);
        }

        private void textBoxCaptureServerPortNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = int.TryParse(textBoxCaptureServerPortNumber.Text, out _);

            if (!result)
            {
                textBoxInterfaceMonitorInterval.BackColor = Color.Red;
                e.Cancel = true;
            }
        }

        private void textBoxCaptureServerPortNumber_Validated(object sender, EventArgs e)
        {
            textBoxInterfaceMonitorInterval.BackColor = Color.FromKnownColor(KnownColor.Window);
        }



        private void textBoxCaptureServerIpAddress_Validating(object sender, System.ComponentModel.CancelEventArgs e)

        {
            if (CheckIpString(textBoxCaptureServerIpAddress.Text))
            {
                textBoxCaptureServerIpAddress.BackColor = Color.Red;
                e.Cancel = true;
            }
        }
        private bool CheckIpString(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("str is null or empty.");
            }

            if (str.Length < 7 || str.Length > 15)
            {
                throw new FormatException("str is illegal fortmat (" + str + ")");
            }

            Match m = Regex.Match(str, @"^(\d+)\.(\d+)\.(\d+)\.(\d+)$");
            if (m.Success)
            {
                for (int i = 1; i < 5; i++)
                {
                    if (!isInByteRange(m.Groups[i].Value))
                    {
                        throw new FormatException("str is illegal fortmat (" + str + ")");
                    }
                }
            }
            return true;
        }

        // 0 ～ 255 の範囲内かどうかチェックする
        private static bool isInByteRange(string block)
        {
           
            return byte.TryParse(block, out _);
        }

    }
}
