using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Management;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Forms.VisualStyles;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Linq.Expressions;
using System.Threading;
using Microsoft.Win32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Reflection.Emit;
using Microsoft.VisualBasic.Devices;
using static System.Net.WebRequestMethods;
using System.Drawing.Design;
using System.Collections;
using System.Data.Common;
using System.Xml;
using System.Diagnostics.Eventing.Reader;
using Renci.SshNet;
using Microsoft.HyperV.PowerShell;
using Renci.SshNet.Sftp;
using Microsoft.Web.Administration;
using System.Xml.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using File = System.IO.File;


namespace TSWindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string finalMsgBox = "";
        private readonly Font originalFont;
        string[] deviceTypeArr;
        string[] typeArr;
        int printerIndex = -1;
        int printer2Index = -1;
        int billIndex = -1;

        public Form1()
        {
            InitializeComponent();
            originalFont = enableHyperVbtn.Font;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            infoLbl.Text = "";
            infoLbl.Select();
            changeProgressLblVal("");
            progressBar.Visible = false;
            downldBtn.Visible = false;
            //pictureBox2.Visible = false;

            //Checking Hyper-V State
            updateHypervLbl();

            //Checking assigned Server IP
            updateServeripLbl();

            //Check VPN IP
            updateVpnipLbl();

            //Check Computer name
            updateComputernameLbl();

            //Check IP address
            updateIpaddrLbl();

            //Check Make/model
            updateDxdiagLbl();

            //Check and Update VPN IP every 5 sec
            checkVpnIp();

            //Check and Update HW details every 5 sec
            checkHwType();

            logoffButton.MouseEnter += logoffBtn_MouseEnter;
            //logoffButton.MouseLeave += logoffBtn_MouseLeave;
        }

        private async void checkVpnIp()
        {
            do
            {
                updateVpnipLbl();
                await Task.Delay(5000);
            }
            while (true);
        }
        private async void checkHwType()
        {
            do
            {
                fetchHwType();
                await Task.Delay(5000);
            }
            while (true);
        }


        /****************************UPDATE LABELS***********************/


        private void updateHypervLbl()
        {
            try
            {
                string hyperVstate = checkHyperVState();
                if (!string.IsNullOrEmpty(hyperVstate))
                {
                    if (hyperVstate != "2")
                    {
                        if (Equals(hyperVstate, "1"))
                        {
                            hypervLbl.Text = "Hyper-V : Enabled";
                        }
                        else if (Equals(hyperVstate, "0"))
                        {
                            hypervLbl.Text = "Hyper-V : Disabled";
                        }
                    }
                }
                else
                {
                    hypervLbl.Text = "Hyper-V : Error";
                }
            }
            catch 
            {
                hypervLbl.Text = "Hyper-V : Error";
            }
        }

        private void updateServeripLbl()
        {
            string regPath = @"Software\Pong Studios\CommonSettings";
            string subkey = @"HKEY_CURRENT_USER\" + regPath;

            try
            {
                object serverIp = Registry.GetValue(subkey, "ServerAddress", null);

                if (serverIp != null)
                {
                    serveripLbl.Text = "Server IP : "+serverIp.ToString();
                }
                else
                {
                    serveripLbl.Text = "Server IP : None";
                }
            }
            catch
            {
                serveripLbl.Text = "Server IP : Error";
            }
        }

        private void updateVpnipLbl()
        {
            string vpnAdapterName = "VPN Connection";

            try
            {
                NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

                NetworkInterface vpnAdapter = Array.Find(networkInterfaces,
                    ni => ni.Name.Equals(vpnAdapterName, StringComparison.OrdinalIgnoreCase));

                if (vpnAdapter != null)    
                {
                    IPInterfaceProperties ipProperties = vpnAdapter.GetIPProperties();
                    UnicastIPAddressInformation ipAddress = ipProperties.UnicastAddresses[0];
                    vpnLbl.Text = "VPN : "+ipAddress.Address.ToString();
                }

                else
                {
                    vpnLbl.Text = "VPN : Disconnected/Not Found";
                }
            }
            catch 
            {
                vpnLbl.Text = "VPN : Error";
            }
        }

        private void updateComputernameLbl()
        {
            try
            {
                ManagementScope scope = new ManagementScope("\\\\.\\root\\cimv2");
                scope.Connect();
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_ComputerSystem");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                foreach (ManagementObject obj in searcher.Get())
                {
                    string currentName = obj["Name"].ToString();
                    compnameLbl.Text += currentName;
                    break;
                }
            }
            catch 
            {
                compnameLbl.Text = "Computer Name : Error";
            }
        }

        private void updateIpaddrLbl()
        {
            string defaultSwitch = "Default Switch";
            string virtualSwitch = "V2-VM-NAT";
            try
            {
                NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

                var nis = networkInterfaces.Where(ni =>
                                                  ni.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                                                  ni.OperationalStatus == OperationalStatus.Up &&
                                                  (ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet ||
                                                  ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) &&
                                                  !(ni.Name.Contains(defaultSwitch)) &&
                                                  !(ni.Name.Contains(virtualSwitch)));
                                                 

                foreach(NetworkInterface eachni in nis)
                {
                    IPInterfaceProperties ipProperties = eachni.GetIPProperties();
                    IPAddress [] ipAddreses = ipProperties.UnicastAddresses.Where(addr =>
                                                                                  addr.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                                                                                  .Select(addr => addr.Address).ToArray();

                    foreach(IPAddress ip in ipAddreses)
                    {
                        ipaddrLbl.Text +=  ip.ToString() + "  ";
                    }
                }
            }
            catch 
            {
                ipaddrLbl.Text = "IP Address : Error";
            }
        }

        private void updateDxdiagLbl()
        {
            string manufacturer="";
            string model="";
            string chipType="";
            //string processor = "";

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
                ManagementObjectCollection collection = searcher.Get();

                foreach (ManagementObject item in collection)
                {
                     manufacturer = item["Manufacturer"].ToString();
                     model = item["Model"].ToString();
                }

                dxdiagLbl.Text += manufacturer + " " + model;

                searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DisplayConfiguration");
                collection=searcher.Get();

                foreach (ManagementObject item in collection)
                {
                    chipType = item["DeviceName"].ToString();
                }

                graphicsLbl.Text += chipType;


               /* searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                collection = searcher.Get();

                foreach (ManagementObject item in collection)
                {
                    processor = item["Name"].ToString();
                }

                label1.Text += processor;*/
            }
            catch(Exception ex) 
            {
                dxdiagLbl.Text += "Error";
                MessageBox.Show(ex.Message);
            }
        }

        //fetches HW from hardware.xml file and updates the labels

        // HKEY_CURRENT_USER\Software\Microsoft\Windows NT\CurrentVersion\Winlogon\
        // System.IO.File.Exists(@"C:\\Game\\config\\hardware.xml")

        private void fetchHwType() 
        {
            deviceTypeArr = new string[10];
            typeArr = new string[10];

            XmlDocument xmlDoc = new XmlDocument();
            string Market = System.IO.File.Exists(@"C:\\Game\\config\\hardware.xml") ? "V2" : "V1";

            string gameFolder = (Market == "V2") ? "Game" : "Sweeps";
            string pathToHardwareXml = "C://" + gameFolder + "//config//hardware.xml";

            if(System.IO.File.Exists(pathToHardwareXml))
            {
                xmlDoc.Load(pathToHardwareXml);
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList portNodes = root.SelectNodes("//PORT");

                int i = 0;

                foreach (XmlNode portNode in portNodes)
                {
                    XmlAttribute deviceTypeAttr = portNode.Attributes["device_type"];
                    XmlAttribute typeAttr = portNode.Attributes["type"];

                    if (deviceTypeAttr != null && typeAttr != null)
                    {
                        string deviceType = deviceTypeAttr.Value;
                        string type = typeAttr.Value;

                        deviceTypeArr[i] = deviceType;
                        typeArr[i] = type;

                        i++;
                    }
                }

                for (int k = 0; k < typeArr.Length; k++)
                {
                    int index = k;

                    switch (typeArr[k])
                    {
                        case "PRINTER":
                            {
                                printerIndex = index;
                                break;
                            }
                        case "PRINTER_2":
                            {
                                printer2Index = index;
                                break;
                            }
                        case "BILL":
                            {
                                billIndex = index;
                                break;
                            }
                    }
                }

                //Updating Bill Acceptor Label
                if (billIndex != -1)
                {
                    switch (deviceTypeArr[billIndex])
                    {
                        case "CashCode":
                            {
                                billAcptrLbl.Text = "Bill Acceptor : CashCode";
                                break;
                            }
                        case "PTI":
                            {
                                billAcptrLbl.Text = "Bill Acceptor : PTI";
                                break;
                            }
                        case "ID003":
                            {
                                billAcptrLbl.Text = "Bill Acceptor : ID003";
                                break;
                            }
                        default:
                            {
                                billAcptrLbl.Text = "Bill Acceptor : Error";
                                break;
                            }
                    }
                }
                else
                {
                    billAcptrLbl.Text = "Bill Acceptor : Error";
                }

                //Updating Printer Label

                if (printerIndex != -1)
                {
                    switch (deviceTypeArr[printerIndex])
                    {
                        case "PayCheck":
                            {
                                prntLbl.Text = "Printer : PayCheck";
                                break;
                            }
                        case "Epson":
                            {
                                prntLbl.Text = "Printer : Epson";
                                break;
                            }
                        case "PHX":
                            {
                                prntLbl.Text = "Printer : Phoenix";
                                break;
                            }
                        case "REL":
                            {
                                prntLbl.Text = "Printer : Reliance";
                                break;
                            }
                        case "CustomSPA":
                            {
                                prntLbl.Text = "Printer : CustomSPA";
                                break;
                            }
                        default:
                            {
                                prntLbl.Text = "Printer : Error";
                                break;
                            }
                    }
                }
                else
                {
                    prntLbl.Text = "Printer : Error";
                }
            }

            else
            {
                billAcptrLbl.Text = "Bill Acceptor : File not found";
                prntLbl.Text = "Printer : File not found";
            }
        }

        /****************************CHANGE FONT AND STYLE FUNCTIONS**************************/

        private void changeToOriginalFont(System.Windows.Forms.Button button)
        {
            button.Font = originalFont;
        }

        private void changeToEnlargedFont(System.Windows.Forms.Button button)
        {
            button.Font = new Font(originalFont.FontFamily, originalFont.Size + 1, originalFont.Style);
        }





        public static void ApplyCustomStyle(System.Windows.Forms.Button button)
        {
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = SystemColors.ControlDark;
            button.FlatAppearance.BorderColor = Color.LightBlue;
        }

        public static void ApplyOriginalStyle(System.Windows.Forms.Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = SystemColors.Control;
            button.FlatAppearance.BorderColor = Color.AliceBlue;
            button.FlatAppearance.BorderSize = 0;
        }


        /****************************MOUSE ENTER AND LEAVE EVENT HANDLERS**************************/

        private void enableHyperVbtn_Enter(object sender, EventArgs e)
        {
            //enableHyperVbtn.Font = new Font(originalFont.FontFamily, originalFont.Size + 1, originalFont.Style);
            changeToEnlargedFont(enableHyperVbtn);
        }
        
        private void enableHyperVbtn_MouseLeave(object sender, EventArgs e)
        {
            //enableHyperVbtn.Font = originalFont;
            changeToOriginalFont(enableHyperVbtn);
        }
       
       /* private void vpnAdptrBtn1_MouseEnter(object sender, EventArgs e)
        {
            changeToEnlargedFont(vpnAdptrBtn1);
        }*/
        
       /* private void vpnAdptrBtn1_MouseLeave(object sender, EventArgs e)
        {
            changeToOriginalFont(vpnAdptrBtn1);
        }*/
        
        private void vpnAdptrBtn2_MouseEnter(object sender, EventArgs e)
        {
            changeToEnlargedFont(vpnAdptrBtn2);
        }
        
        private void vpnAdptrBtn2_MouseLeave(object sender, EventArgs e)
        {
            changeToOriginalFont(vpnAdptrBtn2);
        }
        
        private void createswButton_MouseEnter(object sender, EventArgs e)
        {
           changeToEnlargedFont(createswButton);
        }
       
        private void createswButton_MouseLeave(object sender, EventArgs e)
        {
           changeToOriginalFont(createswButton);
        }
       
        private void createvmButton_MouseEnter(object sender, EventArgs e)
        {
            changeToEnlargedFont(createvmButton);
        }

        private void createvmButton_MouseLeave(object sender, EventArgs e)
        {
            changeToOriginalFont(createvmButton);
        }

        private void updateServerIpButton_MouseEnter(object sender, EventArgs e)
        {
            changeToEnlargedFont(updateServerIpButton);
        }

        private void updateServerIpButton_MouseLeave(object sender, EventArgs e)
        {

        }

        private void renameBtn_MouseEnter(object sender, EventArgs e)
        {
            changeToEnlargedFont(renameBtn);
        }
       
        private void renameBtn_MouseLeave(object sender, EventArgs e)
        {
            changeToOriginalFont(renameBtn);
        }

        private void updatePgsLoaderBtn_MouseLeave(object sender, EventArgs e)
        {
            changeToOriginalFont(updatePgsLoaderBtn);
        }

        private void updatePgsLoaderBtn_MouseEnter(object sender, EventArgs e)
        {
            changeToEnlargedFont(updatePgsLoaderBtn);
        }

        private void openhwFileBtn_MouseLeave(object sender, EventArgs e)
        {
            changeToOriginalFont(openhwFileBtn);
        }

        private void openhwFileBtn_MouseEnter(object sender, EventArgs e)
        {
            changeToEnlargedFont(openhwFileBtn);
        }

        private void copyLogsBtn_MouseLeave(object sender, EventArgs e)
        {
            changeToOriginalFont(copyLogsBtn);
        }

        private void copyLogsBtn_MouseEnter(object sender, EventArgs e)
        {
            changeToEnlargedFont(copyLogsBtn);
        }

        private void testBvBtn_MouseLeave(object sender, EventArgs e)
        {
            changeToOriginalFont(testBvBtn);
        }

        private void testBvBtn_MouseEnter(object sender, EventArgs e)
        {
            changeToEnlargedFont(testBvBtn);
        }

        private void testPrinterBtn_MouseLeave(object sender, EventArgs e)
        {
            changeToOriginalFont(testPrinterBtn);
        }

        private void testPrinterBtn_MouseEnter(object sender, EventArgs e)
        {
            changeToEnlargedFont(testPrinterBtn);
        }
        private void serverLogsBtn_MouseLeave(object sender, EventArgs e)
        {
            changeToOriginalFont(serverLogsBtn);
        }

        private void serverLogsBtn_MouseEnter(object sender, EventArgs e)
        {
            changeToEnlargedFont(serverLogsBtn);
        }


        /************************CLICK BUTTON EVENT HANDLERS***********************/

        private void restartButton_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            ApplyCustomStyle(restartButton);
            infoLbl.Text = "Restarting Computer...";
            DialogResult result = MessageBox.Show("Are you sure you want to restart the computer?", "Restart Computer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Execute the shutdown command to restart the computer
                Process.Start("shutdown", "/r /f /t 2");
            }
            this.ActiveControl = null;
            ApplyOriginalStyle(restartButton);
            infoLbl.Text = "The computer will restart in 2 seconds...";
        }

        private void logoffButton_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            //ApplyCustomStyle(logoffButton);
            infoLbl.Text = "Logging Off...";
            Process.Start("shutdown", "/l /f");
            this.ActiveControl = null;
            //ApplyOriginalStyle(logoffButton);
            infoLbl.Text = "";
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            quitBtn.BackColor = Color.WhiteSmoke;
            Environment.Exit(0);
        }

        private void createvmButton_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            ApplyCustomStyle(createvmButton);

            try
            {
                using (PowerShell ps = PowerShell.Create())
                {
                    infoLbl.Text = "Checking Hyper-V State...";
                    string hyperVstate = checkHyperVState();

                    if (!string.IsNullOrEmpty(hyperVstate))
                    {
                        if (hyperVstate != "2")
                        {
                            if (Equals(hyperVstate, "0"))
                            {
                                MessageBox.Show("Hyper-V is currently disabled.\n\nEnabling Hyper-V now...", "Hyper-V State", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                enableHyperV();
                            }
                            else if (Equals(hyperVstate, "1"))
                            {
                                infoLbl.Text += "\nChecking existing VMs...";
                                Collection<PSObject> vms = null;

                                try
                                {
                                    ps.AddCommand("Get-VM");
                                    ps.AddParameter("Name", "PT-01");
                                    vms = ps.Invoke();

                                    if (ps.HadErrors && (vms.Count == 0 || vms == null))
                                        ps.Streams.Error.Clear();
                                }

                                catch (Exception ex)
                                {
                                    if (vms.Count == 0)
                                    {
                                        ps.Streams.Error.Clear();
                                    }
                                    else
                                    {
                                        MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }

                                if (vms.Count >= 1)
                                {
                                    MessageBox.Show("Error: Found existing VM(s) named as 'PT-01': Cannot create more than 1 one PT-01 VM.\n\nPlease rename/delete the existing PT-01 VMs. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    //1: Checking for Virtual switches
                                    infoLbl.Text += "\nChecking for Virtual switches...";
                                    ps.Commands.Clear();
                                    ps.AddCommand("Get-VMSwitch");
                                    ps.AddParameter("Name", "V2-VM-NAT");
                                    var switches = ps.Invoke();

                                    if (ps.HadErrors)
                                    {
                                        foreach (ErrorRecord error in ps.Streams.Error)
                                        {
                                            MessageBox.Show("Error: " + error.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            ps.Streams.Error.Clear();
                                        }
                                    }

                                    switch (switches.Count)
                                    {
                                        case 0: //no switches found
                                            {
                                                try
                                                {
                                                    MessageBox.Show("No switches found with the name 'V2-VM-NAT'.\n\nCreating a new switch now...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    createSwitch();
                                                    ps.Commands.Clear();
                                                    ps.AddCommand("Get-VMSwitch");
                                                    ps.AddParameter("Name", "V2-VM-NAT");
                                                    switches = ps.Invoke();
                                                }
                                                catch (Exception ex)
                                                {
                                                    MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }

                                                if (switches.Count == 0) //no switch created
                                                {
                                                    MessageBox.Show("Failed to create the switch 'V2-VM-NAT'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                                else //switch created sucessfully
                                                {
                                                    try
                                                    {
                                                        MessageBox.Show("Switch 'V2-VM-NAT' has been succesfully created!\n\nCreating the VM now...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        ps.Commands.Clear();
                                                        createVM(ps);
                                                        ps.AddParameter("SwitchName", "V2-VM-NAT");
                                                        ps.Invoke();

                                                        if (!ps.HadErrors)
                                                        {
                                                            finalMsgBox = "Virtual Machine (9000 MB RAM, Generation 2) created successfully using V2-VM-NAT switch.";
                                                            //MessageBox.Show("Virtual Machine (9000 MB RAM, Generation 2) created successfully using V2-VM-NAT switch.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        }
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    }
                                                }
                                                break;
                                            }

                                        case 1: // 1 switch found
                                            {
                                                try
                                                {
                                                    ps.Commands.Clear();
                                                    createVM(ps);
                                                    ps.AddParameter("SwitchName", "V2-VM-NAT");
                                                    ps.Invoke();

                                                    if (!ps.HadErrors)
                                                    {
                                                        finalMsgBox = "Virtual Machine (9000 MB RAM, Generation 2) created successfully using V2-VM-NAT switch.";
                                                        //MessageBox.Show("Virtual Machine (9000 MB RAM, Generation 2) created successfully using V2-VM-NAT switch.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                                break;
                                            }

                                        default: //More than one switch found
                                            {
                                                try
                                                {
                                                    MessageBox.Show("Warning: More than one switch found with the name V2-VM-NAT.\n\nThe application will continue to create the VM without a virtual network adapter.\nPlease attach an appropriate virtual switch later.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    ps.Commands.Clear();
                                                    createVM(ps);
                                                    ps.Invoke();
                                                    if (!ps.HadErrors)
                                                    {
                                                        finalMsgBox = "Virtual Machine (9000 MB RAM, Generation 2) created successfully using V2-VM-NAT switch.";
                                                        //MessageBox.Show("Virtual Machine (9000 MB RAM, Generation 2) created successfully using V2-VM-NAT switch.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                                break;
                                            }
                                    }

                                    //2: Disable Dynamic Memory
                                    infoLbl.Text += "\nDisabling Dynamic Memory...";
                                    try
                                    {
                                        ps.Commands.Clear();
                                        ps.AddCommand("Set-VMMemory");
                                        ps.AddParameter("VMName", "PT-01");
                                        ps.AddParameter("DynamicMemoryEnabled", false);
                                        ps.Invoke();

                                        if (!ps.HadErrors)
                                        {
                                            finalMsgBox += "\n- Dynamic Memory disabled";
                                            //MessageBox.Show("Dynamic Memory disabled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                    //3: Processor Count setup
                                    infoLbl.Text += "\nSetting up virtual processors...";
                                    try
                                    {
                                        ps.Commands.Clear();
                                        ps.AddCommand("Set-VMProcessor");
                                        ps.AddParameter("VMName", "PT-01");
                                        ps.AddParameter("Count", 2);
                                        ps.Invoke();

                                        if (!ps.HadErrors)
                                        {
                                            finalMsgBox += "\n- Processor Count set";
                                            //MessageBox.Show("Processor Count set successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                    //4: Adding an existing HardDiskDrive
                                    infoLbl.Text += "\nAdding virtual HardDiskDrive...";
                                    try
                                    {
                                        OpenFileDialog openFileDialog = new OpenFileDialog();
                                        openFileDialog.InitialDirectory = @"C:\Hyper V Disk";
                                        openFileDialog.Filter = "VHDX Files (*.vhdx)|*.vhdx|All Files (*.*)|*.*";
                                        openFileDialog.FilterIndex = 1;
                                        openFileDialog.RestoreDirectory = true;
                                        openFileDialog.Multiselect = false;

                                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                                        {
                                            string selectedFilePath = openFileDialog.FileName;

                                            ps.Commands.Clear();
                                            ps.AddCommand("Add-VMHardDiskDrive");
                                            ps.AddParameter("VMName", "PT-01");
                                            ps.AddParameter("Path", selectedFilePath);
                                            ps.Invoke();
                                            finalMsgBox += "\n- Mounted " + selectedFilePath + " file to the VM.";
                                            //MessageBox.Show("Mounted " + selectedFilePath + " file to the VM.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            MessageBox.Show("No VHDX file selected.\nPlease add a Virtual Hard Disk to the Virtual Machine. \nThe application will continue to configure other settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                    //5: Disabling Checkpoints
                                    infoLbl.Text += "\nDisabling Checkpoints...";
                                    try
                                    {
                                        ps.Commands.Clear();
                                        ps.AddCommand("Set-VM");
                                        ps.AddParameter("Name", "PT-01");
                                        ps.AddParameter("CheckpointType", "Disabled");
                                        ps.Invoke();

                                        if (!ps.HadErrors)
                                        {
                                            finalMsgBox += "\n- Checkpoints disabled ";
                                            //MessageBox.Show("Checkpoints disabled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                    //6: Enabling SecureBoot
                                    infoLbl.Text += "\nEnabling SecureBoot...";
                                    try
                                    {
                                        ps.Commands.Clear();
                                        ps.AddCommand("Set-VMFirmware");
                                        ps.AddParameter("VMName", "PT-01");
                                        ps.AddParameter("EnableSecureBoot", "On");
                                        ps.AddParameter("SecureBootTemplate", "MicrosoftUEFICertificateAuthority");
                                        ps.Invoke();

                                        if (!ps.HadErrors)
                                        {
                                            finalMsgBox += "\n- Secure Boot enabled";
                                            //MessageBox.Show("Secure Boot enabled successfully and Template set to MS UEFI Certificate Authority! ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                    //7: Changing BootOrder

                                    try
                                    {
                                        string scriptPath = @"Scripts\SetBootOrder.ps1";
                                        Process process = new Process();
                                        ProcessStartInfo processInfo = new ProcessStartInfo();
                                        processInfo.FileName = "powershell.exe";
                                        processInfo.Arguments = "-ExecutionPolicy Bypass -File " + scriptPath;
                                        processInfo.UseShellExecute = false;
                                        processInfo.RedirectStandardOutput = true; // Enable redirection of stdout
                                        processInfo.RedirectStandardError = true; // Enable redirection of stderr
                                        processInfo.CreateNoWindow = true;
                                        process.StartInfo = processInfo;
                                        process.Start();
                                        process.WaitForExit();

                                        string output = process.StandardOutput.ReadToEnd();
                                        string errors = process.StandardError.ReadToEnd();

                                        if (!string.IsNullOrEmpty(errors))
                                        {
                                            MessageBox.Show("Error: " + errors, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else
                                        {
                                            finalMsgBox += "\n- Boot Order set";
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                    MessageBox.Show(finalMsgBox, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.ActiveControl = null;
            ApplyOriginalStyle(createvmButton);
            infoLbl.Text = "";
        }

        private void createswButton_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            ApplyCustomStyle(createswButton);
            infoLbl.Text = "Creating a virtual network adapter...";
            createSwitch();
            this.ActiveControl = null;
            ApplyOriginalStyle(createswButton);
            infoLbl.Text = "";
        }
      
        private void enableHyperVbtn_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            ApplyCustomStyle(enableHyperVbtn);
            
            infoLbl.Text = "Enabling Hyper-V features...";
            try
            {
                string hyperVstate = checkHyperVState();
                if (!string.IsNullOrEmpty(hyperVstate))
                {
                    if (hyperVstate != "2")
                    {
                        if (Equals(hyperVstate, "1"))
                        {
                            MessageBox.Show("Hyper-V is already enabled.\n\nPlease be advised that a system restart may be necessary to ensure all features are fully reflected.", "Hyper-V State", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (Equals(hyperVstate, "0"))
                        {
                            MessageBox.Show("Hyper-V is currently disabled.\n\nEnabling Hyper-V now...", "Hyper-V State", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            enableHyperV();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                hypervLbl.Text = "Hyper-V : Error";
            }
            this.ActiveControl = null;
            ApplyOriginalStyle(enableHyperVbtn);
            infoLbl.Text = "";
        }

        private async void vpnAdptrBtn2_Click(object sender, EventArgs e)//Vendor 2 VPN
        {
            this.ActiveControl = null;
            ApplyCustomStyle(vpnAdptrBtn2);
            infoLbl.Text = "Creating a VPN adapter...\nIt may take some time, Please wait...";
            createVpn(@"Scripts\VPN\Vendor2-InternalSwitch\Create-VPNConnection.ps1");
            this.ActiveControl = null;
            ApplyOriginalStyle(vpnAdptrBtn2);
            infoLbl.Text = "";

            do
            {
                updateVpnipLbl();
                await Task.Delay(5000);
            }
            while (vpnLbl.Text == "VPN : Disconnected/Not Found");
        }

        private void updateServerIpButton_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            ApplyCustomStyle(updateServerIpButton);
            updateServerIpButton.BackColor = SystemColors.ControlDark;
            infoLbl.Text = "Updating Server IP address...";
            string promptMessage = "Please enter the Server IP:";
            string serverIp = Interaction.InputBox(promptMessage, "Server IP Address", "").Trim();

            if (IPAddress.TryParse(serverIp, out IPAddress ipAddress))
            {
                try
                {
                    if (!string.IsNullOrEmpty(serverIp))
                    {
                        string pgsConfigPath = @"Scripts\pgsConfig\pgsConfig.exe";

                        if (System.IO.File.Exists(pgsConfigPath))
                        {
                            ProcessStartInfo startInfo = new ProcessStartInfo();
                            {
                                startInfo.FileName = pgsConfigPath;
                                startInfo.Arguments = "set -i " + serverIp;
                                startInfo.UseShellExecute = true;
                                startInfo.CreateNoWindow = true;
                            }
                            Process.Start(startInfo);
                            MessageBox.Show("This terminal is now pointed to Server IP: " + serverIp, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error: pgsConfig.exe not found at the specified path.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error: Please enter a valid Server IP!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            updateServeripLbl();

            this.ActiveControl = null;
            ApplyOriginalStyle(updateServerIpButton);
            infoLbl.Text = "";
        }
       
        private void renameBtn_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            ApplyCustomStyle(renameBtn);
            renameBtn.BackColor = SystemColors.ControlDark;
            infoLbl.Text = "Renaming Computer...";

            try
            {
                // Connect to WMI namespace
                ManagementScope scope = new ManagementScope("\\\\.\\root\\cimv2");
                scope.Connect();
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_ComputerSystem");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                foreach (ManagementObject obj in searcher.Get())
                {
                    string currentName = obj["Name"].ToString();
                    string promptMessage = "Please enter the new computer name:";
                    string newName = Interaction.InputBox(promptMessage, "New Computer Name", "").Trim();
                    obj.InvokeMethod("Rename", new object[] { newName, null, null });

                    MessageBox.Show("Computer successfully renamed from " + currentName + " to " + newName+".\n\nPlease be advised that a system restart is necessary to ensure that the new name is reflected.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            this.ActiveControl = null;
            ApplyOriginalStyle(renameBtn);
            infoLbl.Text = "";
        }

        private void updatePgsLoaderBtn_Click(object sender, EventArgs e)
        {

            this.ActiveControl = null;
            ApplyCustomStyle(updatePgsLoaderBtn);
            updatePgsLoaderBtn.BackColor = SystemColors.ControlDark;

            try
            {
                string[] files = Directory.GetFiles(@"C:\Program Files\", "pgsLoader*.exe");
                infoLbl.Text += "\nFound ";

                if (files.Length > 0)
                {
                    foreach (string file in files)
                    {
                        infoLbl.Text += Path.GetFileName(file) + " ";
                    }
                    infoLbl.Text += "in C:\\Program Files folder.";
                }
                else
                {
                    infoLbl.Text += "no pgsLoader*.exe files in C:\\Program Files folder. ";
                }

                DialogResult result = MessageBox.Show("Do you wish to update pgsLoader?\n\nIf yes, please ensure that the new pgsLoader*.exe file is present in C:\\Game folder.", "Update pgsLoader", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    foreach (Process process in Process.GetProcesses())
                    {
                        if (process.ProcessName.StartsWith("pgs"))
                        {
                            process.Kill();
                        }
                    }

                    if (files.Length > 0)
                    {
                        foreach (string file in files)
                        {
                            System.IO.File.Delete(file);
                        }
                    }

                    ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");

                    foreach (ManagementObject os in searcher.Get())
                    {
                        string architecture = os["OSArchitecture"].ToString();

                        if (architecture == "64-bit")
                        {
                            if (Directory.Exists(@"C:\Program Files\pgsLoaderX64"))
                            {
                                try
                                {
                                    string[] insideFiles = Directory.GetFiles(@"C:\Program Files\pgsLoaderX64");
                                    string[] insideDirectories = Directory.GetDirectories(@"C:\Program Files\pgsLoaderX64");

                                    infoLbl.Text += "\nDeleting the files/subdirectories within pgsLoaderX64 folder";

                                    foreach (string file in insideFiles)
                                    {
                                        System.IO.File.Delete(file);
                                    }

                                    foreach (string directory in insideDirectories)
                                    {
                                        Directory.Delete(directory, true);
                                    }
                                    //Directory.Delete(@"C:\Program Files\pgsLoaderX64");
                                }

                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }

                            string[] pgsLoaderFiles = Directory.GetFiles(@"C:\Game\", "pgsLoaderX64*.exe");

                            if (pgsLoaderFiles.Length == 1)
                            {
                                string path = pgsLoaderFiles[0];
                                string sourceFileName = Path.GetFileName(path);
                                string destFileName = Path.Combine(@"C:\Program Files", sourceFileName);

                                System.IO.File.Copy(path, destFileName, true);
                                Process.Start(destFileName).WaitForExit();
                                infoLbl.Text += "\nCurrent version of pgsLoader: " + sourceFileName;
                                MessageBox.Show("pgsLoader has been succesfully updated to " + sourceFileName, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (pgsLoaderFiles.Length > 1)
                            {
                                MessageBox.Show("Error: Found more than one pgsLoaderX64*.exe files in C:\\Game folder.\n\nPlease delete the unecessary pgsLoaderX64*.exe files in C:\\Game\\ folder and try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("Error: pgsLoader not found in C:\\Game folder.\n\nPlease copy pgsLoader in C:\\Game\\ folder.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            if (Directory.Exists(@"C:\Program Files\pgsLoaderX86"))
                            {
                                try
                                {
                                    string[] insideFiles = Directory.GetFiles(@"C:\Program Files\pgsLoaderX86");
                                    string[] insideDirectories = Directory.GetDirectories(@"C:\Program Files\pgsLoaderX86");

                                    infoLbl.Text += "\nDeleting the files/subdirectories within pgsLoaderX86 folder";

                                    foreach (string file in insideFiles)
                                    {
                                        System.IO.File.Delete(file);
                                    }

                                    foreach (string directory in insideDirectories)
                                    {
                                        Directory.Delete(directory, true);
                                    }
                                }

                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }

                            string[] pgsLoaderFiles = Directory.GetFiles(@"C:\Game\", "pgsLoaderX86*.exe");

                            if (pgsLoaderFiles.Length == 1)
                            {
                                string path = pgsLoaderFiles[0];
                                string sourceFileName = Path.GetFileName(path);
                                string destFileName = Path.Combine(@"C:\Program Files", sourceFileName);

                                System.IO.File.Copy(path, destFileName, true);
                                Process.Start(destFileName).WaitForExit();
                                infoLbl.Text += "\nCurrent version of pgsLoader: " + sourceFileName;
                                MessageBox.Show("pgsLoader has been succesfully updated to " + sourceFileName, "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (pgsLoaderFiles.Length > 1)
                            {
                                MessageBox.Show("Error: Found more than one pgsLoaderX86*.exe files in C:\\Game folder.\n\nPlease delete the unecessary pgsLoaderX86*.exe files in C:\\Game\\ folder and try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("Error: pgsLoader not found in C:\\Game folder.\n\nPlease copy pgsLoader in C:\\Game\\ folder.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.ActiveControl = null;
            ApplyOriginalStyle(updatePgsLoaderBtn);
            infoLbl.Text = "";
        }

        private void openhwFileBtn_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            ApplyCustomStyle(openhwFileBtn);
            openhwFileBtn.BackColor = SystemColors.ControlDark;

            string Market = System.IO.File.Exists(@"C:\\Game\\config\\hardware.xml") ? "V2" : "V1";
            string gameFolder = (Market == "V2") ? "Game" : "Sweeps";
            string filePath = "C://" + gameFolder + "//config//hardware.xml";

            

            if(System.IO.File.Exists(filePath))
            {
                try
                {
                    Process.Start("notepad.exe", filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(filePath + "file not found. ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.ActiveControl = null;
            ApplyOriginalStyle(openhwFileBtn);
            infoLbl.Text = "";
        }

        private void copyLogsBtn_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            ApplyCustomStyle(copyLogsBtn);
            copyLogsBtn.BackColor = SystemColors.ControlDark;

            string sourceFolderPath = @"C:\Game_Logs\";

            infoLbl.Text += "\nChecking C:\\Game_Logs folder...";
            string directory = Path.GetDirectoryName(sourceFolderPath);

            if(Directory.Exists(directory))
            {
                string destinationFolderPath = Path.Combine(@"C:\", "Game_Logs_" + DateTime.Now.ToString("MMddyyyy_hhmm tt"));

                try
                {
                    Directory.CreateDirectory(destinationFolderPath);
                    CopyAll(new DirectoryInfo(sourceFolderPath), new DirectoryInfo(destinationFolderPath));
                    MessageBox.Show("C:\\Game_Logs folder copied successfully to: " + destinationFolderPath, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("Error: C:\\Game_Logs folder not found!  ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.ActiveControl = null;
            ApplyOriginalStyle(copyLogsBtn);
            infoLbl.Text = "";
        }

        static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            // Copying files
            foreach (FileInfo file in source.GetFiles())
            {
                file.CopyTo(Path.Combine(target.FullName, file.Name), true);
            }

            // Copying subdirectories using recursion
            foreach (DirectoryInfo sourceSubDir in source.GetDirectories())
            {
                DirectoryInfo targetSubDir = target.CreateSubdirectory(sourceSubDir.Name);
                CopyAll(sourceSubDir, targetSubDir);
            }
        }
        
        private void testBvBtn_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            ApplyCustomStyle(testBvBtn);
            testBvBtn.BackColor = SystemColors.ControlDark;

            infoLbl.Text = "Testing Bill Acceptor...";
            string Market = System.IO.File.Exists(@"C:\\Game\\config\\hardware.xml") ? "V2" : "V1";

            string gameFolder = (Market == "V2") ? "Game" : "Sweeps";
            string filePath = "C://" + gameFolder + "//config//hardware.xml";

            

            if (System.IO.File.Exists(filePath))
            {
                if (billIndex != -1)
                {
                    switch (deviceTypeArr[billIndex])
                    {
                        case "CashCode":
                            {
                                string promptMessage = "Enter :-\n\n1 to run CCNet Simulator\n2 to run GBA Talk Tools";
                                string choice = Interaction.InputBox(promptMessage, "Choose a simulation tool", "").Trim();

                                if (choice == "1")
                                {
                                    if (System.IO.File.Exists(@"Tools\CCNETSimulator.exe"))
                                    {
                                        infoLbl.Text += "\nRunning CCNet Simulator...";
                                        Process.Start(@"Tools\CCNETSimulator.exe");
                                    }
                                }
                                else if (choice == "2")
                                {
                                    if (System.IO.File.Exists(@"Tools\CCNETSimulator.exe"))
                                    {
                                        infoLbl.Text += "\nRunning GBA Talk Tools...";
                                        Process.Start(@"Tools\GBA Talk\GBA_Talk_NET.exe");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Incorrect choice entered!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                infoLbl.Text = "";
                                break;
                            }

                        case "PTI":
                            {
                                if (System.IO.File.Exists(@"Tools\Pyramid NET RS-232\PyramidNETRS232_TestApp.exe"))
                                {
                                    infoLbl.Text += "\nRunning RS232 application...";
                                    Process.Start(@"Tools\Pyramid NET RS-232\PyramidNETRS232_TestApp.exe");
                                }
                                else
                                {
                                    MessageBox.Show("Error: PTI Bill Acceptor drivers/application not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                infoLbl.Text = "";
                                break;
                            }

                        case "ID003":
                            {
                                string promptMessage = "Enter :-\n\n1 to run ID-003 Basic Driver v1.6\n2 to run ID-003 Basic Driver v201 (For Kiosk)";
                                string choice = Interaction.InputBox(promptMessage, "Choose a simulation tool", "").Trim();

                                if (choice == "1")
                                {
                                    if (System.IO.File.Exists(@"Tools\BV_JCM\ID-003_Basic_Driver_v1.6\ID003 Basic Driver v1.6.exe"))
                                    {
                                        infoLbl.Text += "\nRunning ID003 Utility....";
                                        Process.Start(@"Tools\BV_JCM\ID-003_Basic_Driver_v1.6\ID003 Basic Driver v1.6.exe");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error: ID003 Bill Acceptor drivers/application not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    infoLbl.Text = "";
                                    break;
                                }
                                else if (choice == "2")
                                {
                                    if (System.IO.File.Exists(@"Tools\BV_JCM\ID-003 Basic Driver v201\ID003 Basic Driver v201.exe"))
                                    {
                                        infoLbl.Text += "\nRunning ID003 Utility....";
                                        Process.Start(@"Tools\BV_JCM\ID-003 Basic Driver v201\ID003 Basic Driver v201.exe");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error: ID003 Bill Acceptor drivers/application not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    infoLbl.Text = "";
                                    break;
                                }
                                else
                                {
                                    MessageBox.Show("Invalid Choice!! Returning to the main page.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                            }

                        default:
                            {
                                billAcptrLbl.Text = "Bill Acceptor : Error";
                                MessageBox.Show("Error: No Bill Acceptor found in C:\\Game\\config\\hardware file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                    }
                }
                else
                {
                    billAcptrLbl.Text = "Bill Acceptor : Error";
                    MessageBox.Show("Error: No Bill Acceptor found in C:\\Game\\config\\hardware file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(filePath+ "file not found. ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            this.ActiveControl = null;
            ApplyOriginalStyle(testBvBtn);
            infoLbl.Text = "";
        }

        private void testPrinterBtn_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            ApplyCustomStyle(testPrinterBtn);
            testPrinterBtn.BackColor = SystemColors.ControlDark;
            infoLbl.Text = "Testing Printer...";

            string filePath = @"C:\Game\config\hardware.xml";

            if (System.IO.File.Exists(filePath))
            {
                if (printerIndex != -1)
                {
                    switch (deviceTypeArr[printerIndex])
                    {
                        case "PayCheck":
                            {
                                if (System.IO.File.Exists(@"Tools\Nanoptix Printer Management\npxStatus.exe"))
                                {
                                    infoLbl.Text += "\nRunning Nanoptix Printer application...";
                                    Process.Start(@"Tools\Nanoptix Printer Management\npxStatus.exe");
                                }
                                else
                                {
                                    MessageBox.Show("Error: Nanoptix Printer application not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                infoLbl.Text = "";
                                break;
                            }

                        case "Epson":
                            {
                                if (System.IO.File.Exists(@"C:\Program Files (x86)\EPSON\EPSON Advanced Printer Driver 6\DriverPack\PrinterReg.exe"))
                                {
                                    infoLbl.Text += "\nRunning Epson Printer Utility...";
                                    Process.Start(@"C:\Program Files (x86)\EPSON\EPSON Advanced Printer Driver 6\DriverPack\PrinterReg.exe");
                                }

                                else if (System.IO.File.Exists(@"C:\Program Files (x86)\EPSON\EPSON Advanced Printer Driver 5\PrinterReg.exe"))
                                {
                                    infoLbl.Text += "\nRunning Epson Printer Utility...";
                                    Process.Start(@"C:\Program Files (x86)\EPSON\EPSON Advanced Printer Driver 5\PrinterReg.exe");
                                }

                                else
                                {
                                    MessageBox.Show("Error: Epson Printer drivers/application not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                infoLbl.Text = "";
                                break;
                            }

                        case "PHX":
                            {
                                infoLbl.Text += "\nPhoenix Printer can be tested on games.";

                                if (System.IO.File.Exists(@"Tools\Phoenix Tools\PhoenixTools.exe"))
                                {
                                    infoLbl.Text += "\nRunning Phoenix Printer utility...";
                                    Process.Start(@"Tools\Phoenix Tools\PhoenixTools.exe");
                                }
                                else
                                {
                                    MessageBox.Show("Error: Phoenix Priner application not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                infoLbl.Text = "";
                                break;
                            }

                        case "REL":
                            {
                                if (System.IO.File.Exists(@"Tools\Reliance Tools\Reliance.NET.UI.exe"))
                                {
                                    infoLbl.Text += "\nRunning Reliance Tools...";
                                    Process.Start(@"Tools\Reliance Tools\Reliance.NET.UI.exe");
                                }
                                else
                                {
                                    MessageBox.Show("Error: Reliance Tools not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                infoLbl.Text = "";
                                break;
                            }

                        case "CustomSPA":
                            {
                                if (System.IO.File.Exists(@"Tools\CUSTOM\PrinterSet\CePrinterSet.exe"))
                                {
                                    infoLbl.Text += "\nRunning Custom Tool...";
                                    Process.Start(@"Tools\CUSTOM\PrinterSet\CePrinterSet.exe");
                                }
                                else
                                {
                                    MessageBox.Show("Error: Custom Tool not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                infoLbl.Text = "";
                                break;
                            }
                        default:
                            {
                                prntLbl.Text = "Printer : Error";
                                MessageBox.Show("Error: No printer found in C:\\Game\\config\\hardware file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                    }
                }

                else if (printer2Index != -1)
                {
                    if (System.IO.File.Exists(@"Tools\Nanoptix Printer Management\npxStatus.exe"))
                    {
                        infoLbl.Text += "\nRunning Nanoptix Printer application...";
                        Process.Start(@"Tools\Nanoptix Printer Management\npxStatus.exe");
                    }
                    else
                    {
                        MessageBox.Show("Error: Nanoptix Printer application not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else
                {
                    prntLbl.Text = "Printer : Error";
                    MessageBox.Show("Error: No printer found in C:\\Game\\config\\hardware file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("C:\\Game\\config\\hardware.xml file not found. ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.ActiveControl = null;
            ApplyOriginalStyle(testPrinterBtn);
            infoLbl.Text = "";
        }

        private async void downldBtn_Click(object sender, EventArgs e)
        {
            string output;
            int intValue;
            string errors;
            string scriptPath1 = @"Scripts\downloadTest.ps1";

            progressBar.Visible = true;
            progressBar.Style = ProgressBarStyle.Blocks;

            string url = "https://pongstudios-my.sharepoint.com/:u:/p/sdadmin/EZRRyusm0LhHmys6HbAO2JoBTctWAKXvxiUDm_bvoImU7w?download=1";
            string dest = @"C:\Drivers\UPDD_06_00_742.exe";

            try
            {
                using (PowerShell ps = PowerShell.Create())
                {
                    changeProgressLblVal("0%");

                    ps.AddScript($"Start-BitsTransfer -Source '{url}' -Destination '{dest}'");
                    ps.Invoke();
                    MessageBox.Show("Hi-Download Started!");

                    Process process = new Process();
                    ProcessStartInfo processInfo = new ProcessStartInfo();
                    processInfo.FileName = "powershell.exe";
                    processInfo.Arguments = "-ExecutionPolicy Bypass -File " + scriptPath1;
                    processInfo.UseShellExecute = false;
                    processInfo.RedirectStandardOutput = true;
                    processInfo.RedirectStandardError = true;
                    processInfo.CreateNoWindow = true;
                    process.StartInfo = processInfo;

                    do
                    {
                        process.Start();
                        errors = process.StandardError.ReadToEnd().Trim();
                        output = process.StandardOutput.ReadToEnd().Trim();
                        int.TryParse(output, out intValue);
                        Console.WriteLine("Progress Bar Value is " + output);
                        progressBar.Value = intValue;
                        changeProgressLblVal("Downloading..." + output + "%");
                        Console.WriteLine("Label Value is " + progPercentLbl.Text);
                        await Task.Delay(1000);
                    }
                    while (intValue < 100);
                    changeProgressLblVal("Download Completed!");
                    await Task.Delay(1000);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //changeProgressLblVal("");
            //progressBar.Visible = false;
        }

        private void serverLogsBtn_Click(object sender, EventArgs e)
        {
            string enteredPassword = "";
            this.ActiveControl = null;
            ApplyCustomStyle(serverLogsBtn);
            serverLogsBtn.BackColor = SystemColors.ControlDark;
            
            infoLbl.Text += "Attempting to Connect to Server...";

            using (PasswordForm passwordForm = new PasswordForm())
            {
                if(passwordForm.ShowDialog() == DialogResult.OK)
                {
                   enteredPassword = passwordForm.password;
                }

            string hostname = "10.0.42.10";
            string username = "oracle";
            string password = "zsxdcfvPT007";

            if(String.Equals(enteredPassword,password))
                {
                try
                {
                    using (var sshClient = new SshClient(hostname, username, password))
                    {
                        sshClient.Connect();

                        if (sshClient.IsConnected)
                        {
                            infoLbl.Text += "\nConnection established";

                            //Copying Server.log
                            string serverTimestamp = DateTime.Now.ToString("MMddyyyy_hhmm");
                            string serverLogSource = "/home/oracle/server/wildfly-10.1.0.Final/standalone/log/server.log";
                            string serverLogdestination = $"/shared/server_{serverTimestamp}.log";
                            string serverCommand = $"cp {serverLogSource} {serverLogdestination}";

                            var cmd1 = sshClient.CreateCommand(serverCommand);
                            cmd1.Execute();

                            infoLbl.Text += "\nCopying server.log...";
                            if (cmd1.ExitStatus == 0)
                            {
                                infoLbl.Text += "Done";
                            }

                            else
                            {
                                MessageBox.Show($"Error during file copy {cmd1.Error}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            //Copying Socket.log
                            string socketTimestamp = DateTime.Now.ToString("MMddyyyy_hhmm");
                            string socketLogSource = "/home/oracle/server/wildfly-10.1.0.Final/standalone/log/socket.log";
                            string socketLogdestination = $"/shared/socket_{socketTimestamp}.log";
                            string socketCommand = $"cp {socketLogSource} {socketLogdestination}";

                            var cmd2 = sshClient.CreateCommand(socketCommand);
                            cmd2.Execute();
                            infoLbl.Text += "\nCopying socket.log...";

                            if (cmd2.ExitStatus == 0)
                            {
                                //MessageBox.Show("socket.log file copied successfully to \\\\10.0.42.10\\shared\\ folder", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                infoLbl.Text += "Done";
                            }

                            else
                            {
                                MessageBox.Show($"Error during file copy {cmd2.Error}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            //Copying Handler.log
                            string handlerTimestamp = DateTime.Now.ToString("MMddyyyy_hhmm");
                            string handlerLogSource = "/home/oracle/deploymgr/pong/task-handler/handler.log";
                            string handlerLogdestination = $"/shared/handler_{handlerTimestamp}.log";
                            string handlerCommand = $"cp {handlerLogSource} {handlerLogdestination}";

                            var cmd3 = sshClient.CreateCommand(handlerCommand);
                            cmd3.Execute();
                            infoLbl.Text += "\nCopying handler.log...";

                            if (cmd3.ExitStatus == 0)
                            {
                                //MessageBox.Show("handler.log file copied successfully to \\\\10.0.42.10\\shared\\ folder", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                infoLbl.Text += "Done";
                            }

                            else
                            {
                                MessageBox.Show($"Error during file copy {cmd3.Error}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Failed to establish session to VM!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        sshClient.Disconnect();
                        infoLbl.Text += "\nSession disconnected";

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error: Incorrect password entered!\n\nPlease try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            }


            this.ActiveControl = null;
            ApplyOriginalStyle(serverLogsBtn);
            infoLbl.Text = "";
        }

        private void deployerLogBtn_Click(object sender, EventArgs e)
        {
            string hostname = "10.0.42.10";
            string username = "oracle";
            string password = "zsxdcfvPT007";
            string deployerLogPath = "/home/oracle/deploymgr/pong/deploy/deployer.log";

            infoLbl.Text += "Checking deployer.log...";

            try
            {
                using (var sshClient = new SshClient(hostname, username, password))
                {
                    infoLbl.Text += "\nAttempting to Connect to Server...";
                    sshClient.Connect();

                    if(sshClient.IsConnected)
                    {
                        string command = $"tail -f {deployerLogPath}";
                        var cmd = sshClient.CreateCommand(command);

                        var processInfo = new ProcessStartInfo
                        {
                            FileName = "cmd.exe",
                            Arguments = $"/C start cmd.exe /K \"ssh {username}@{hostname} \\\"{command}\\\"\"",
                            UseShellExecute = true,
                        };

                        Process.Start(processInfo);
                        sshClient.Disconnect();
                    }
                    else
                    {
                        MessageBox.Show("Failed to establish session to VM!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        /************************MOUSE DOWN EVENT HANDLERS************************/

        private void logoffBtn_MouseEnter(object sender, EventArgs e)
        {
            logoffButton.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;             
        }

        private void restartButton_MouseEnter(object sender, EventArgs e)
        {
            restartButton.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
        }

        private void quitBtn_MouseEnter(object sender, EventArgs e)
        {
            quitBtn.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
        }

        private void quitBtn_MouseDown(object sender, EventArgs e)
        {
            quitBtn.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke;
        }

        private void enableHyperVbtn_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
            ApplyCustomStyle(enableHyperVbtn);
            enableHyperVbtn_Click (sender, e);
        }

        private void updateServerIpButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
            ApplyCustomStyle(updateServerIpButton);
            updateServerIpButton_Click(sender, e);
        }

        private void createvmButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
            ApplyCustomStyle(createvmButton);
            createvmButton_Click(sender, e);
        }

        private void createswButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
            ApplyCustomStyle(createswButton);
            createswButton_Click(sender, e);
        }

       /* private void vpnAdptrBtn1_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
            ApplyCustomStyle(vpnAdptrBtn1);
            vpnAdptrBtn1_Click(sender, e);
        }*/

        private void vpnAdptrBtn2_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
            ApplyCustomStyle(vpnAdptrBtn2);
            vpnAdptrBtn2_Click(sender, e);
        }

        /*private void logoffButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
            ApplyCustomStyle(logoffButton);
            logoffButton_Click(sender, e);
        }*/

        private void restartButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
            ApplyCustomStyle(restartButton);
            restartButton_Click(sender, e);
        }

        private void quitBtn_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
            ApplyCustomStyle(quitBtn);
            quitBtn_Click(sender, e);
        }
     
        private void renameBtn_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
            ApplyCustomStyle(renameBtn);
            renameBtn_Click(sender, e);
        }
        
        private void updatePgsLoaderBtn_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
            ApplyCustomStyle(updatePgsLoaderBtn);
            updatePgsLoaderBtn_Click(sender, e);
        }

        private void openhwFileBtn_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
            ApplyCustomStyle(openhwFileBtn);
            openhwFileBtn_Click(sender, e);
        }

        private void copyLogsBtn_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
            ApplyCustomStyle(copyLogsBtn);
            copyLogsBtn_Click(sender, e);
        }
      
        private void testBvBtn_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
            ApplyCustomStyle(testBvBtn);
            testBvBtn_Click(sender, e);
        }

        private void testPrinterBtn_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
            ApplyCustomStyle(testPrinterBtn);
            testPrinterBtn_Click(sender, e);
        }

        private void serverLogsBtn_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
            ApplyCustomStyle(serverLogsBtn);
            serverLogsBtn_Click(sender, e);
        }

        /*******************************MISCELLANEOUS FUNCTIONS**************************************/

        private void createSwitch()
        {
            try
            {
                string scriptPath = @"Scripts\V2-VM-NAT.ps1";
                Process process = new Process();
                ProcessStartInfo processInfo = new ProcessStartInfo();
                processInfo.FileName = "powershell.exe";
                processInfo.Arguments = "-ExecutionPolicy Bypass -File " + scriptPath;
                processInfo.UseShellExecute = true;
                //processInfo.RedirectStandardOutput = true; // Enable redirection of stdout
                processInfo.RedirectStandardError = false; // Enable redirection of stderr
                process.StartInfo = processInfo;
                process.Start();
                process.WaitForExit();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string checkHyperVState()
        {
            try
            {
                string scriptPath1 = @"Scripts\CheckHyperVState.ps1";
                Process process1 = new Process();
                ProcessStartInfo processInfo1 = new ProcessStartInfo();
                processInfo1.FileName = "powershell.exe";
                processInfo1.Arguments = "-ExecutionPolicy Bypass -File " + scriptPath1;
                processInfo1.UseShellExecute = false;
                processInfo1.RedirectStandardOutput = true; // Enable redirection of stdout
                processInfo1.RedirectStandardError = true;  // Enable redirection of stderr
                processInfo1.CreateNoWindow = true;
                process1.StartInfo = processInfo1;
                process1.Start();
                process1.WaitForExit();

                string output1 = process1.StandardOutput.ReadToEnd().Trim();
                string errors1 = process1.StandardError.ReadToEnd().Trim();

                if (!string.IsNullOrEmpty(errors1))
                {
                    MessageBox.Show("Error: " + errors1, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "2";
                }
                else
                    return output1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "2";
            }
        }

        private void enableHyperV()
        {
            try
            {
                string scriptPath2 = @"Scripts\EnableHyperV.ps1";
                Process process2 = new Process();
                ProcessStartInfo processInfo2 = new ProcessStartInfo();
                processInfo2.FileName = "powershell.exe";
                processInfo2.Arguments = "-ExecutionPolicy Bypass -File " + scriptPath2;
                processInfo2.UseShellExecute = false;
                processInfo2.RedirectStandardOutput = true; // Enable redirection of stdout
                processInfo2.RedirectStandardError = true; // Enable redirection of stderr
                //processInfo2.CreateNoWindow = true;
                process2.StartInfo = processInfo2;
                process2.Start();
                process2.WaitForExit();

                string output2 = process2.StandardOutput.ReadToEnd();
                string errors2 = process2.StandardError.ReadToEnd();

                if (!string.IsNullOrEmpty(errors2))
                {
                    MessageBox.Show("Error: " + errors2, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    hypervLbl.Text = "Hyper-V : Error";
                }
                else
                {
                    MessageBox.Show("Hyper-V has been successfully enabled! Please restart the computer to reflect all the changes.", "Enable Hyper-V", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                hypervLbl.Text = "Hyper-V : Error";
            }
        }

        private void createVM(PowerShell ps)
        {
            ps.AddCommand("New-VM");
            ps.AddParameter("Name", "PT-01");
            ps.AddParameter("MemoryStartupBytes", 9000 * 1024L * 1024L);
            ps.AddParameter("Generation", 2);
        }

        private void createVpn(string scriptPath)
        {
            try
            {
                Process process = new Process();
                ProcessStartInfo processInfo = new ProcessStartInfo();
                processInfo.FileName = "powershell.exe";
                processInfo.Arguments = "-ExecutionPolicy Bypass -File " + scriptPath;
                processInfo.UseShellExecute = true;
                processInfo.RedirectStandardOutput = false; // Enable redirection of stdout
                processInfo.RedirectStandardError = false; // Enable redirection of stderr
                process.StartInfo = processInfo;
                process.Start();
                process.WaitForExit();
                
                infoLbl.Text += "\nVPN adapter created!";
                MessageBox.Show("VPN adapter has been created successfully!", "VPN Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                infoLbl.Text += "\nVPN adapter created!";
                MessageBox.Show("VPN adapter has been created successfully!", "VPN Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void changeProgressLblVal(string text)
        {
            progPercentLbl.Text = text;
        }

        private void Check_Click(object sender, EventArgs e)
        {

        }

        private void buttonCheckServer_MouseEnter(object sender, EventArgs e)
        {
            changeToEnlargedFont(buttonCheckServer);
        }


        private void buttonCheckServer_MouseEnter_1(object sender, EventArgs e)
        {
            changeToEnlargedFont(buttonCheckServer);
        }

        private void buttonCheckServer_MouseLeave(object sender, EventArgs e)
        {
            changeToOriginalFont(buttonCheckServer);
        }

        /* ADD VALUES TO THE LIST BOX */

        public void addRequirements(object sender, EventArgs e)
        {
            if(dropDownVendor.Text == "V2")
            {
                listBoxRequirements.Items.Clear();
                labelStatus.Text = "";
                listBoxRequirements.Items.Add("Hyper V");
                listBoxRequirements.Items.Add("Virtualization Enabled in BIOS");
                listBoxRequirements.Items.Add("RAM - min. 16GB");
                
            }
            else if(dropDownVendor.Text == "V1")
            {
                listBoxRequirements.Items.Clear();
                labelStatus.Text = "";
                listBoxRequirements.Items.Add(".NET Framework v4.8 or later");
                listBoxRequirements.Items.Add(".NET Hosting Bundle v6.0.15");
                listBoxRequirements.Items.Add("Application Initialization Feature enabled in IIS");
                listBoxRequirements.Items.Add("ASPNETCORE Environment set to Production");
                listBoxRequirements.Items.Add("Visual C++ runtime 2012, 2013 and 2015-2019");
            }
        }

        public int CheckVirtualizationBios()
        {
            int flag = 0;
            try
            {
                // Query WMI for processor information
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor"))
                {
                    foreach (ManagementObject queryObj in searcher.Get())
                    {
                        // Check if virtualization is enabled
                        if (queryObj["VirtualizationFirmwareEnabled"] != null)
                        {
                            bool isVirtualizationEnabled = (bool)queryObj["VirtualizationFirmwareEnabled"];
                            flag = 1;
                        }
                        else
                        {
                            flag = 0;
                        }
                    }
                }
            }
            catch (ManagementException e)
            {
                string Message = e.Message;
                flag = 2;
            }
            
            return flag;
        }

        private void checkCompatiability(object Sender, EventArgs e) 
        {
            
            if (dropDownVendor.Text == "V2")
            {
                if (checkV2Server() == 3)
                {
                    labelStatus.Text = "✅ This PC is compatible for hosting a V2 Server.";
                }
                else
                {
                    labelStatus.Text = "❌ This PC is not compatible for hosting V2 Server.";
                }
            }
            else if (dropDownVendor.Text == "V1")
            {
                if (checkV1Server() == 5)
                {
                    labelStatus.Text = "✅ This PC is compatible for hosting a V1 Server.";
                }
                else
                {
                    labelStatus.Text = "❌ This PC is not compatible for hosting V1 Server.";
                }
            }
            

        }

        private int checkPhysicalMemory()
        {
            ComputerInfo computerInfo = new ComputerInfo();
            ulong totalPhysicalMemory = computerInfo.TotalPhysicalMemory;

            float ram = (float)totalPhysicalMemory / 1073741824;

            if (ram >= 15)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private int checkV2Server()
        {
            int flag = 0;

            if (checkHyperVState() == "1")
            {
                listBoxRequirements.SetItemChecked(0, true);
                flag++;
            }
            else 
            {
                labelStatus.Text = "Hyper V is disabled.";
            }
            if (CheckVirtualizationBios() == 1)
            {
                listBoxRequirements.SetItemChecked(1, true);
                flag++;
            }
            if (checkPhysicalMemory() == 1)
            {
                listBoxRequirements.SetItemChecked(2, true);
                flag++;
            }
            return flag;
        }

        private int checkV1Server()
        {
            int flag = 0;
            if (IsApplicationInitializationEnabled() == 1) 
            {
                listBoxRequirements.SetItemChecked(2, true);
                flag++;
            }
            if (IsAspNetCoreEnvironmentProduction())
            {
                listBoxRequirements.SetItemChecked (3, true);
                flag++;
            }
            if (AreVisualCRuntimesInstalled())
            {
                listBoxRequirements.SetItemChecked(4, true);
                flag++;
            }
            if (IsDotNetFramework48OrLater())
            {
                listBoxRequirements.SetItemChecked(0, true);
                flag++;
            }
            if (IsDotNetHostingBundle6015Installed())
            {
                listBoxRequirements.SetItemChecked(1, true);
                flag++;
            }
            return flag;

        }

        public bool IsDotNetFramework48OrLater()
        {
            const string subkey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\";
            using (RegistryKey ndpKey = Registry.LocalMachine.OpenSubKey(subkey))
            {
                if (ndpKey != null && ndpKey.GetValue("Release") != null)
                {
                    int releaseKey = (int)ndpKey.GetValue("Release");

                    // 528040 is for .NET Framework 4.8, 528209 for 4.8.1
                    return releaseKey >= 528040;
                }
            }
            return false;
        }


        public bool IsDotNetHostingBundle6015Installed()
        {
            const string subkey32 = @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
            const string subkey64 = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";

            bool CheckSubkey(string subkey)
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(subkey))
                {
                    if (key != null)
                    {
                        foreach (string subKeyName in key.GetSubKeyNames())
                        {
                            using (RegistryKey subKey = key.OpenSubKey(subKeyName))
                            {
                                if (subKey != null)
                                {
                                    string displayName = subKey.GetValue("DisplayName") as string;
                                    if (!string.IsNullOrEmpty(displayName) &&
                                        displayName.IndexOf("Hosting", StringComparison.OrdinalIgnoreCase) >= 0 &&
                                        displayName.IndexOf("6.0.15", StringComparison.OrdinalIgnoreCase) >= 0)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                    return false;
                }
            }

            return CheckSubkey(subkey32) || CheckSubkey(subkey64);
        }




        public int IsApplicationInitializationEnabled()
        {
            try
            {
                string scriptPath1 = @"Scripts\CheckIISApplicationInit.ps1";
                Process process1 = new Process();
                ProcessStartInfo processInfo1 = new ProcessStartInfo();
                processInfo1.FileName = "powershell.exe";
                processInfo1.Arguments = "-ExecutionPolicy Bypass -File " + scriptPath1;
                processInfo1.UseShellExecute = false;
                processInfo1.RedirectStandardOutput = true; // Enable redirection of stdout
                processInfo1.RedirectStandardError = true;  // Enable redirection of stderr
                processInfo1.CreateNoWindow = true;
                process1.StartInfo = processInfo1;
                process1.Start();
                process1.WaitForExit();

                string output1 = process1.StandardOutput.ReadToEnd().Trim();
                string errors1 = process1.StandardError.ReadToEnd().Trim();

                if (!string.IsNullOrEmpty(errors1))
                {
                    MessageBox.Show("Error: " + errors1, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 2;
            }
        }

        public bool IsAspNetCoreEnvironmentProduction()
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            return string.Equals(environment, "Production", StringComparison.OrdinalIgnoreCase);
        }


        public bool AreVisualCRuntimesInstalled()
        {
            return IsRuntimeInstalled("2012") &&
                   IsRuntimeInstalled("2013") &&
                   IsRuntimeInstalled("2015-2019");
        }

        private bool IsRuntimeInstalled(string version)
        {
            string[] keys = {
            @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall",
            @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall"
        };

            foreach (string keyPath in keys)
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath))
                {
                    if (key == null) continue;

                    foreach (string subKeyName in key.GetSubKeyNames())
                    {
                        using (RegistryKey subKey = key.OpenSubKey(subKeyName))
                        {
                            if (subKey != null)
                            {
                                string displayName = subKey.GetValue("DisplayName") as string;
                                string versionNumber = subKey.GetValue("DisplayVersion") as string;
                                if (!string.IsNullOrEmpty(displayName) &&
                                    !string.IsNullOrEmpty(versionNumber))
                                {
                                    if (IsMatchingRuntime(displayName, version))
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        private bool IsMatchingRuntime(string displayName, string targetVersion)
        {
            if (displayName.IndexOf("Microsoft Visual C++", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                if (targetVersion == "2015-2019")
                {
                    // The 2015-2019 runtimes often share a common redistributable name
                    return displayName.IndexOf("2015-2019", StringComparison.OrdinalIgnoreCase) >= 0 ||
                           displayName.IndexOf("2017", StringComparison.OrdinalIgnoreCase) >= 0 ||
                           displayName.IndexOf("2019", StringComparison.OrdinalIgnoreCase) >= 0;
                }
                else
                {
                    return displayName.IndexOf(targetVersion, StringComparison.OrdinalIgnoreCase) >= 0;
                }
            }
            return false;
        }


        /*********************  FETCH DOWNLOAD JSON  ************************/
        
        private async void FetchJson()
        {
            

            string url = "https://api.jsonbin.io/v3/b/65a15cbb266cfc3fde76bfce";
            string apikey = "$2a$10$m05lTBaGjnoT3Q5VsKgkHeIy6GyBFPDNGr4KKUmP3TxZwoGG4/gTe";

            var data = await FetchJsonDataAsync(url, apikey);

            

            PopulateMarkets(data);
        }

        private async Task<dynamic> FetchJsonDataAsync(string url, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-Access-Key", token);

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string jsonData = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<dynamic>(jsonData);
                }
                else
                {
                    MessageBox.Show($"Error: {response.StatusCode}");
                    return null;
                }
            }
        }

        private void PopulateMarkets(dynamic data)
        {
            comboBoxMarkets.DisplayMember = "Product";
            comboBoxMarkets.ValueMember = "Id";
            comboBoxMarkets.DataSource = data.record[0].Markets;
        }

        private void comboBoxMarkets_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedMarket = comboBoxMarkets.SelectedItem as dynamic;
            if (selectedMarket != null)
            {
                listBoxProducts.Items.Clear();
                string blockName = selectedMarket.BlockName;
                var products = selectedMarket[blockName];

                foreach (var product in products)
                {
                    listBoxProducts.Items.Add(product.Name);
                }
            }
        }

        private void fetchJson_MouseClick(object sender, MouseEventArgs e)
        {
            FetchJson();
            
        }

        private void listBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxProducts.CheckedItems.Count == 0)
            {
                btnDownload.Enabled = false;
            }
            else
            {
                btnDownload.Enabled = true;
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            var selectedMarket = comboBoxMarkets.SelectedItem as dynamic;
            var selectedProducts = listBoxProducts.SelectedItems;

            if (selectedMarket != null && selectedProducts.Count > 0)
            {
                string blockName = selectedMarket.BlockName;
                var products = selectedMarket[blockName];

                foreach (var selectedItem in selectedProducts)
                {
                    foreach (var product in products)
                    {
                        if (product.Name == selectedItem.ToString())
                        {
                            string File = product.Name;
                            string sourceLink = "https://pongstudios-my.sharepoint.com/:u:/p/sdadmin/" + product.Token + "?download=1";
                            string destination = @"C:\Intel\" + product.FileName;

                            
                            string script = @"Set-Location 'C:\\Program Files\\Tech Support\\Tech Support Tools\\Scripts'; .\aria2c.exe -d 'C:/Intel' --log 'C:\Intel\Download-logs.log' '" + sourceLink + @"'";
                            startDownload(script, File);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select at least one product.");
            }
        }

        private void startDownload(string script, string FileName)
        {
            try
            {
                // Define the path to the PowerShell script file
                string scriptFilePath = "C:/Intel/"+ FileName+".ps1";

                // Write the PowerShell script content to the file
                File.WriteAllText(scriptFilePath, script);

                // Set up the process start information
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-ExecutionPolicy Bypass -File \"{scriptFilePath}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                // Start the PowerShell process
                
                Process p = new Process();
                p.StartInfo = startInfo;
                p.Start();
                p.WaitForExit();

                if (!string.IsNullOrEmpty(p.StandardError.ReadToEnd()))
                {
                    MessageBox.Show(p.StandardError.ReadToEnd().Trim(), "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                File.Delete(scriptFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}

