namespace WinformsExample
{
	partial class CaptureForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.captureStatisticsToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.packetInfoTextbox = new System.Windows.Forms.RichTextBox();
			this.textBoxTargetInterfaceIpAddress = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBoxTargetInterfaceName = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textBoxCaptureServerPortNumber = new System.Windows.Forms.TextBox();
			this.textBoxCaptureServerIpAddress = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxCaptureFilter = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxInterfaceMonitorInterval = new System.Windows.Forms.TextBox();
			this.buttonCaptureStart = new System.Windows.Forms.Button();
			this.buttonCaptureStop = new System.Windows.Forms.Button();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.captureStatisticsToolStripStatusLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 834);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1180, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// captureStatisticsToolStripStatusLabel
			// 
			this.captureStatisticsToolStripStatusLabel.Name = "captureStatisticsToolStripStatusLabel";
			this.captureStatisticsToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(0, 136);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.dataGridView);
			this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.packetInfoTextbox);
			this.splitContainer1.Size = new System.Drawing.Size(1180, 695);
			this.splitContainer1.SplitterDistance = 387;
			this.splitContainer1.TabIndex = 3;
			// 
			// dataGridView
			// 
			this.dataGridView.AllowUserToAddRows = false;
			this.dataGridView.AllowUserToDeleteRows = false;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView.Location = new System.Drawing.Point(0, 0);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.ReadOnly = true;
			this.dataGridView.Size = new System.Drawing.Size(1180, 387);
			this.dataGridView.TabIndex = 0;
			this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
			this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
			// 
			// packetInfoTextbox
			// 
			this.packetInfoTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.packetInfoTextbox.Location = new System.Drawing.Point(0, 0);
			this.packetInfoTextbox.Name = "packetInfoTextbox";
			this.packetInfoTextbox.Size = new System.Drawing.Size(1180, 304);
			this.packetInfoTextbox.TabIndex = 1;
			this.packetInfoTextbox.Text = "";
			// 
			// textBoxTargetInterfaceIpAddress
			// 
			this.textBoxTargetInterfaceIpAddress.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.textBoxTargetInterfaceIpAddress.Location = new System.Drawing.Point(362, 21);
			this.textBoxTargetInterfaceIpAddress.Name = "textBoxTargetInterfaceIpAddress";
			this.textBoxTargetInterfaceIpAddress.Size = new System.Drawing.Size(140, 22);
			this.textBoxTargetInterfaceIpAddress.TabIndex = 2;
			this.textBoxTargetInterfaceIpAddress.Text = "255.255.255.255";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBoxTargetInterfaceIpAddress);
			this.groupBox1.Controls.Add(this.textBoxTargetInterfaceName);
			this.groupBox1.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(515, 56);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Interface";
			// 
			// textBoxTargetInterfaceName
			// 
			this.textBoxTargetInterfaceName.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.textBoxTargetInterfaceName.Location = new System.Drawing.Point(6, 21);
			this.textBoxTargetInterfaceName.Name = "textBoxTargetInterfaceName";
			this.textBoxTargetInterfaceName.Size = new System.Drawing.Size(350, 22);
			this.textBoxTargetInterfaceName.TabIndex = 1;
			this.textBoxTargetInterfaceName.Text = " VirtualBox Host-Only Ethernet Adapter #2";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.textBoxCaptureServerPortNumber);
			this.groupBox2.Controls.Add(this.textBoxCaptureServerIpAddress);
			this.groupBox2.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.groupBox2.Location = new System.Drawing.Point(533, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(515, 56);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Source IP Adress  And Port";
			// 
			// textBoxCaptureServerPortNumber
			// 
			this.textBoxCaptureServerPortNumber.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.textBoxCaptureServerPortNumber.Location = new System.Drawing.Point(362, 21);
			this.textBoxCaptureServerPortNumber.Name = "textBoxCaptureServerPortNumber";
			this.textBoxCaptureServerPortNumber.Size = new System.Drawing.Size(140, 22);
			this.textBoxCaptureServerPortNumber.TabIndex = 4;
			this.textBoxCaptureServerPortNumber.Text = "8080";
			this.textBoxCaptureServerPortNumber.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxCaptureServerPortNumber_Validating);
			this.textBoxCaptureServerPortNumber.Validated += new System.EventHandler(this.textBoxCaptureServerPortNumber_Validated);
			// 
			// textBoxCaptureServerIpAddress
			// 
			this.textBoxCaptureServerIpAddress.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.textBoxCaptureServerIpAddress.Location = new System.Drawing.Point(6, 21);
			this.textBoxCaptureServerIpAddress.Name = "textBoxCaptureServerIpAddress";
			this.textBoxCaptureServerIpAddress.Size = new System.Drawing.Size(350, 22);
			this.textBoxCaptureServerIpAddress.TabIndex = 3;
			this.textBoxCaptureServerIpAddress.Text = "192.168.0.254";
			this.textBoxCaptureServerIpAddress.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxCaptureServerIpAddress_Validating);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.textBoxCaptureFilter);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.textBoxInterfaceMonitorInterval);
			this.groupBox3.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.groupBox3.Location = new System.Drawing.Point(12, 74);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(1036, 56);
			this.groupBox3.TabIndex = 7;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Capture Setting";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(524, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(39, 15);
			this.label2.TabIndex = 7;
			this.label2.Text = "Filter";
			// 
			// textBoxCaptureFilter
			// 
			this.textBoxCaptureFilter.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.textBoxCaptureFilter.Location = new System.Drawing.Point(569, 18);
			this.textBoxCaptureFilter.Name = "textBoxCaptureFilter";
			this.textBoxCaptureFilter.Size = new System.Drawing.Size(454, 22);
			this.textBoxCaptureFilter.TabIndex = 6;
			this.textBoxCaptureFilter.Text = "ip and tcp";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 15);
			this.label1.TabIndex = 5;
			this.label1.Text = "Interval(ms)";
			// 
			// textBoxInterfaceMonitorInterval
			// 
			this.textBoxInterfaceMonitorInterval.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.textBoxInterfaceMonitorInterval.Location = new System.Drawing.Point(94, 18);
			this.textBoxInterfaceMonitorInterval.Name = "textBoxInterfaceMonitorInterval";
			this.textBoxInterfaceMonitorInterval.Size = new System.Drawing.Size(408, 22);
			this.textBoxInterfaceMonitorInterval.TabIndex = 5;
			this.textBoxInterfaceMonitorInterval.Text = "1000";
			this.textBoxInterfaceMonitorInterval.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxInterfaceMonitorInterval_Validating);
			this.textBoxInterfaceMonitorInterval.Validated += new System.EventHandler(this.textBoxInterfaceMonitorInterval_Validated);
			// 
			// buttonCaptureStart
			// 
			this.buttonCaptureStart.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.buttonCaptureStart.Location = new System.Drawing.Point(1054, 24);
			this.buttonCaptureStart.Name = "buttonCaptureStart";
			this.buttonCaptureStart.Size = new System.Drawing.Size(120, 34);
			this.buttonCaptureStart.TabIndex = 8;
			this.buttonCaptureStart.Text = "START";
			this.buttonCaptureStart.UseVisualStyleBackColor = true;
			this.buttonCaptureStart.Click += new System.EventHandler(this.buttonCaptureStart_Click);
			// 
			// buttonCaptureStop
			// 
			this.buttonCaptureStop.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.buttonCaptureStop.Location = new System.Drawing.Point(1054, 84);
			this.buttonCaptureStop.Name = "buttonCaptureStop";
			this.buttonCaptureStop.Size = new System.Drawing.Size(120, 34);
			this.buttonCaptureStop.TabIndex = 9;
			this.buttonCaptureStop.Text = "STOP";
			this.buttonCaptureStop.UseVisualStyleBackColor = true;
			this.buttonCaptureStop.Click += new System.EventHandler(this.buttonCaptureStop_Click);
			// 
			// CaptureForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1180, 856);
			this.Controls.Add(this.buttonCaptureStop);
			this.Controls.Add(this.buttonCaptureStart);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.statusStrip1);
			this.Name = "CaptureForm";
			this.Text = "CaptureForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CaptureForm_FormClosing);
			this.Load += new System.EventHandler(this.CaptureForm_Load);
			this.Shown += new System.EventHandler(this.CaptureForm_Shown);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel captureStatisticsToolStripStatusLabel;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.RichTextBox packetInfoTextbox;
		private System.Windows.Forms.TextBox textBoxTargetInterfaceIpAddress;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBoxTargetInterfaceName;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textBoxCaptureServerPortNumber;
		private System.Windows.Forms.TextBox textBoxCaptureServerIpAddress;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textBoxInterfaceMonitorInterval;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxCaptureFilter;
		private System.Windows.Forms.Button buttonCaptureStart;
		private System.Windows.Forms.Button buttonCaptureStop;
	}
}