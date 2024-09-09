namespace TSWindowsFormsApp1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.createvmButton = new System.Windows.Forms.Button();
            this.createswButton = new System.Windows.Forms.Button();
            this.serverlabel = new System.Windows.Forms.Label();
            this.vpnAdptrBtn2 = new System.Windows.Forms.Button();
            this.enableHyperVbtn = new System.Windows.Forms.Button();
            this.infoLbl = new System.Windows.Forms.Label();
            this.updateServerIpButton = new System.Windows.Forms.Button();
            this.terminalLbl = new System.Windows.Forms.Label();
            this.renameBtn = new System.Windows.Forms.Button();
            this.updatePgsLoaderBtn = new System.Windows.Forms.Button();
            this.openhwFileBtn = new System.Windows.Forms.Button();
            this.testPrinterBtn = new System.Windows.Forms.Button();
            this.testBvBtn = new System.Windows.Forms.Button();
            this.copyLogsBtn = new System.Windows.Forms.Button();
            this.downldBtn = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progPercentLbl = new System.Windows.Forms.Label();
            this.hypervLbl = new System.Windows.Forms.Label();
            this.serveripLbl = new System.Windows.Forms.Label();
            this.vpnLbl = new System.Windows.Forms.Label();
            this.compnameLbl = new System.Windows.Forms.Label();
            this.ipaddrLbl = new System.Windows.Forms.Label();
            this.dxdiagLbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.quitBtn = new System.Windows.Forms.Button();
            this.logoffButton = new System.Windows.Forms.Button();
            this.restartButton = new System.Windows.Forms.Button();
            this.graphicsLbl = new System.Windows.Forms.Label();
            this.billAcptrLbl = new System.Windows.Forms.Label();
            this.prntLbl = new System.Windows.Forms.Label();
            this.serverLogsBtn = new System.Windows.Forms.Button();
            this.deployerLogBtn = new System.Windows.Forms.Button();
            this.tabDownload = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Check = new System.Windows.Forms.TabPage();
            this.labelStatus = new System.Windows.Forms.Label();
            this.listBoxRequirements = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCheckServer = new System.Windows.Forms.Button();
            this.dropDownVendor = new System.Windows.Forms.ComboBox();
            this.labelCompatibilityTitle = new System.Windows.Forms.Label();
            this.DownloadPackagaes = new System.Windows.Forms.TabPage();
            this.btnDownload = new System.Windows.Forms.Button();
            this.listBoxProducts = new System.Windows.Forms.CheckedListBox();
            this.fetchJson = new System.Windows.Forms.Button();
            this.comboBoxMarkets = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabDownload.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.Check.SuspendLayout();
            this.DownloadPackagaes.SuspendLayout();
            this.SuspendLayout();
            // 
            // createvmButton
            // 
            this.createvmButton.BackColor = System.Drawing.SystemColors.Control;
            this.createvmButton.FlatAppearance.BorderSize = 0;
            this.createvmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createvmButton.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createvmButton.ForeColor = System.Drawing.Color.Black;
            this.createvmButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.createvmButton.Location = new System.Drawing.Point(9, 301);
            this.createvmButton.Name = "createvmButton";
            this.createvmButton.Size = new System.Drawing.Size(202, 30);
            this.createvmButton.TabIndex = 1;
            this.createvmButton.TabStop = false;
            this.createvmButton.Text = "Create VM";
            this.createvmButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.createvmButton.UseVisualStyleBackColor = false;
            this.createvmButton.Click += new System.EventHandler(this.createvmButton_Click);
            this.createvmButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.createvmButton_MouseDown);
            this.createvmButton.MouseEnter += new System.EventHandler(this.createvmButton_MouseEnter);
            this.createvmButton.MouseLeave += new System.EventHandler(this.createvmButton_MouseLeave);
            // 
            // createswButton
            // 
            this.createswButton.BackColor = System.Drawing.SystemColors.Control;
            this.createswButton.FlatAppearance.BorderSize = 0;
            this.createswButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createswButton.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createswButton.ForeColor = System.Drawing.Color.Black;
            this.createswButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.createswButton.Location = new System.Drawing.Point(9, 264);
            this.createswButton.Name = "createswButton";
            this.createswButton.Size = new System.Drawing.Size(202, 30);
            this.createswButton.TabIndex = 2;
            this.createswButton.TabStop = false;
            this.createswButton.Text = "Create Virtual Switch";
            this.createswButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.createswButton.UseVisualStyleBackColor = false;
            this.createswButton.Click += new System.EventHandler(this.createswButton_Click);
            this.createswButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.createswButton_MouseDown);
            this.createswButton.MouseEnter += new System.EventHandler(this.createswButton_MouseEnter);
            this.createswButton.MouseLeave += new System.EventHandler(this.createswButton_MouseLeave);
            // 
            // serverlabel
            // 
            this.serverlabel.AutoSize = true;
            this.serverlabel.BackColor = System.Drawing.Color.Transparent;
            this.serverlabel.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.serverlabel.ForeColor = System.Drawing.Color.Crimson;
            this.serverlabel.Location = new System.Drawing.Point(9, 200);
            this.serverlabel.Name = "serverlabel";
            this.serverlabel.Size = new System.Drawing.Size(78, 25);
            this.serverlabel.TabIndex = 7;
            this.serverlabel.Text = "SERVER";
            // 
            // vpnAdptrBtn2
            // 
            this.vpnAdptrBtn2.BackColor = System.Drawing.SystemColors.Control;
            this.vpnAdptrBtn2.FlatAppearance.BorderSize = 0;
            this.vpnAdptrBtn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vpnAdptrBtn2.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vpnAdptrBtn2.ForeColor = System.Drawing.Color.Black;
            this.vpnAdptrBtn2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.vpnAdptrBtn2.Location = new System.Drawing.Point(9, 337);
            this.vpnAdptrBtn2.Name = "vpnAdptrBtn2";
            this.vpnAdptrBtn2.Size = new System.Drawing.Size(202, 30);
            this.vpnAdptrBtn2.TabIndex = 4;
            this.vpnAdptrBtn2.TabStop = false;
            this.vpnAdptrBtn2.Text = "VPN Adapter";
            this.vpnAdptrBtn2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vpnAdptrBtn2.UseVisualStyleBackColor = false;
            this.vpnAdptrBtn2.Click += new System.EventHandler(this.vpnAdptrBtn2_Click);
            this.vpnAdptrBtn2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.vpnAdptrBtn2_MouseDown);
            this.vpnAdptrBtn2.MouseEnter += new System.EventHandler(this.vpnAdptrBtn2_MouseEnter);
            this.vpnAdptrBtn2.MouseLeave += new System.EventHandler(this.vpnAdptrBtn2_MouseLeave);
            // 
            // enableHyperVbtn
            // 
            this.enableHyperVbtn.BackColor = System.Drawing.SystemColors.Control;
            this.enableHyperVbtn.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.enableHyperVbtn.FlatAppearance.BorderSize = 0;
            this.enableHyperVbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enableHyperVbtn.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableHyperVbtn.ForeColor = System.Drawing.Color.Black;
            this.enableHyperVbtn.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.enableHyperVbtn.Location = new System.Drawing.Point(9, 228);
            this.enableHyperVbtn.Name = "enableHyperVbtn";
            this.enableHyperVbtn.Size = new System.Drawing.Size(202, 30);
            this.enableHyperVbtn.TabIndex = 0;
            this.enableHyperVbtn.TabStop = false;
            this.enableHyperVbtn.Text = "Enable Hyper-V";
            this.enableHyperVbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.enableHyperVbtn.UseVisualStyleBackColor = false;
            this.enableHyperVbtn.Click += new System.EventHandler(this.enableHyperVbtn_Click);
            this.enableHyperVbtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.enableHyperVbtn_MouseDown);
            this.enableHyperVbtn.MouseEnter += new System.EventHandler(this.enableHyperVbtn_Enter);
            this.enableHyperVbtn.MouseLeave += new System.EventHandler(this.enableHyperVbtn_MouseLeave);
            // 
            // infoLbl
            // 
            this.infoLbl.AutoSize = true;
            this.infoLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLbl.ForeColor = System.Drawing.Color.DarkRed;
            this.infoLbl.Location = new System.Drawing.Point(11, 489);
            this.infoLbl.Name = "infoLbl";
            this.infoLbl.Size = new System.Drawing.Size(0, 21);
            this.infoLbl.TabIndex = 19;
            // 
            // updateServerIpButton
            // 
            this.updateServerIpButton.BackColor = System.Drawing.SystemColors.Control;
            this.updateServerIpButton.FlatAppearance.BorderSize = 0;
            this.updateServerIpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateServerIpButton.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateServerIpButton.ForeColor = System.Drawing.Color.Black;
            this.updateServerIpButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.updateServerIpButton.Location = new System.Drawing.Point(9, 373);
            this.updateServerIpButton.Name = "updateServerIpButton";
            this.updateServerIpButton.Size = new System.Drawing.Size(202, 30);
            this.updateServerIpButton.TabIndex = 5;
            this.updateServerIpButton.TabStop = false;
            this.updateServerIpButton.Text = "Update Server IP";
            this.updateServerIpButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.updateServerIpButton.UseVisualStyleBackColor = false;
            this.updateServerIpButton.Click += new System.EventHandler(this.updateServerIpButton_Click);
            this.updateServerIpButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.updateServerIpButton_MouseDown);
            this.updateServerIpButton.MouseEnter += new System.EventHandler(this.updateServerIpButton_MouseEnter);
            this.updateServerIpButton.MouseLeave += new System.EventHandler(this.updateServerIpButton_MouseLeave);
            // 
            // terminalLbl
            // 
            this.terminalLbl.AutoSize = true;
            this.terminalLbl.BackColor = System.Drawing.Color.Transparent;
            this.terminalLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.terminalLbl.ForeColor = System.Drawing.Color.Crimson;
            this.terminalLbl.Location = new System.Drawing.Point(343, 200);
            this.terminalLbl.Name = "terminalLbl";
            this.terminalLbl.Size = new System.Drawing.Size(105, 25);
            this.terminalLbl.TabIndex = 20;
            this.terminalLbl.Text = "TERMINAL";
            // 
            // renameBtn
            // 
            this.renameBtn.BackColor = System.Drawing.SystemColors.Control;
            this.renameBtn.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.renameBtn.FlatAppearance.BorderSize = 0;
            this.renameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.renameBtn.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.renameBtn.ForeColor = System.Drawing.Color.Black;
            this.renameBtn.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.renameBtn.Location = new System.Drawing.Point(343, 228);
            this.renameBtn.Name = "renameBtn";
            this.renameBtn.Size = new System.Drawing.Size(202, 30);
            this.renameBtn.TabIndex = 21;
            this.renameBtn.TabStop = false;
            this.renameBtn.Text = "Rename Computer";
            this.renameBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.renameBtn.UseVisualStyleBackColor = false;
            this.renameBtn.Click += new System.EventHandler(this.renameBtn_Click);
            this.renameBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.renameBtn_MouseDown);
            this.renameBtn.MouseEnter += new System.EventHandler(this.renameBtn_MouseEnter);
            this.renameBtn.MouseLeave += new System.EventHandler(this.renameBtn_MouseLeave);
            // 
            // updatePgsLoaderBtn
            // 
            this.updatePgsLoaderBtn.BackColor = System.Drawing.SystemColors.Control;
            this.updatePgsLoaderBtn.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.updatePgsLoaderBtn.FlatAppearance.BorderSize = 0;
            this.updatePgsLoaderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updatePgsLoaderBtn.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updatePgsLoaderBtn.ForeColor = System.Drawing.Color.Black;
            this.updatePgsLoaderBtn.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.updatePgsLoaderBtn.Location = new System.Drawing.Point(343, 264);
            this.updatePgsLoaderBtn.Name = "updatePgsLoaderBtn";
            this.updatePgsLoaderBtn.Size = new System.Drawing.Size(202, 30);
            this.updatePgsLoaderBtn.TabIndex = 22;
            this.updatePgsLoaderBtn.TabStop = false;
            this.updatePgsLoaderBtn.Text = "Update pgsLoader";
            this.updatePgsLoaderBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.updatePgsLoaderBtn.UseVisualStyleBackColor = false;
            this.updatePgsLoaderBtn.Click += new System.EventHandler(this.updatePgsLoaderBtn_Click);
            this.updatePgsLoaderBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.updatePgsLoaderBtn_MouseDown);
            this.updatePgsLoaderBtn.MouseEnter += new System.EventHandler(this.updatePgsLoaderBtn_MouseEnter);
            this.updatePgsLoaderBtn.MouseLeave += new System.EventHandler(this.updatePgsLoaderBtn_MouseLeave);
            // 
            // openhwFileBtn
            // 
            this.openhwFileBtn.BackColor = System.Drawing.SystemColors.Control;
            this.openhwFileBtn.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.openhwFileBtn.FlatAppearance.BorderSize = 0;
            this.openhwFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openhwFileBtn.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openhwFileBtn.ForeColor = System.Drawing.Color.Black;
            this.openhwFileBtn.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.openhwFileBtn.Location = new System.Drawing.Point(343, 301);
            this.openhwFileBtn.Name = "openhwFileBtn";
            this.openhwFileBtn.Size = new System.Drawing.Size(202, 30);
            this.openhwFileBtn.TabIndex = 25;
            this.openhwFileBtn.TabStop = false;
            this.openhwFileBtn.Text = "Open hardware.xml file";
            this.openhwFileBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.openhwFileBtn.UseVisualStyleBackColor = false;
            this.openhwFileBtn.Click += new System.EventHandler(this.openhwFileBtn_Click);
            this.openhwFileBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openhwFileBtn_MouseDown);
            this.openhwFileBtn.MouseEnter += new System.EventHandler(this.openhwFileBtn_MouseEnter);
            this.openhwFileBtn.MouseLeave += new System.EventHandler(this.openhwFileBtn_MouseLeave);
            // 
            // testPrinterBtn
            // 
            this.testPrinterBtn.BackColor = System.Drawing.SystemColors.Control;
            this.testPrinterBtn.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.testPrinterBtn.FlatAppearance.BorderSize = 0;
            this.testPrinterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testPrinterBtn.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testPrinterBtn.ForeColor = System.Drawing.Color.Black;
            this.testPrinterBtn.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.testPrinterBtn.Location = new System.Drawing.Point(343, 409);
            this.testPrinterBtn.Name = "testPrinterBtn";
            this.testPrinterBtn.Size = new System.Drawing.Size(202, 30);
            this.testPrinterBtn.TabIndex = 23;
            this.testPrinterBtn.TabStop = false;
            this.testPrinterBtn.Text = "Test Printer";
            this.testPrinterBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.testPrinterBtn.UseVisualStyleBackColor = false;
            this.testPrinterBtn.Click += new System.EventHandler(this.testPrinterBtn_Click);
            this.testPrinterBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.testPrinterBtn_MouseDown);
            this.testPrinterBtn.MouseEnter += new System.EventHandler(this.testPrinterBtn_MouseEnter);
            this.testPrinterBtn.MouseLeave += new System.EventHandler(this.testPrinterBtn_MouseLeave);
            // 
            // testBvBtn
            // 
            this.testBvBtn.BackColor = System.Drawing.SystemColors.Control;
            this.testBvBtn.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.testBvBtn.FlatAppearance.BorderSize = 0;
            this.testBvBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testBvBtn.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testBvBtn.ForeColor = System.Drawing.Color.Black;
            this.testBvBtn.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.testBvBtn.Location = new System.Drawing.Point(343, 373);
            this.testBvBtn.Name = "testBvBtn";
            this.testBvBtn.Size = new System.Drawing.Size(202, 30);
            this.testBvBtn.TabIndex = 24;
            this.testBvBtn.TabStop = false;
            this.testBvBtn.Text = "Test Bill Validator";
            this.testBvBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.testBvBtn.UseVisualStyleBackColor = false;
            this.testBvBtn.Click += new System.EventHandler(this.testBvBtn_Click);
            this.testBvBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.testBvBtn_MouseDown);
            this.testBvBtn.MouseEnter += new System.EventHandler(this.testBvBtn_MouseEnter);
            this.testBvBtn.MouseLeave += new System.EventHandler(this.testBvBtn_MouseLeave);
            // 
            // copyLogsBtn
            // 
            this.copyLogsBtn.BackColor = System.Drawing.SystemColors.Control;
            this.copyLogsBtn.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.copyLogsBtn.FlatAppearance.BorderSize = 0;
            this.copyLogsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyLogsBtn.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyLogsBtn.ForeColor = System.Drawing.Color.Black;
            this.copyLogsBtn.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.copyLogsBtn.Location = new System.Drawing.Point(343, 337);
            this.copyLogsBtn.Name = "copyLogsBtn";
            this.copyLogsBtn.Size = new System.Drawing.Size(202, 30);
            this.copyLogsBtn.TabIndex = 26;
            this.copyLogsBtn.TabStop = false;
            this.copyLogsBtn.Text = "Copy Game_Logs";
            this.copyLogsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.copyLogsBtn.UseVisualStyleBackColor = false;
            this.copyLogsBtn.Click += new System.EventHandler(this.copyLogsBtn_Click);
            this.copyLogsBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.copyLogsBtn_MouseDown);
            this.copyLogsBtn.MouseEnter += new System.EventHandler(this.copyLogsBtn_MouseEnter);
            this.copyLogsBtn.MouseLeave += new System.EventHandler(this.copyLogsBtn_MouseLeave);
            // 
            // downldBtn
            // 
            this.downldBtn.BackColor = System.Drawing.SystemColors.Control;
            this.downldBtn.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.downldBtn.FlatAppearance.BorderSize = 0;
            this.downldBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downldBtn.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downldBtn.ForeColor = System.Drawing.Color.Black;
            this.downldBtn.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.downldBtn.Location = new System.Drawing.Point(343, 445);
            this.downldBtn.Name = "downldBtn";
            this.downldBtn.Size = new System.Drawing.Size(202, 30);
            this.downldBtn.TabIndex = 27;
            this.downldBtn.TabStop = false;
            this.downldBtn.Text = "Download Drivers";
            this.downldBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.downldBtn.UseVisualStyleBackColor = false;
            this.downldBtn.Click += new System.EventHandler(this.downldBtn_Click);
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.CadetBlue;
            this.progressBar.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.progressBar.Location = new System.Drawing.Point(6, 602);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(427, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 28;
            // 
            // progPercentLbl
            // 
            this.progPercentLbl.AutoSize = true;
            this.progPercentLbl.ForeColor = System.Drawing.Color.SteelBlue;
            this.progPercentLbl.Location = new System.Drawing.Point(5, 566);
            this.progPercentLbl.Name = "progPercentLbl";
            this.progPercentLbl.Size = new System.Drawing.Size(165, 23);
            this.progPercentLbl.TabIndex = 32;
            this.progPercentLbl.Text = "Progress Percentage";
            // 
            // hypervLbl
            // 
            this.hypervLbl.AutoSize = true;
            this.hypervLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hypervLbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.hypervLbl.Location = new System.Drawing.Point(11, 168);
            this.hypervLbl.Name = "hypervLbl";
            this.hypervLbl.Size = new System.Drawing.Size(78, 20);
            this.hypervLbl.TabIndex = 33;
            this.hypervLbl.Text = "Hyper-V : ";
            // 
            // serveripLbl
            // 
            this.serveripLbl.AutoSize = true;
            this.serveripLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serveripLbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.serveripLbl.Location = new System.Drawing.Point(335, 138);
            this.serveripLbl.Name = "serveripLbl";
            this.serveripLbl.Size = new System.Drawing.Size(83, 20);
            this.serveripLbl.TabIndex = 34;
            this.serveripLbl.Text = "Server IP : ";
            // 
            // vpnLbl
            // 
            this.vpnLbl.AutoSize = true;
            this.vpnLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vpnLbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.vpnLbl.Location = new System.Drawing.Point(335, 108);
            this.vpnLbl.Name = "vpnLbl";
            this.vpnLbl.Size = new System.Drawing.Size(52, 20);
            this.vpnLbl.TabIndex = 35;
            this.vpnLbl.Text = "VPN : ";
            // 
            // compnameLbl
            // 
            this.compnameLbl.AutoSize = true;
            this.compnameLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compnameLbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.compnameLbl.Location = new System.Drawing.Point(11, 108);
            this.compnameLbl.Name = "compnameLbl";
            this.compnameLbl.Size = new System.Drawing.Size(134, 20);
            this.compnameLbl.TabIndex = 38;
            this.compnameLbl.Text = "Computer Name : ";
            // 
            // ipaddrLbl
            // 
            this.ipaddrLbl.AutoSize = true;
            this.ipaddrLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipaddrLbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.ipaddrLbl.Location = new System.Drawing.Point(11, 138);
            this.ipaddrLbl.Name = "ipaddrLbl";
            this.ipaddrLbl.Size = new System.Drawing.Size(92, 20);
            this.ipaddrLbl.TabIndex = 39;
            this.ipaddrLbl.Text = "IP Address : ";
            // 
            // dxdiagLbl
            // 
            this.dxdiagLbl.AutoSize = true;
            this.dxdiagLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dxdiagLbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.dxdiagLbl.Location = new System.Drawing.Point(11, 48);
            this.dxdiagLbl.Name = "dxdiagLbl";
            this.dxdiagLbl.Size = new System.Drawing.Size(65, 20);
            this.dxdiagLbl.TabIndex = 41;
            this.dxdiagLbl.Text = "Model : ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(425, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            // 
            // quitBtn
            // 
            this.quitBtn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.quitBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("quitBtn.BackgroundImage")));
            this.quitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.quitBtn.FlatAppearance.BorderSize = 0;
            this.quitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitBtn.ForeColor = System.Drawing.Color.Teal;
            this.quitBtn.Location = new System.Drawing.Point(527, 510);
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Padding = new System.Windows.Forms.Padding(100);
            this.quitBtn.Size = new System.Drawing.Size(36, 29);
            this.quitBtn.TabIndex = 8;
            this.quitBtn.TabStop = false;
            this.quitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.quitBtn.UseVisualStyleBackColor = false;
            this.quitBtn.Click += new System.EventHandler(this.quitBtn_Click);
            this.quitBtn.MouseEnter += new System.EventHandler(this.quitBtn_MouseEnter);
            // 
            // logoffButton
            // 
            this.logoffButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.logoffButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logoffButton.BackgroundImage")));
            this.logoffButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logoffButton.FlatAppearance.BorderSize = 0;
            this.logoffButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoffButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoffButton.ForeColor = System.Drawing.Color.Teal;
            this.logoffButton.Location = new System.Drawing.Point(527, 596);
            this.logoffButton.Name = "logoffButton";
            this.logoffButton.Size = new System.Drawing.Size(36, 29);
            this.logoffButton.TabIndex = 6;
            this.logoffButton.TabStop = false;
            this.logoffButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.logoffButton.UseVisualStyleBackColor = false;
            this.logoffButton.Click += new System.EventHandler(this.logoffButton_Click);
            // 
            // restartButton
            // 
            this.restartButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.restartButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("restartButton.BackgroundImage")));
            this.restartButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.restartButton.FlatAppearance.BorderSize = 0;
            this.restartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restartButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restartButton.ForeColor = System.Drawing.Color.Teal;
            this.restartButton.Location = new System.Drawing.Point(527, 554);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(36, 29);
            this.restartButton.TabIndex = 7;
            this.restartButton.TabStop = false;
            this.restartButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.restartButton.UseVisualStyleBackColor = false;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            this.restartButton.MouseEnter += new System.EventHandler(this.restartButton_MouseEnter);
            // 
            // graphicsLbl
            // 
            this.graphicsLbl.AutoSize = true;
            this.graphicsLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graphicsLbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.graphicsLbl.Location = new System.Drawing.Point(11, 78);
            this.graphicsLbl.Name = "graphicsLbl";
            this.graphicsLbl.Size = new System.Drawing.Size(80, 20);
            this.graphicsLbl.TabIndex = 44;
            this.graphicsLbl.Text = "Graphics : ";
            // 
            // billAcptrLbl
            // 
            this.billAcptrLbl.AutoSize = true;
            this.billAcptrLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.billAcptrLbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.billAcptrLbl.Location = new System.Drawing.Point(335, 78);
            this.billAcptrLbl.Name = "billAcptrLbl";
            this.billAcptrLbl.Size = new System.Drawing.Size(107, 20);
            this.billAcptrLbl.TabIndex = 46;
            this.billAcptrLbl.Text = "Bill Acceptor : ";
            // 
            // prntLbl
            // 
            this.prntLbl.AutoSize = true;
            this.prntLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prntLbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.prntLbl.Location = new System.Drawing.Point(335, 48);
            this.prntLbl.Name = "prntLbl";
            this.prntLbl.Size = new System.Drawing.Size(68, 20);
            this.prntLbl.TabIndex = 47;
            this.prntLbl.Text = "Printer : ";
            // 
            // serverLogsBtn
            // 
            this.serverLogsBtn.BackColor = System.Drawing.SystemColors.Control;
            this.serverLogsBtn.FlatAppearance.BorderSize = 0;
            this.serverLogsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.serverLogsBtn.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverLogsBtn.ForeColor = System.Drawing.Color.Black;
            this.serverLogsBtn.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.serverLogsBtn.Location = new System.Drawing.Point(9, 409);
            this.serverLogsBtn.Name = "serverLogsBtn";
            this.serverLogsBtn.Size = new System.Drawing.Size(202, 30);
            this.serverLogsBtn.TabIndex = 48;
            this.serverLogsBtn.TabStop = false;
            this.serverLogsBtn.Text = "Copy Server Logs";
            this.serverLogsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.serverLogsBtn.UseVisualStyleBackColor = false;
            this.serverLogsBtn.Click += new System.EventHandler(this.serverLogsBtn_Click);
            this.serverLogsBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.serverLogsBtn_MouseDown);
            this.serverLogsBtn.MouseEnter += new System.EventHandler(this.serverLogsBtn_MouseEnter);
            this.serverLogsBtn.MouseLeave += new System.EventHandler(this.serverLogsBtn_MouseLeave);
            // 
            // deployerLogBtn
            // 
            this.deployerLogBtn.BackColor = System.Drawing.SystemColors.Control;
            this.deployerLogBtn.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.deployerLogBtn.FlatAppearance.BorderSize = 0;
            this.deployerLogBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deployerLogBtn.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deployerLogBtn.ForeColor = System.Drawing.Color.Black;
            this.deployerLogBtn.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.deployerLogBtn.Location = new System.Drawing.Point(9, 445);
            this.deployerLogBtn.Name = "deployerLogBtn";
            this.deployerLogBtn.Size = new System.Drawing.Size(202, 30);
            this.deployerLogBtn.TabIndex = 49;
            this.deployerLogBtn.TabStop = false;
            this.deployerLogBtn.Text = "Check deployer.log";
            this.deployerLogBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deployerLogBtn.UseVisualStyleBackColor = false;
            this.deployerLogBtn.Click += new System.EventHandler(this.deployerLogBtn_Click);
            // 
            // tabDownload
            // 
            this.tabDownload.Controls.Add(this.tabPage1);
            this.tabDownload.Controls.Add(this.Check);
            this.tabDownload.Controls.Add(this.DownloadPackagaes);
            this.tabDownload.Location = new System.Drawing.Point(0, 0);
            this.tabDownload.Name = "tabDownload";
            this.tabDownload.SelectedIndex = 0;
            this.tabDownload.Size = new System.Drawing.Size(583, 671);
            this.tabDownload.TabIndex = 50;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tabPage1.Controls.Add(this.progressBar);
            this.tabPage1.Controls.Add(this.logoffButton);
            this.tabPage1.Controls.Add(this.infoLbl);
            this.tabPage1.Controls.Add(this.quitBtn);
            this.tabPage1.Controls.Add(this.restartButton);
            this.tabPage1.Controls.Add(this.progPercentLbl);
            this.tabPage1.Controls.Add(this.deployerLogBtn);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.serverLogsBtn);
            this.tabPage1.Controls.Add(this.prntLbl);
            this.tabPage1.Controls.Add(this.createvmButton);
            this.tabPage1.Controls.Add(this.billAcptrLbl);
            this.tabPage1.Controls.Add(this.createswButton);
            this.tabPage1.Controls.Add(this.graphicsLbl);
            this.tabPage1.Controls.Add(this.serverlabel);
            this.tabPage1.Controls.Add(this.dxdiagLbl);
            this.tabPage1.Controls.Add(this.vpnAdptrBtn2);
            this.tabPage1.Controls.Add(this.ipaddrLbl);
            this.tabPage1.Controls.Add(this.enableHyperVbtn);
            this.tabPage1.Controls.Add(this.compnameLbl);
            this.tabPage1.Controls.Add(this.updateServerIpButton);
            this.tabPage1.Controls.Add(this.vpnLbl);
            this.tabPage1.Controls.Add(this.terminalLbl);
            this.tabPage1.Controls.Add(this.serveripLbl);
            this.tabPage1.Controls.Add(this.renameBtn);
            this.tabPage1.Controls.Add(this.hypervLbl);
            this.tabPage1.Controls.Add(this.updatePgsLoaderBtn);
            this.tabPage1.Controls.Add(this.testPrinterBtn);
            this.tabPage1.Controls.Add(this.testBvBtn);
            this.tabPage1.Controls.Add(this.downldBtn);
            this.tabPage1.Controls.Add(this.openhwFileBtn);
            this.tabPage1.Controls.Add(this.copyLogsBtn);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(575, 635);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "HomePage";
            // 
            // Check
            // 
            this.Check.Controls.Add(this.labelStatus);
            this.Check.Controls.Add(this.listBoxRequirements);
            this.Check.Controls.Add(this.label1);
            this.Check.Controls.Add(this.buttonCheckServer);
            this.Check.Controls.Add(this.dropDownVendor);
            this.Check.Controls.Add(this.labelCompatibilityTitle);
            this.Check.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Check.Location = new System.Drawing.Point(4, 32);
            this.Check.Margin = new System.Windows.Forms.Padding(0);
            this.Check.Name = "Check";
            this.Check.Padding = new System.Windows.Forms.Padding(3);
            this.Check.Size = new System.Drawing.Size(575, 635);
            this.Check.TabIndex = 1;
            this.Check.Text = "Compatibility";
            this.Check.UseVisualStyleBackColor = true;
            this.Check.Click += new System.EventHandler(this.Check_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.ForeColor = System.Drawing.Color.Black;
            this.labelStatus.Location = new System.Drawing.Point(29, 541);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 25);
            this.labelStatus.TabIndex = 6;
            this.labelStatus.UseMnemonic = false;
            // 
            // listBoxRequirements
            // 
            this.listBoxRequirements.FormattingEnabled = true;
            this.listBoxRequirements.Location = new System.Drawing.Point(19, 309);
            this.listBoxRequirements.Name = "listBoxRequirements";
            this.listBoxRequirements.Size = new System.Drawing.Size(513, 193);
            this.listBoxRequirements.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(42, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Vendor";
            // 
            // buttonCheckServer
            // 
            this.buttonCheckServer.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCheckServer.FlatAppearance.BorderSize = 0;
            this.buttonCheckServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCheckServer.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCheckServer.ForeColor = System.Drawing.Color.Black;
            this.buttonCheckServer.Location = new System.Drawing.Point(296, 115);
            this.buttonCheckServer.Name = "buttonCheckServer";
            this.buttonCheckServer.Size = new System.Drawing.Size(166, 40);
            this.buttonCheckServer.TabIndex = 3;
            this.buttonCheckServer.Text = "Check";
            this.buttonCheckServer.UseVisualStyleBackColor = false;
            this.buttonCheckServer.Click += new System.EventHandler(this.checkCompatiability);
            this.buttonCheckServer.MouseEnter += new System.EventHandler(this.buttonCheckServer_MouseEnter_1);
            this.buttonCheckServer.MouseLeave += new System.EventHandler(this.buttonCheckServer_MouseLeave);
            // 
            // dropDownVendor
            // 
            this.dropDownVendor.FormattingEnabled = true;
            this.dropDownVendor.Items.AddRange(new object[] {
            "V1",
            "V2"});
            this.dropDownVendor.Location = new System.Drawing.Point(137, 115);
            this.dropDownVendor.Name = "dropDownVendor";
            this.dropDownVendor.Size = new System.Drawing.Size(121, 33);
            this.dropDownVendor.TabIndex = 2;
            this.dropDownVendor.SelectedIndexChanged += new System.EventHandler(this.addRequirements);
            // 
            // labelCompatibilityTitle
            // 
            this.labelCompatibilityTitle.AutoSize = true;
            this.labelCompatibilityTitle.ForeColor = System.Drawing.Color.Black;
            this.labelCompatibilityTitle.Location = new System.Drawing.Point(14, 16);
            this.labelCompatibilityTitle.Name = "labelCompatibilityTitle";
            this.labelCompatibilityTitle.Size = new System.Drawing.Size(448, 25);
            this.labelCompatibilityTitle.TabIndex = 0;
            this.labelCompatibilityTitle.Text = "Check if the machine is capable of hosting a Server";
            // 
            // DownloadPackagaes
            // 
            this.DownloadPackagaes.Controls.Add(this.btnDownload);
            this.DownloadPackagaes.Controls.Add(this.listBoxProducts);
            this.DownloadPackagaes.Controls.Add(this.fetchJson);
            this.DownloadPackagaes.Controls.Add(this.comboBoxMarkets);
            this.DownloadPackagaes.Location = new System.Drawing.Point(4, 32);
            this.DownloadPackagaes.Name = "DownloadPackagaes";
            this.DownloadPackagaes.Padding = new System.Windows.Forms.Padding(3);
            this.DownloadPackagaes.Size = new System.Drawing.Size(575, 635);
            this.DownloadPackagaes.TabIndex = 2;
            this.DownloadPackagaes.Text = "Download Packages";
            this.DownloadPackagaes.UseVisualStyleBackColor = true;
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.SystemColors.Control;
            this.btnDownload.Enabled = false;
            this.btnDownload.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnDownload.FlatAppearance.BorderSize = 0;
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownload.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.ForeColor = System.Drawing.Color.Black;
            this.btnDownload.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnDownload.Location = new System.Drawing.Point(22, 487);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(515, 30);
            this.btnDownload.TabIndex = 25;
            this.btnDownload.TabStop = false;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // listBoxProducts
            // 
            this.listBoxProducts.CheckOnClick = true;
            this.listBoxProducts.FormattingEnabled = true;
            this.listBoxProducts.Location = new System.Drawing.Point(22, 204);
            this.listBoxProducts.Name = "listBoxProducts";
            this.listBoxProducts.Size = new System.Drawing.Size(515, 254);
            this.listBoxProducts.TabIndex = 24;
            this.listBoxProducts.SelectedIndexChanged += new System.EventHandler(this.listBoxProducts_SelectedIndexChanged);
            // 
            // fetchJson
            // 
            this.fetchJson.BackColor = System.Drawing.SystemColors.Control;
            this.fetchJson.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.fetchJson.FlatAppearance.BorderSize = 0;
            this.fetchJson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fetchJson.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fetchJson.ForeColor = System.Drawing.Color.Black;
            this.fetchJson.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.fetchJson.Location = new System.Drawing.Point(310, 148);
            this.fetchJson.Name = "fetchJson";
            this.fetchJson.Size = new System.Drawing.Size(202, 30);
            this.fetchJson.TabIndex = 22;
            this.fetchJson.TabStop = false;
            this.fetchJson.Text = "Fetch JSON";
            this.fetchJson.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.fetchJson.UseVisualStyleBackColor = false;
            this.fetchJson.MouseClick += new System.Windows.Forms.MouseEventHandler(this.fetchJson_MouseClick);
            // 
            // comboBoxMarkets
            // 
            this.comboBoxMarkets.FormattingEnabled = true;
            this.comboBoxMarkets.Location = new System.Drawing.Point(22, 147);
            this.comboBoxMarkets.Name = "comboBoxMarkets";
            this.comboBoxMarkets.Size = new System.Drawing.Size(193, 31);
            this.comboBoxMarkets.TabIndex = 0;
            this.comboBoxMarkets.SelectedIndexChanged += new System.EventHandler(this.comboBoxMarkets_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(582, 669);
            this.Controls.Add(this.tabDownload);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Tech Support Tools";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabDownload.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.Check.ResumeLayout(false);
            this.Check.PerformLayout();
            this.DownloadPackagaes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Button createvmButton;
        private System.Windows.Forms.Button logoffButton;
        private System.Windows.Forms.Button createswButton;
        private System.Windows.Forms.Label serverlabel;
        private System.Windows.Forms.Button vpnAdptrBtn2;
        private System.Windows.Forms.Button enableHyperVbtn;
        private System.Windows.Forms.Button quitBtn;
        private System.Windows.Forms.Label infoLbl;
        private System.Windows.Forms.Button updateServerIpButton;
        private System.Windows.Forms.Label terminalLbl;
        private System.Windows.Forms.Button renameBtn;
        private System.Windows.Forms.Button updatePgsLoaderBtn;
        private System.Windows.Forms.Button openhwFileBtn;
        private System.Windows.Forms.Button testPrinterBtn;
        private System.Windows.Forms.Button testBvBtn;
        private System.Windows.Forms.Button copyLogsBtn;
        private System.Windows.Forms.Button downldBtn;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label progPercentLbl;
        private System.Windows.Forms.Label hypervLbl;
        private System.Windows.Forms.Label serveripLbl;
        private System.Windows.Forms.Label vpnLbl;
        private System.Windows.Forms.Label compnameLbl;
        private System.Windows.Forms.Label ipaddrLbl;
        private System.Windows.Forms.Label dxdiagLbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label graphicsLbl;
        private System.Windows.Forms.Label billAcptrLbl;
        private System.Windows.Forms.Label prntLbl;
        private System.Windows.Forms.Button serverLogsBtn;
        private System.Windows.Forms.Button deployerLogBtn;
        private System.Windows.Forms.TabControl tabDownload;
        private System.Windows.Forms.TabPage Check;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label labelCompatibilityTitle;
        private System.Windows.Forms.ComboBox dropDownVendor;
        private System.Windows.Forms.Button buttonCheckServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox listBoxRequirements;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TabPage DownloadPackagaes;
        private System.Windows.Forms.ComboBox comboBoxMarkets;
        private System.Windows.Forms.Button fetchJson;
        private System.Windows.Forms.CheckedListBox listBoxProducts;
        private System.Windows.Forms.Button btnDownload;
        //private System.Windows.Forms.Label label3;
    }
}

