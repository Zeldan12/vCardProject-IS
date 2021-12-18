
namespace vCardAdministratorConsole
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageAdmin = new System.Windows.Forms.TabPage();
            this.comboBoxUserBank = new System.Windows.Forms.ComboBox();
            this.buttonActive = new System.Windows.Forms.Button();
            this.labelActive = new System.Windows.Forms.Label();
            this.comboBoxUserType = new System.Windows.Forms.ComboBox();
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxNameUser = new System.Windows.Forms.TextBox();
            this.textBoxUserBankId = new System.Windows.Forms.TextBox();
            this.textBoxUserId = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.tabPageTransactions = new System.Windows.Forms.TabPage();
            this.tabPageBanks = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonCheckConn = new System.Windows.Forms.Button();
            this.labelCheckConn = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxEarnings = new System.Windows.Forms.TextBox();
            this.textBoxBankName = new System.Windows.Forms.TextBox();
            this.textBoxBankId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxBanks = new System.Windows.Forms.ListBox();
            this.tabPageLogs = new System.Windows.Forms.TabPage();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.buttonUpdateCode = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.textBoxCurrentPass = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.textBoxNewCode = new System.Windows.Forms.TextBox();
            this.textBoxNewPass = new System.Windows.Forms.TextBox();
            this.buttonUpdatePass = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.textBoxSetingsNumber = new System.Windows.Forms.TextBox();
            this.textBoxSetingsEmail = new System.Windows.Forms.TextBox();
            this.textBoxSettingsName = new System.Windows.Forms.TextBox();
            this.textBoxSettingsId = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPageAdmin.SuspendLayout();
            this.tabPageBanks.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageAdmin);
            this.tabControl.Controls.Add(this.tabPageTransactions);
            this.tabControl.Controls.Add(this.tabPageBanks);
            this.tabControl.Controls.Add(this.tabPageLogs);
            this.tabControl.Controls.Add(this.tabPageSettings);
            this.tabControl.Location = new System.Drawing.Point(30, 93);
            this.tabControl.Name = "tabControl";
            this.tabControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1052, 497);
            this.tabControl.TabIndex = 0;
            this.tabControl.TabStop = false;
            this.tabControl.Visible = false;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPageAdmin
            // 
            this.tabPageAdmin.BackColor = System.Drawing.Color.Transparent;
            this.tabPageAdmin.Controls.Add(this.comboBoxUserBank);
            this.tabPageAdmin.Controls.Add(this.buttonActive);
            this.tabPageAdmin.Controls.Add(this.labelActive);
            this.tabPageAdmin.Controls.Add(this.comboBoxUserType);
            this.tabPageAdmin.Controls.Add(this.textBoxPhoneNumber);
            this.tabPageAdmin.Controls.Add(this.textBoxEmail);
            this.tabPageAdmin.Controls.Add(this.textBoxNameUser);
            this.tabPageAdmin.Controls.Add(this.textBoxUserBankId);
            this.tabPageAdmin.Controls.Add(this.textBoxUserId);
            this.tabPageAdmin.Controls.Add(this.label13);
            this.tabPageAdmin.Controls.Add(this.label12);
            this.tabPageAdmin.Controls.Add(this.label11);
            this.tabPageAdmin.Controls.Add(this.label10);
            this.tabPageAdmin.Controls.Add(this.label9);
            this.tabPageAdmin.Controls.Add(this.label8);
            this.tabPageAdmin.Controls.Add(this.label6);
            this.tabPageAdmin.Controls.Add(this.listBoxUsers);
            this.tabPageAdmin.Location = new System.Drawing.Point(4, 25);
            this.tabPageAdmin.Name = "tabPageAdmin";
            this.tabPageAdmin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdmin.Size = new System.Drawing.Size(1044, 468);
            this.tabPageAdmin.TabIndex = 0;
            this.tabPageAdmin.Text = "Administrators";
            // 
            // comboBoxUserBank
            // 
            this.comboBoxUserBank.BackColor = System.Drawing.SystemColors.Control;
            this.comboBoxUserBank.Enabled = false;
            this.comboBoxUserBank.FormattingEnabled = true;
            this.comboBoxUserBank.Location = new System.Drawing.Point(269, 304);
            this.comboBoxUserBank.Name = "comboBoxUserBank";
            this.comboBoxUserBank.Size = new System.Drawing.Size(122, 24);
            this.comboBoxUserBank.TabIndex = 18;
            // 
            // buttonActive
            // 
            this.buttonActive.Location = new System.Drawing.Point(415, 75);
            this.buttonActive.Name = "buttonActive";
            this.buttonActive.Size = new System.Drawing.Size(131, 45);
            this.buttonActive.TabIndex = 17;
            this.buttonActive.Text = "Activate/Deactive";
            this.buttonActive.UseVisualStyleBackColor = true;
            this.buttonActive.Click += new System.EventHandler(this.buttonActive_Click);
            // 
            // labelActive
            // 
            this.labelActive.AutoSize = true;
            this.labelActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActive.Location = new System.Drawing.Point(444, 137);
            this.labelActive.Name = "labelActive";
            this.labelActive.Size = new System.Drawing.Size(66, 25);
            this.labelActive.TabIndex = 16;
            this.labelActive.Text = "Active";
            this.labelActive.Visible = false;
            // 
            // comboBoxUserType
            // 
            this.comboBoxUserType.FormattingEnabled = true;
            this.comboBoxUserType.Items.AddRange(new object[] {
            "User",
            "Admin"});
            this.comboBoxUserType.Location = new System.Drawing.Point(415, 32);
            this.comboBoxUserType.Name = "comboBoxUserType";
            this.comboBoxUserType.Size = new System.Drawing.Size(131, 24);
            this.comboBoxUserType.TabIndex = 15;
            // 
            // textBoxPhoneNumber
            // 
            this.textBoxPhoneNumber.Location = new System.Drawing.Point(269, 250);
            this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            this.textBoxPhoneNumber.ReadOnly = true;
            this.textBoxPhoneNumber.Size = new System.Drawing.Size(122, 22);
            this.textBoxPhoneNumber.TabIndex = 13;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(269, 195);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.ReadOnly = true;
            this.textBoxEmail.Size = new System.Drawing.Size(122, 22);
            this.textBoxEmail.TabIndex = 12;
            // 
            // textBoxNameUser
            // 
            this.textBoxNameUser.Location = new System.Drawing.Point(269, 141);
            this.textBoxNameUser.Name = "textBoxNameUser";
            this.textBoxNameUser.ReadOnly = true;
            this.textBoxNameUser.Size = new System.Drawing.Size(122, 22);
            this.textBoxNameUser.TabIndex = 10;
            // 
            // textBoxUserBankId
            // 
            this.textBoxUserBankId.Location = new System.Drawing.Point(269, 86);
            this.textBoxUserBankId.Name = "textBoxUserBankId";
            this.textBoxUserBankId.ReadOnly = true;
            this.textBoxUserBankId.Size = new System.Drawing.Size(122, 22);
            this.textBoxUserBankId.TabIndex = 9;
            // 
            // textBoxUserId
            // 
            this.textBoxUserId.Location = new System.Drawing.Point(269, 32);
            this.textBoxUserId.Name = "textBoxUserId";
            this.textBoxUserId.ReadOnly = true;
            this.textBoxUserId.Size = new System.Drawing.Size(122, 22);
            this.textBoxUserId.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(266, 284);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 17);
            this.label13.TabIndex = 7;
            this.label13.Text = "Bank";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(412, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 17);
            this.label12.TabIndex = 6;
            this.label12.Text = "Type";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(266, 175);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 17);
            this.label11.TabIndex = 5;
            this.label11.Text = "Email";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(266, 230);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 17);
            this.label10.TabIndex = 4;
            this.label10.Text = "Phone Number";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(266, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 17);
            this.label9.TabIndex = 3;
            this.label9.Text = "Bank Id";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(266, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(266, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Id";
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.ItemHeight = 16;
            this.listBoxUsers.Location = new System.Drawing.Point(11, 12);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(247, 436);
            this.listBoxUsers.TabIndex = 0;
            this.listBoxUsers.SelectedValueChanged += new System.EventHandler(this.listBoxUsers_SelectedValueChanged);
            // 
            // tabPageTransactions
            // 
            this.tabPageTransactions.Location = new System.Drawing.Point(4, 25);
            this.tabPageTransactions.Name = "tabPageTransactions";
            this.tabPageTransactions.Size = new System.Drawing.Size(1044, 468);
            this.tabPageTransactions.TabIndex = 3;
            this.tabPageTransactions.Text = "Transactions";
            this.tabPageTransactions.UseVisualStyleBackColor = true;
            // 
            // tabPageBanks
            // 
            this.tabPageBanks.BackColor = System.Drawing.Color.Transparent;
            this.tabPageBanks.Controls.Add(this.groupBox2);
            this.tabPageBanks.Controls.Add(this.groupBox1);
            this.tabPageBanks.Controls.Add(this.listBoxBanks);
            this.tabPageBanks.Location = new System.Drawing.Point(4, 25);
            this.tabPageBanks.Name = "tabPageBanks";
            this.tabPageBanks.Size = new System.Drawing.Size(1044, 468);
            this.tabPageBanks.TabIndex = 2;
            this.tabPageBanks.Text = "Banks";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonCheckConn);
            this.groupBox2.Controls.Add(this.labelCheckConn);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxURL);
            this.groupBox2.Location = new System.Drawing.Point(563, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(478, 183);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // buttonCheckConn
            // 
            this.buttonCheckConn.Location = new System.Drawing.Point(19, 101);
            this.buttonCheckConn.Name = "buttonCheckConn";
            this.buttonCheckConn.Size = new System.Drawing.Size(145, 45);
            this.buttonCheckConn.TabIndex = 16;
            this.buttonCheckConn.Text = "Check Connection";
            this.buttonCheckConn.UseVisualStyleBackColor = true;
            this.buttonCheckConn.Click += new System.EventHandler(this.buttonCheckConn_Click);
            // 
            // labelCheckConn
            // 
            this.labelCheckConn.AutoSize = true;
            this.labelCheckConn.ForeColor = System.Drawing.Color.Goldenrod;
            this.labelCheckConn.Location = new System.Drawing.Point(324, 65);
            this.labelCheckConn.Name = "labelCheckConn";
            this.labelCheckConn.Size = new System.Drawing.Size(70, 17);
            this.labelCheckConn.TabIndex = 2;
            this.labelCheckConn.Text = "Unkown...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Base URL";
            // 
            // textBoxURL
            // 
            this.textBoxURL.Location = new System.Drawing.Point(19, 62);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(299, 22);
            this.textBoxURL.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxEarnings);
            this.groupBox1.Controls.Add(this.textBoxBankName);
            this.groupBox1.Controls.Add(this.textBoxBankId);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(333, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 312);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attributes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Earnings Percentage";
            // 
            // textBoxEarnings
            // 
            this.textBoxEarnings.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxEarnings.Location = new System.Drawing.Point(41, 186);
            this.textBoxEarnings.Name = "textBoxEarnings";
            this.textBoxEarnings.Size = new System.Drawing.Size(100, 22);
            this.textBoxEarnings.TabIndex = 10;
            // 
            // textBoxBankName
            // 
            this.textBoxBankName.Location = new System.Drawing.Point(41, 124);
            this.textBoxBankName.Name = "textBoxBankName";
            this.textBoxBankName.Size = new System.Drawing.Size(100, 22);
            this.textBoxBankName.TabIndex = 6;
            // 
            // textBoxBankId
            // 
            this.textBoxBankId.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxBankId.Location = new System.Drawing.Point(41, 62);
            this.textBoxBankId.Name = "textBoxBankId";
            this.textBoxBankId.ReadOnly = true;
            this.textBoxBankId.Size = new System.Drawing.Size(100, 22);
            this.textBoxBankId.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Id";
            // 
            // listBoxBanks
            // 
            this.listBoxBanks.FormattingEnabled = true;
            this.listBoxBanks.ItemHeight = 16;
            this.listBoxBanks.Location = new System.Drawing.Point(24, 30);
            this.listBoxBanks.Name = "listBoxBanks";
            this.listBoxBanks.Size = new System.Drawing.Size(277, 404);
            this.listBoxBanks.TabIndex = 1;
            this.listBoxBanks.SelectedValueChanged += new System.EventHandler(this.listBoxBanks_SelectedValueChanged);
            // 
            // tabPageLogs
            // 
            this.tabPageLogs.Location = new System.Drawing.Point(4, 25);
            this.tabPageLogs.Name = "tabPageLogs";
            this.tabPageLogs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPageLogs.Size = new System.Drawing.Size(1044, 468);
            this.tabPageLogs.TabIndex = 5;
            this.tabPageLogs.Text = "System Logs";
            this.tabPageLogs.UseVisualStyleBackColor = true;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.BackColor = System.Drawing.Color.Transparent;
            this.tabPageSettings.Controls.Add(this.buttonUpdateCode);
            this.tabPageSettings.Controls.Add(this.label25);
            this.tabPageSettings.Controls.Add(this.textBoxCurrentPass);
            this.tabPageSettings.Controls.Add(this.label24);
            this.tabPageSettings.Controls.Add(this.label23);
            this.tabPageSettings.Controls.Add(this.textBoxNewCode);
            this.tabPageSettings.Controls.Add(this.textBoxNewPass);
            this.tabPageSettings.Controls.Add(this.buttonUpdatePass);
            this.tabPageSettings.Controls.Add(this.label22);
            this.tabPageSettings.Controls.Add(this.textBoxSetingsNumber);
            this.tabPageSettings.Controls.Add(this.textBoxSetingsEmail);
            this.tabPageSettings.Controls.Add(this.textBoxSettingsName);
            this.tabPageSettings.Controls.Add(this.textBoxSettingsId);
            this.tabPageSettings.Controls.Add(this.label17);
            this.tabPageSettings.Controls.Add(this.label18);
            this.tabPageSettings.Controls.Add(this.label20);
            this.tabPageSettings.Controls.Add(this.label21);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 25);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPageSettings.Size = new System.Drawing.Size(1044, 468);
            this.tabPageSettings.TabIndex = 4;
            this.tabPageSettings.Text = "Profile";
            // 
            // buttonUpdateCode
            // 
            this.buttonUpdateCode.Location = new System.Drawing.Point(501, 162);
            this.buttonUpdateCode.Name = "buttonUpdateCode";
            this.buttonUpdateCode.Size = new System.Drawing.Size(160, 42);
            this.buttonUpdateCode.TabIndex = 35;
            this.buttonUpdateCode.Text = "Update Confirmation Code";
            this.buttonUpdateCode.UseVisualStyleBackColor = true;
            this.buttonUpdateCode.Click += new System.EventHandler(this.buttonUpdateCode_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(306, 175);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(120, 17);
            this.label25.TabIndex = 38;
            this.label25.Text = "Current Password";
            // 
            // textBoxCurrentPass
            // 
            this.textBoxCurrentPass.Location = new System.Drawing.Point(309, 195);
            this.textBoxCurrentPass.Name = "textBoxCurrentPass";
            this.textBoxCurrentPass.Size = new System.Drawing.Size(152, 22);
            this.textBoxCurrentPass.TabIndex = 33;
            this.textBoxCurrentPass.UseSystemPasswordChar = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(306, 120);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(155, 17);
            this.label24.TabIndex = 36;
            this.label24.Text = "New Confirmation Code";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(306, 66);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(100, 17);
            this.label23.TabIndex = 35;
            this.label23.Text = "New Password";
            // 
            // textBoxNewCode
            // 
            this.textBoxNewCode.Location = new System.Drawing.Point(309, 140);
            this.textBoxNewCode.Name = "textBoxNewCode";
            this.textBoxNewCode.Size = new System.Drawing.Size(152, 22);
            this.textBoxNewCode.TabIndex = 32;
            this.textBoxNewCode.UseSystemPasswordChar = true;
            // 
            // textBoxNewPass
            // 
            this.textBoxNewPass.Location = new System.Drawing.Point(309, 86);
            this.textBoxNewPass.Name = "textBoxNewPass";
            this.textBoxNewPass.Size = new System.Drawing.Size(152, 22);
            this.textBoxNewPass.TabIndex = 31;
            this.textBoxNewPass.UseSystemPasswordChar = true;
            // 
            // buttonUpdatePass
            // 
            this.buttonUpdatePass.Location = new System.Drawing.Point(501, 95);
            this.buttonUpdatePass.Name = "buttonUpdatePass";
            this.buttonUpdatePass.Size = new System.Drawing.Size(160, 42);
            this.buttonUpdatePass.TabIndex = 34;
            this.buttonUpdatePass.Text = "Update Password";
            this.buttonUpdatePass.UseVisualStyleBackColor = true;
            this.buttonUpdatePass.Click += new System.EventHandler(this.buttonUpdatePass_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(23, 17);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(105, 29);
            this.label22.TabIndex = 31;
            this.label22.Text = "Account";
            // 
            // textBoxSetingsNumber
            // 
            this.textBoxSetingsNumber.Location = new System.Drawing.Point(28, 249);
            this.textBoxSetingsNumber.Name = "textBoxSetingsNumber";
            this.textBoxSetingsNumber.ReadOnly = true;
            this.textBoxSetingsNumber.Size = new System.Drawing.Size(122, 22);
            this.textBoxSetingsNumber.TabIndex = 29;
            // 
            // textBoxSetingsEmail
            // 
            this.textBoxSetingsEmail.Location = new System.Drawing.Point(28, 194);
            this.textBoxSetingsEmail.Name = "textBoxSetingsEmail";
            this.textBoxSetingsEmail.Size = new System.Drawing.Size(122, 22);
            this.textBoxSetingsEmail.TabIndex = 28;
            // 
            // textBoxSettingsName
            // 
            this.textBoxSettingsName.Location = new System.Drawing.Point(28, 140);
            this.textBoxSettingsName.Name = "textBoxSettingsName";
            this.textBoxSettingsName.Size = new System.Drawing.Size(122, 22);
            this.textBoxSettingsName.TabIndex = 27;
            // 
            // textBoxSettingsId
            // 
            this.textBoxSettingsId.Location = new System.Drawing.Point(28, 86);
            this.textBoxSettingsId.Name = "textBoxSettingsId";
            this.textBoxSettingsId.ReadOnly = true;
            this.textBoxSettingsId.Size = new System.Drawing.Size(122, 22);
            this.textBoxSettingsId.TabIndex = 25;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(25, 174);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 17);
            this.label17.TabIndex = 23;
            this.label17.Text = "Email";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(25, 229);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(103, 17);
            this.label18.TabIndex = 22;
            this.label18.Text = "Phone Number";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(25, 120);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(45, 17);
            this.label20.TabIndex = 20;
            this.label20.Text = "Name";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(25, 66);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(19, 17);
            this.label21.TabIndex = 19;
            this.label21.Text = "Id";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Enabled = false;
            this.buttonRefresh.Location = new System.Drawing.Point(124, 596);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 36);
            this.buttonRefresh.TabIndex = 0;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Enabled = false;
            this.buttonUpdate.Location = new System.Drawing.Point(30, 596);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(88, 36);
            this.buttonUpdate.TabIndex = 14;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(405, 37);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(196, 22);
            this.textBoxPassword.TabIndex = 2;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(110, 36);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(192, 22);
            this.textBoxUsername.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(55, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 18);
            this.label14.TabIndex = 18;
            this.label14.Text = "Email:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(320, 38);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 18);
            this.label15.TabIndex = 19;
            this.label15.Text = "Password:";
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(607, 32);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(109, 35);
            this.buttonLogin.TabIndex = 3;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Enabled = false;
            this.buttonLogout.Location = new System.Drawing.Point(722, 32);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(109, 35);
            this.buttonLogout.TabIndex = 21;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 658);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.buttonRefresh);
            this.Name = "Form1";
            this.Text = "Administration Console";
            this.tabControl.ResumeLayout(false);
            this.tabPageAdmin.ResumeLayout(false);
            this.tabPageAdmin.PerformLayout();
            this.tabPageBanks.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageAdmin;
        private System.Windows.Forms.TabPage tabPageTransactions;
        private System.Windows.Forms.TabPage tabPageBanks;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxEarnings;
        private System.Windows.Forms.TextBox textBoxBankName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxBanks;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonCheckConn;
        private System.Windows.Forms.Label labelCheckConn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.TabPage tabPageLogs;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.Button buttonActive;
        private System.Windows.Forms.Label labelActive;
        private System.Windows.Forms.ComboBox comboBoxUserType;
        private System.Windows.Forms.TextBox textBoxPhoneNumber;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxNameUser;
        private System.Windows.Forms.TextBox textBoxUserBankId;
        private System.Windows.Forms.TextBox textBoxUserId;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxBankId;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.ComboBox comboBoxUserBank;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBoxSetingsNumber;
        private System.Windows.Forms.TextBox textBoxSetingsEmail;
        private System.Windows.Forms.TextBox textBoxSettingsName;
        private System.Windows.Forms.TextBox textBoxSettingsId;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox textBoxCurrentPass;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox textBoxNewCode;
        private System.Windows.Forms.TextBox textBoxNewPass;
        private System.Windows.Forms.Button buttonUpdatePass;
        private System.Windows.Forms.Button buttonUpdateCode;
    }
}

