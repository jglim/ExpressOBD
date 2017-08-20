using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;


namespace ExpressOBD
{
    public partial class MainForm : Form
    {
        private SerialPort sp;
        private int numberOfPromptsSinceInit = 0;
        private bool ecuIsAvailable = false;
        private bool serialPortsAreAvailable = false;
        private bool connectingInProgress = false;
        StringBuilder serialBuffer = new StringBuilder();
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lvLog.Items.Clear();
            cbBaud.SelectedIndex = 2;
            LogCustom("ExpressOBD 1.0 [github.com/jglim]. Icons: [famfamfam.com/lab/icons/silk]", 4);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            connectingInProgress = true;
            sp = new SerialPort(cbPort.Text, int.Parse(cbBaud.Text), Parity.None, 8, StopBits.One);
            sp.Open();
            numberOfPromptsSinceInit = 0;
            serialBuffer.Clear();
            tmrSerialEvent.Enabled = true;
            sp.Write("ATWS\r");
            tmrSerialTimeout.Enabled = true;
            SetupFormForPostConnect();

        }

        private void SetupFormForPreConnect()
        {

            cbBaud.Enabled = true;
            cbPort.Enabled = true;
            btnConnect.Enabled = serialPortsAreAvailable;
            btnResetErrors.Enabled = false;

        }

        private void SetupFormForPostConnect()
        {

            cbBaud.Enabled = false;
            cbPort.Enabled = false;
            btnConnect.Enabled = false;

            btnResetErrors.Enabled = ecuIsAvailable;

        }



        private void tmrSerialEvent_Tick(object sender, EventArgs e)
        {
            if (sp == null)
            {
                SetupFormForPreConnect();
                return;
            }

            if (sp.IsOpen == false)
            {
                SetupFormForPreConnect();
                return;
            }

            while (sp.IsOpen && sp.BytesToRead > 0)
            {
                SetupFormForPostConnect();
                
                string inString = Encoding.ASCII.GetChars(new byte[] { (byte) sp.ReadByte() })[0].ToString();
                if (inString == ">")
                {
                    numberOfPromptsSinceInit++;
                    Console.WriteLine("PC: {0}, Value: {1}", numberOfPromptsSinceInit, serialBuffer.ToString().Replace("\r", ""));
                    if (numberOfPromptsSinceInit == 1)
                    {
                        sp.Write("ATZ\r");
                    }
                    else if (numberOfPromptsSinceInit == 2)
                    {
                        if (serialBuffer.ToString().Contains("ELM327"))
                        {
                            tmrSerialTimeout.Enabled = false;
                            sp.Write("ATE0\r");
                        }
                        else
                        {
                            // Wait for serial timeout which should automatically abort
                        }
                    }
                    else if (numberOfPromptsSinceInit == 3)
                    {
                        sp.Write("ATL0\r");
                    }
                    else if (numberOfPromptsSinceInit == 4)
                    {
                        sp.Write("ATH1\r");
                    }
                    else if (numberOfPromptsSinceInit == 5)
                    {
                        sp.Write("ATSP0\r");
                    }
                    else if (numberOfPromptsSinceInit == 6)
                    {
                        sp.Write("ATI\r");
                    }
                    else if (numberOfPromptsSinceInit == 7)
                    {
                        // Check for "ELM327" else abort
                        if (serialBuffer.ToString().Contains("ELM327"))
                        {
                            Log("Connected to " + serialBuffer.ToString());
                            sp.Write("AT@1\r");
                        }
                        else
                        {
                            LogError("No compatible ELM327 device available on " + cbPort.Text);
                            DisconnectAndTidyUp();
                        }
                    }
                    else if (numberOfPromptsSinceInit == 8)
                    {
                        Log("Device Description: " + serialBuffer.ToString());
                        sp.Write("ATRV\r");
                    }
                    else if (numberOfPromptsSinceInit == 9)
                    {
                        Log("Vehicle Voltage: " + serialBuffer.ToString());
                        sp.Write("0100\r");
                    }
                    else if (numberOfPromptsSinceInit == 10)
                    {
                        // Check for "UNABLE TO CONNECT" else continue
                        if (serialBuffer.ToString().Contains("UNABLE TO CONNECT"))
                        {
                            LogError("ECU not detected! Check OBD2 connection, or if vehicle is switched ON");
                            DisconnectAndTidyUp();
                        }
                        else
                        {
                            Log("ECU Ready for OBD actions");
                            ecuIsAvailable = true;
                            sp.Write("ATDP\r");
                        }
                    }
                    else if (numberOfPromptsSinceInit == 11)
                    {
                        Log("Communicating with ECU via " + serialBuffer.ToString());
                        sp.Write("0101\r");
                    }
                    else if (numberOfPromptsSinceInit == 12)
                    {
                        //string milData = "7E8 06 41 01 00 FF FF FF \r\r"; // Test data: no errors
                        //string milData = "7E8 06 41 01 81 FF FF FF \r\r"; // Test data: 1 error

                        string milData = serialBuffer.ToString();
                        milData = milData.Replace("\r", " ").Trim();
                        string[] milDataSegments = milData.Split(' ');
                        if (milDataSegments.Length != 8)
                        {
                            LogWarn("MIL Data could not be parsed");
                        }
                        else
                        {
                            byte milByte = byte.Parse(milDataSegments[4], System.Globalization.NumberStyles.HexNumber);
                            bool milIsActive = ((milByte & 0x80) > 0);
                            int milCount = (milByte & 0x7F);

                            if (milIsActive)
                            {
                                LogWarn("MIL (Check Engine Light) is ON. Number of Errors: " + milCount.ToString());
                            }
                            else
                            {
                                LogSuccess("MIL (Check Engine Light) is OFF");
                            }
                        }
                        sp.Write("0101\r");
                    }
                    else if (numberOfPromptsSinceInit == 100000)
                    {
                        LogSuccess("Erase acknowledged by ECU");
                        LogWarn("Restart vehicle to reflect changes");
                        DisconnectAndTidyUp();
                    }

                    serialBuffer.Clear();
                }
                else
                {
                    serialBuffer.Append(inString);
                }
            }

        }

        private void btnResetErrors_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This action will: \r\n\r\n\r\n" +
                "Reset Trouble Code Count and MIL (Check Engine Light)\r\n\r\n" +
                "Erase Diagnostic Trouble Codes, Freeze Frame Data(and associated DTCs), Oxygen Test Data, Mode 06, 07 Data\r\n\r\n" +
                "Mode 0A(Permanent Trouble Codes) are unaffected and can only be reset by ECU\r\n\r\n\r\n" +
                "Would you like to continue?", "Confirm Reset", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                numberOfPromptsSinceInit = 99999;
                //sp.Write("0100\r"); // 01 for dry run
                sp.Write("04\r"); // 04 will actually do the reset
            }
        }

        private void Log(string Message)
        {
            lvLog.Items.Add(new ListViewItem(Message, 2));
        }

        private void LogWarn(string Message)
        {
            lvLog.Items.Add(new ListViewItem(Message, 1));
        }

        private void LogSuccess(string Message)
        {
            lvLog.Items.Add(new ListViewItem(Message, 0));
        }

        private void LogCustom(string Message, int ImageIndex)
        {
            lvLog.Items.Add(new ListViewItem(Message, ImageIndex));
        }

        private void LogError(string Message)
        {
            lvLog.Items.Add(new ListViewItem(Message, 3));
        }

        private void tmrSerialPortListUpdate_Tick(object sender, EventArgs e)
        {
            List<string> freshPorts = new List<string>(SerialPort.GetPortNames());
            freshPorts.Sort();

            if (freshPorts.Count == 0)
            {
                serialPortsAreAvailable = false;
            }
            else
            {
                serialPortsAreAvailable = true;
            }
            if (!connectingInProgress)
            {
                btnConnect.Enabled = serialPortsAreAvailable;
            }


            bool portsNeedUpdating = false;

            if (freshPorts.Count == cbPort.Items.Count)
            {
                for (int i = 0; i < freshPorts.Count; i++)
                {
                    if (freshPorts[i] != cbPort.Items[i].ToString())
                    {
                        portsNeedUpdating = true;
                    }
                }
            }
            else
            {
                portsNeedUpdating = true;
            }

            if (portsNeedUpdating)
            {
                cbPort.Items.Clear();
                cbPort.Items.AddRange(freshPorts.ToArray());
                cbPort.SelectedIndex = cbPort.Items.Count - 1;
                Log("Available Serial Ports updated");
            }
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sp != null)
            {
                if (sp.IsOpen)
                {
                    sp.Close();
                }
            }
        }

        private void tmrSerialTimeout_Tick(object sender, EventArgs e)
        {
            LogError("Serial Timeout: Port or baud rate may be incorrectly set.");
            DisconnectAndTidyUp();
        }

        private void DisconnectAndTidyUp()
        {
            tmrSerialEvent.Enabled = false;
            tmrSerialTimeout.Enabled = false;
            sp.Close();
            serialBuffer.Clear();
            connectingInProgress = false;
            ecuIsAvailable = false;
            Log("Connection closed automatically");
            SetupFormForPreConnect();
        }
    }
}
