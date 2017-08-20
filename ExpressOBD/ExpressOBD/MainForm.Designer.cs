namespace ExpressOBD
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("ExpressOBD Initializing..", 2);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.gbConnection = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.descRate = new System.Windows.Forms.Label();
            this.descPort = new System.Windows.Forms.Label();
            this.cbBaud = new System.Windows.Forms.ComboBox();
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.gbOBDActions = new System.Windows.Forms.GroupBox();
            this.btnResetErrors = new System.Windows.Forms.Button();
            this.descReset = new System.Windows.Forms.Label();
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.tmrSerialEvent = new System.Windows.Forms.Timer(this.components);
            this.tmrSerialPortListUpdate = new System.Windows.Forms.Timer(this.components);
            this.tmrSerialTimeout = new System.Windows.Forms.Timer(this.components);
            this.lvLog = new System.Windows.Forms.ListView();
            this.chLog = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ilListviewImages = new System.Windows.Forms.ImageList(this.components);
            this.gbConnection.SuspendLayout();
            this.gbOBDActions.SuspendLayout();
            this.gbStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbConnection
            // 
            this.gbConnection.Controls.Add(this.label1);
            this.gbConnection.Controls.Add(this.btnConnect);
            this.gbConnection.Controls.Add(this.descRate);
            this.gbConnection.Controls.Add(this.descPort);
            this.gbConnection.Controls.Add(this.cbBaud);
            this.gbConnection.Controls.Add(this.cbPort);
            this.gbConnection.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbConnection.Location = new System.Drawing.Point(12, 12);
            this.gbConnection.Name = "gbConnection";
            this.gbConnection.Padding = new System.Windows.Forms.Padding(15);
            this.gbConnection.Size = new System.Drawing.Size(300, 241);
            this.gbConnection.TabIndex = 0;
            this.gbConnection.TabStop = false;
            this.gbConnection.Text = "Connection";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 51);
            this.label1.TabIndex = 5;
            this.label1.Text = "To identify the correct port,\r\nDisconnect device && note available ports\r\nReconne" +
    "ct device && select the new entry";
            // 
            // btnConnect
            // 
            this.btnConnect.Enabled = false;
            this.btnConnect.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(18, 186);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(264, 37);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // descRate
            // 
            this.descRate.AutoSize = true;
            this.descRate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descRate.Location = new System.Drawing.Point(18, 83);
            this.descRate.Name = "descRate";
            this.descRate.Size = new System.Drawing.Size(80, 21);
            this.descRate.TabIndex = 3;
            this.descRate.Text = "Baud Rate";
            // 
            // descPort
            // 
            this.descPort.AutoSize = true;
            this.descPort.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descPort.Location = new System.Drawing.Point(18, 48);
            this.descPort.Name = "descPort";
            this.descPort.Size = new System.Drawing.Size(85, 21);
            this.descPort.TabIndex = 2;
            this.descPort.Text = "Port Name";
            // 
            // cbBaud
            // 
            this.cbBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaud.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBaud.FormattingEnabled = true;
            this.cbBaud.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cbBaud.Location = new System.Drawing.Point(129, 80);
            this.cbBaud.Name = "cbBaud";
            this.cbBaud.Size = new System.Drawing.Size(153, 29);
            this.cbBaud.TabIndex = 1;
            // 
            // cbPort
            // 
            this.cbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPort.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Location = new System.Drawing.Point(129, 45);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(153, 29);
            this.cbPort.TabIndex = 0;
            // 
            // gbOBDActions
            // 
            this.gbOBDActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbOBDActions.Controls.Add(this.btnResetErrors);
            this.gbOBDActions.Controls.Add(this.descReset);
            this.gbOBDActions.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbOBDActions.Location = new System.Drawing.Point(12, 264);
            this.gbOBDActions.Name = "gbOBDActions";
            this.gbOBDActions.Padding = new System.Windows.Forms.Padding(15);
            this.gbOBDActions.Size = new System.Drawing.Size(300, 250);
            this.gbOBDActions.TabIndex = 5;
            this.gbOBDActions.TabStop = false;
            this.gbOBDActions.Text = "OBD Actions";
            // 
            // btnResetErrors
            // 
            this.btnResetErrors.Enabled = false;
            this.btnResetErrors.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetErrors.Location = new System.Drawing.Point(18, 195);
            this.btnResetErrors.Name = "btnResetErrors";
            this.btnResetErrors.Size = new System.Drawing.Size(264, 37);
            this.btnResetErrors.TabIndex = 4;
            this.btnResetErrors.Text = "Reset Errors";
            this.btnResetErrors.UseVisualStyleBackColor = true;
            this.btnResetErrors.Click += new System.EventHandler(this.btnResetErrors_Click);
            // 
            // descReset
            // 
            this.descReset.AutoSize = true;
            this.descReset.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.descReset.Location = new System.Drawing.Point(18, 43);
            this.descReset.Name = "descReset";
            this.descReset.Size = new System.Drawing.Size(259, 136);
            this.descReset.TabIndex = 2;
            this.descReset.Text = "Reset Errors with 04 Command\r\n\r\nAvailable after connecting\r\n\r\nClear MIL (\"Check E" +
    "ngine Light\")\r\nErase Diagnostic Trouble Codes\r\nErase Freeze Frame Data\r\nErase Ox" +
    "ygen Test Data, Mode 06, 07 Data";
            // 
            // gbStatus
            // 
            this.gbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbStatus.Controls.Add(this.lvLog);
            this.gbStatus.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbStatus.Location = new System.Drawing.Point(318, 12);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Padding = new System.Windows.Forms.Padding(15);
            this.gbStatus.Size = new System.Drawing.Size(604, 502);
            this.gbStatus.TabIndex = 6;
            this.gbStatus.TabStop = false;
            this.gbStatus.Text = "Status";
            // 
            // tmrSerialEvent
            // 
            this.tmrSerialEvent.Tick += new System.EventHandler(this.tmrSerialEvent_Tick);
            // 
            // tmrSerialPortListUpdate
            // 
            this.tmrSerialPortListUpdate.Enabled = true;
            this.tmrSerialPortListUpdate.Interval = 1000;
            this.tmrSerialPortListUpdate.Tick += new System.EventHandler(this.tmrSerialPortListUpdate_Tick);
            // 
            // tmrSerialTimeout
            // 
            this.tmrSerialTimeout.Interval = 2000;
            this.tmrSerialTimeout.Tick += new System.EventHandler(this.tmrSerialTimeout_Tick);
            // 
            // lvLog
            // 
            this.lvLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chLog});
            this.lvLog.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvLog.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.lvLog.Location = new System.Drawing.Point(18, 46);
            this.lvLog.Name = "lvLog";
            this.lvLog.Size = new System.Drawing.Size(570, 438);
            this.lvLog.SmallImageList = this.ilListviewImages;
            this.lvLog.TabIndex = 1;
            this.lvLog.UseCompatibleStateImageBehavior = false;
            this.lvLog.View = System.Windows.Forms.View.Details;
            // 
            // chLog
            // 
            this.chLog.Text = "Log Details";
            this.chLog.Width = 570;
            // 
            // ilListviewImages
            // 
            this.ilListviewImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilListviewImages.ImageStream")));
            this.ilListviewImages.TransparentColor = System.Drawing.Color.Transparent;
            this.ilListviewImages.Images.SetKeyName(0, "accept.png");
            this.ilListviewImages.Images.SetKeyName(1, "error.png");
            this.ilListviewImages.Images.SetKeyName(2, "information.png");
            this.ilListviewImages.Images.SetKeyName(3, "delete.png");
            this.ilListviewImages.Images.SetKeyName(4, "application_xp_terminal.png");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 526);
            this.Controls.Add(this.gbStatus);
            this.Controls.Add(this.gbOBDActions);
            this.Controls.Add(this.gbConnection);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExpressOBD";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbConnection.ResumeLayout(false);
            this.gbConnection.PerformLayout();
            this.gbOBDActions.ResumeLayout(false);
            this.gbOBDActions.PerformLayout();
            this.gbStatus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbConnection;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label descRate;
        private System.Windows.Forms.Label descPort;
        private System.Windows.Forms.ComboBox cbBaud;
        private System.Windows.Forms.ComboBox cbPort;
        private System.Windows.Forms.GroupBox gbOBDActions;
        private System.Windows.Forms.Button btnResetErrors;
        private System.Windows.Forms.Label descReset;
        private System.Windows.Forms.GroupBox gbStatus;
        private System.Windows.Forms.Timer tmrSerialEvent;
        private System.Windows.Forms.Timer tmrSerialPortListUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tmrSerialTimeout;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.ColumnHeader chLog;
        private System.Windows.Forms.ImageList ilListviewImages;
    }
}

