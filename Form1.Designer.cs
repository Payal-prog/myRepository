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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.createvmButton.Location = new System.Drawing.Point(16, 313);
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
            this.createswButton.Location = new System.Drawing.Point(16, 276);
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
            this.serverlabel.Location = new System.Drawing.Point(16, 212);
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
            this.vpnAdptrBtn2.Location = new System.Drawing.Point(16, 349);
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
            this.enableHyperVbtn.Location = new System.Drawing.Point(16, 240);
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
            this.infoLbl.Location = new System.Drawing.Point(18, 456);
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
            this.updateServerIpButton.Location = new System.Drawing.Point(16, 385);
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
            this.terminalLbl.Location = new System.Drawing.Point(350, 212);
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
            this.renameBtn.Location = new System.Drawing.Point(350, 240);
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
            this.updatePgsLoaderBtn.Location = new System.Drawing.Point(350, 276);
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
            this.openhwFileBtn.Location = new System.Drawing.Point(350, 313);
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
            this.testPrinterBtn.Location = new System.Drawing.Point(350, 421);
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
            this.testBvBtn.Location = new System.Drawing.Point(350, 385);
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
            this.copyLogsBtn.Location = new System.Drawing.Point(350, 349);
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
            this.downldBtn.Location = new System.Drawing.Point(350, 456);
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
            this.progressBar.Location = new System.Drawing.Point(12, 616);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(427, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 28;
            // 
            // progPercentLbl
            // 
            this.progPercentLbl.AutoSize = true;
            this.progPercentLbl.ForeColor = System.Drawing.Color.SteelBlue;
            this.progPercentLbl.Location = new System.Drawing.Point(12, 580);
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
            this.hypervLbl.Location = new System.Drawing.Point(18, 180);
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
            this.serveripLbl.Location = new System.Drawing.Point(342, 150);
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
            this.vpnLbl.Location = new System.Drawing.Point(342, 120);
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
            this.compnameLbl.Location = new System.Drawing.Point(18, 120);
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
            this.ipaddrLbl.Location = new System.Drawing.Point(18, 150);
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
            this.dxdiagLbl.Location = new System.Drawing.Point(18, 60);
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
            this.pictureBox1.Location = new System.Drawing.Point(402, 12);
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
            this.quitBtn.Location = new System.Drawing.Point(504, 519);
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
            this.logoffButton.Location = new System.Drawing.Point(504, 589);
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
            this.restartButton.Location = new System.Drawing.Point(504, 554);
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
            this.graphicsLbl.Location = new System.Drawing.Point(18, 90);
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
            this.billAcptrLbl.Location = new System.Drawing.Point(342, 90);
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
            this.prntLbl.Location = new System.Drawing.Point(342, 60);
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
            this.serverLogsBtn.Location = new System.Drawing.Point(16, 421);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(572, 651);
            this.Controls.Add(this.serverLogsBtn);
            this.Controls.Add(this.prntLbl);
            this.Controls.Add(this.billAcptrLbl);
            this.Controls.Add(this.graphicsLbl);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dxdiagLbl);
            this.Controls.Add(this.ipaddrLbl);
            this.Controls.Add(this.compnameLbl);
            this.Controls.Add(this.vpnLbl);
            this.Controls.Add(this.serveripLbl);
            this.Controls.Add(this.hypervLbl);
            this.Controls.Add(this.progPercentLbl);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.downldBtn);
            this.Controls.Add(this.copyLogsBtn);
            this.Controls.Add(this.openhwFileBtn);
            this.Controls.Add(this.testBvBtn);
            this.Controls.Add(this.testPrinterBtn);
            this.Controls.Add(this.updatePgsLoaderBtn);
            this.Controls.Add(this.renameBtn);
            this.Controls.Add(this.terminalLbl);
            this.Controls.Add(this.updateServerIpButton);
            this.Controls.Add(this.infoLbl);
            this.Controls.Add(this.quitBtn);
            this.Controls.Add(this.enableHyperVbtn);
            this.Controls.Add(this.vpnAdptrBtn2);
            this.Controls.Add(this.serverlabel);
            this.Controls.Add(this.createswButton);
            this.Controls.Add(this.logoffButton);
            this.Controls.Add(this.createvmButton);
            this.Controls.Add(this.restartButton);
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
            this.ResumeLayout(false);
            this.PerformLayout();

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
        //private System.Windows.Forms.Label label3;
    }
}

