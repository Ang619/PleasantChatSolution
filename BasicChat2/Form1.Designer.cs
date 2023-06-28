namespace BasicChat2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBox1 = new TextBox();
            ServerStatusLabel = new Label();
            NotificationTextbox = new TextBox();
            BasicChatLabel = new Label();
            cmdStopServer = new Button();
            MessageTextbox = new TextBox();
            CmdSend = new Button();
            CmdRunServer = new Button();
            ChatListbox = new ListBox();
            PortTexbox = new TextBox();
            IpTextbox = new TextBox();
            PortLabel = new Label();
            IpLabel = new Label();
            MembersComboBox = new ComboBox();
            MembersLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(1083, 17);
            label1.Name = "label1";
            label1.Size = new Size(39, 50);
            label1.TabIndex = 53;
            label1.Text = "x";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ControlDarkDark;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(139, 23);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(938, 20);
            textBox1.TabIndex = 52;
            // 
            // ServerStatusLabel
            // 
            ServerStatusLabel.AutoSize = true;
            ServerStatusLabel.BackColor = Color.Red;
            ServerStatusLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            ServerStatusLabel.ForeColor = Color.WhiteSmoke;
            ServerStatusLabel.Location = new Point(161, 140);
            ServerStatusLabel.Name = "ServerStatusLabel";
            ServerStatusLabel.Size = new Size(132, 23);
            ServerStatusLabel.TabIndex = 51;
            ServerStatusLabel.Text = "Server gestoppt";
            // 
            // NotificationTextbox
            // 
            NotificationTextbox.BackColor = Color.WhiteSmoke;
            NotificationTextbox.BorderStyle = BorderStyle.None;
            NotificationTextbox.Enabled = false;
            NotificationTextbox.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            NotificationTextbox.Location = new Point(161, 175);
            NotificationTextbox.Name = "NotificationTextbox";
            NotificationTextbox.ReadOnly = true;
            NotificationTextbox.Size = new Size(720, 20);
            NotificationTextbox.TabIndex = 50;
            // 
            // BasicChatLabel
            // 
            BasicChatLabel.AutoSize = true;
            BasicChatLabel.BackColor = SystemColors.ControlDarkDark;
            BasicChatLabel.Font = new Font("Lucida Sans Unicode", 24F, FontStyle.Regular, GraphicsUnit.Point);
            BasicChatLabel.ForeColor = Color.WhiteSmoke;
            BasicChatLabel.Location = new Point(161, 50);
            BasicChatLabel.Name = "BasicChatLabel";
            BasicChatLabel.Size = new Size(339, 48);
            BasicChatLabel.TabIndex = 49;
            BasicChatLabel.Text = "BasicChat Server";
            // 
            // cmdStopServer
            // 
            cmdStopServer.Enabled = false;
            cmdStopServer.Location = new Point(936, 173);
            cmdStopServer.Name = "cmdStopServer";
            cmdStopServer.Size = new Size(125, 29);
            cmdStopServer.TabIndex = 48;
            cmdStopServer.Text = "Server Beenden";
            cmdStopServer.UseVisualStyleBackColor = true;
            // 
            // MessageTextbox
            // 
            MessageTextbox.Enabled = false;
            MessageTextbox.Location = new Point(161, 727);
            MessageTextbox.Name = "MessageTextbox";
            MessageTextbox.PlaceholderText = "Enter...";
            MessageTextbox.Size = new Size(817, 27);
            MessageTextbox.TabIndex = 47;
            // 
            // CmdSend
            // 
            CmdSend.Enabled = false;
            CmdSend.Location = new Point(1002, 725);
            CmdSend.Name = "CmdSend";
            CmdSend.Size = new Size(94, 29);
            CmdSend.TabIndex = 46;
            CmdSend.Text = "Senden";
            CmdSend.UseVisualStyleBackColor = true;
            // 
            // CmdRunServer
            // 
            CmdRunServer.Location = new Point(936, 138);
            CmdRunServer.Name = "CmdRunServer";
            CmdRunServer.Size = new Size(125, 29);
            CmdRunServer.TabIndex = 45;
            CmdRunServer.Text = "Server Starten";
            CmdRunServer.UseVisualStyleBackColor = true;
            // 
            // ChatListbox
            // 
            ChatListbox.BackColor = Color.WhiteSmoke;
            ChatListbox.FormattingEnabled = true;
            ChatListbox.ItemHeight = 20;
            ChatListbox.Location = new Point(161, 223);
            ChatListbox.Name = "ChatListbox";
            ChatListbox.Size = new Size(935, 484);
            ChatListbox.TabIndex = 44;
            // 
            // PortTexbox
            // 
            PortTexbox.BackColor = Color.WhiteSmoke;
            PortTexbox.Location = new Point(917, 96);
            PortTexbox.Name = "PortTexbox";
            PortTexbox.ReadOnly = true;
            PortTexbox.Size = new Size(144, 27);
            PortTexbox.TabIndex = 43;
            // 
            // IpTextbox
            // 
            IpTextbox.BackColor = Color.WhiteSmoke;
            IpTextbox.Location = new Point(917, 63);
            IpTextbox.Name = "IpTextbox";
            IpTextbox.ReadOnly = true;
            IpTextbox.Size = new Size(144, 27);
            IpTextbox.TabIndex = 42;
            // 
            // PortLabel
            // 
            PortLabel.AutoSize = true;
            PortLabel.BackColor = SystemColors.ControlDarkDark;
            PortLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            PortLabel.ForeColor = Color.WhiteSmoke;
            PortLabel.Location = new Point(846, 95);
            PortLabel.Name = "PortLabel";
            PortLabel.Size = new Size(55, 28);
            PortLabel.TabIndex = 41;
            PortLabel.Text = "Port:";
            // 
            // IpLabel
            // 
            IpLabel.AutoSize = true;
            IpLabel.BackColor = SystemColors.ControlDarkDark;
            IpLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            IpLabel.ForeColor = Color.WhiteSmoke;
            IpLabel.Location = new Point(846, 63);
            IpLabel.Name = "IpLabel";
            IpLabel.Size = new Size(35, 28);
            IpLabel.TabIndex = 40;
            IpLabel.Text = "IP:";
            // 
            // MembersComboBox
            // 
            MembersComboBox.FormattingEnabled = true;
            MembersComboBox.Location = new Point(583, 135);
            MembersComboBox.Name = "MembersComboBox";
            MembersComboBox.Size = new Size(151, 28);
            MembersComboBox.TabIndex = 54;
            // 
            // MembersLabel
            // 
            MembersLabel.AutoSize = true;
            MembersLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            MembersLabel.ForeColor = Color.WhiteSmoke;
            MembersLabel.Location = new Point(474, 135);
            MembersLabel.Name = "MembersLabel";
            MembersLabel.Size = new Size(103, 28);
            MembersLabel.TabIndex = 55;
            MembersLabel.Text = "Members:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(1261, 771);
            Controls.Add(MembersLabel);
            Controls.Add(MembersComboBox);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(ServerStatusLabel);
            Controls.Add(NotificationTextbox);
            Controls.Add(BasicChatLabel);
            Controls.Add(cmdStopServer);
            Controls.Add(MessageTextbox);
            Controls.Add(CmdSend);
            Controls.Add(CmdRunServer);
            Controls.Add(ChatListbox);
            Controls.Add(PortTexbox);
            Controls.Add(IpTextbox);
            Controls.Add(PortLabel);
            Controls.Add(IpLabel);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label ServerStatusLabel;
        private TextBox NotificationTextbox;
        private Label BasicChatLabel;
        private Button cmdStopServer;
        private TextBox MessageTextbox;
        private Button CmdSend;
        private Button CmdRunServer;
        private ListBox ChatListbox;
        private TextBox PortTexbox;
        private TextBox IpTextbox;
        private Label PortLabel;
        private Label IpLabel;
        private ComboBox MembersComboBox;
        private Label MembersLabel;
    }
}