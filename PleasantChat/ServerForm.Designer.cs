namespace PleasantChat
{
    partial class ServerForm
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
            textBox1 = new TextBox();
            ServerStatusLabel = new Label();
            NotificationTextbox = new TextBox();
            BasicChatLabel = new Label();
            cmdExit = new Label();
            cmdStopServer = new Button();
            MessageTextbox = new TextBox();
            CmdSend = new Button();
            CmdRunServer = new Button();
            ChatListbox = new ListBox();
            IpTextbox = new TextBox();
            IpLabel = new Label();
            Cmd_CloseApplication_Label = new Label();
            SelectUserCombobox = new ComboBox();
            CmdSendToSelected = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ControlDarkDark;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(2, 1);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(938, 20);
            textBox1.TabIndex = 38;
            textBox1.MouseDown += textBox1_MouseDown;
            // 
            // ServerStatusLabel
            // 
            ServerStatusLabel.AutoSize = true;
            ServerStatusLabel.BackColor = Color.Red;
            ServerStatusLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            ServerStatusLabel.ForeColor = Color.WhiteSmoke;
            ServerStatusLabel.Location = new Point(24, 118);
            ServerStatusLabel.Name = "ServerStatusLabel";
            ServerStatusLabel.Size = new Size(132, 23);
            ServerStatusLabel.TabIndex = 37;
            ServerStatusLabel.Text = "Server gestoppt";
            // 
            // NotificationTextbox
            // 
            NotificationTextbox.BackColor = Color.WhiteSmoke;
            NotificationTextbox.BorderStyle = BorderStyle.None;
            NotificationTextbox.Enabled = false;
            NotificationTextbox.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            NotificationTextbox.Location = new Point(24, 153);
            NotificationTextbox.Name = "NotificationTextbox";
            NotificationTextbox.ReadOnly = true;
            NotificationTextbox.Size = new Size(300, 20);
            NotificationTextbox.TabIndex = 36;
            // 
            // BasicChatLabel
            // 
            BasicChatLabel.AutoSize = true;
            BasicChatLabel.BackColor = SystemColors.ControlDarkDark;
            BasicChatLabel.Font = new Font("Lucida Sans Unicode", 24F, FontStyle.Regular, GraphicsUnit.Point);
            BasicChatLabel.ForeColor = Color.WhiteSmoke;
            BasicChatLabel.Location = new Point(24, 28);
            BasicChatLabel.Name = "BasicChatLabel";
            BasicChatLabel.Size = new Size(339, 48);
            BasicChatLabel.TabIndex = 35;
            BasicChatLabel.Text = "BasicChat Server";
            // 
            // cmdExit
            // 
            cmdExit.AutoSize = true;
            cmdExit.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            cmdExit.ForeColor = Color.WhiteSmoke;
            cmdExit.Location = new Point(978, -5);
            cmdExit.Name = "cmdExit";
            cmdExit.Size = new Size(32, 41);
            cmdExit.TabIndex = 34;
            cmdExit.Text = "x";
            // 
            // cmdStopServer
            // 
            cmdStopServer.Enabled = false;
            cmdStopServer.Location = new Point(348, 156);
            cmdStopServer.Name = "cmdStopServer";
            cmdStopServer.Size = new Size(125, 29);
            cmdStopServer.TabIndex = 33;
            cmdStopServer.Text = "Server Beenden";
            cmdStopServer.UseVisualStyleBackColor = true;
            cmdStopServer.Click += cmdStopServer_Click;
            // 
            // MessageTextbox
            // 
            MessageTextbox.Enabled = false;
            MessageTextbox.Location = new Point(12, 588);
            MessageTextbox.Name = "MessageTextbox";
            MessageTextbox.PlaceholderText = "Enter...";
            MessageTextbox.Size = new Size(284, 27);
            MessageTextbox.TabIndex = 32;
            MessageTextbox.KeyPress += MessageTextbox_KeyPress;
            // 
            // CmdSend
            // 
            CmdSend.Enabled = false;
            CmdSend.Location = new Point(145, 551);
            CmdSend.Name = "CmdSend";
            CmdSend.Size = new Size(82, 29);
            CmdSend.TabIndex = 31;
            CmdSend.Text = "An alle Senden";
            CmdSend.UseVisualStyleBackColor = true;
            CmdSend.Click += CmdSend_Click;
            // 
            // CmdRunServer
            // 
            CmdRunServer.Location = new Point(348, 121);
            CmdRunServer.Name = "CmdRunServer";
            CmdRunServer.Size = new Size(125, 29);
            CmdRunServer.TabIndex = 30;
            CmdRunServer.Text = "Server Starten";
            CmdRunServer.UseVisualStyleBackColor = true;
            CmdRunServer.Click += CmdRunServer_Click;
            // 
            // ChatListbox
            // 
            ChatListbox.BackColor = Color.WhiteSmoke;
            ChatListbox.FormattingEnabled = true;
            ChatListbox.ItemHeight = 20;
            ChatListbox.Location = new Point(24, 201);
            ChatListbox.Name = "ChatListbox";
            ChatListbox.Size = new Size(327, 344);
            ChatListbox.TabIndex = 29;
            // 
            // IpTextbox
            // 
            IpTextbox.BackColor = Color.WhiteSmoke;
            IpTextbox.Location = new Point(329, 79);
            IpTextbox.Name = "IpTextbox";
            IpTextbox.ReadOnly = true;
            IpTextbox.Size = new Size(144, 27);
            IpTextbox.TabIndex = 27;
            // 
            // IpLabel
            // 
            IpLabel.AutoSize = true;
            IpLabel.BackColor = SystemColors.ControlDarkDark;
            IpLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            IpLabel.ForeColor = Color.WhiteSmoke;
            IpLabel.Location = new Point(316, 75);
            IpLabel.Name = "IpLabel";
            IpLabel.Size = new Size(35, 28);
            IpLabel.TabIndex = 25;
            IpLabel.Text = "IP:";
            // 
            // Cmd_CloseApplication_Label
            // 
            Cmd_CloseApplication_Label.AutoSize = true;
            Cmd_CloseApplication_Label.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point);
            Cmd_CloseApplication_Label.ForeColor = Color.WhiteSmoke;
            Cmd_CloseApplication_Label.Location = new Point(397, 24);
            Cmd_CloseApplication_Label.Name = "Cmd_CloseApplication_Label";
            Cmd_CloseApplication_Label.Size = new Size(39, 50);
            Cmd_CloseApplication_Label.TabIndex = 39;
            Cmd_CloseApplication_Label.Text = "x";
            Cmd_CloseApplication_Label.Click += label1_Click;
            // 
            // SelectUserCombobox
            // 
            SelectUserCombobox.FormattingEnabled = true;
            SelectUserCombobox.Location = new Point(243, 637);
            SelectUserCombobox.Name = "SelectUserCombobox";
            SelectUserCombobox.Size = new Size(151, 28);
            SelectUserCombobox.TabIndex = 40;
            SelectUserCombobox.SelectedIndexChanged += SelectUserCombobox_SelectedIndexChanged;
            // 
            // CmdSendToSelected
            // 
            CmdSendToSelected.Location = new Point(243, 553);
            CmdSendToSelected.Name = "CmdSendToSelected";
            CmdSendToSelected.Size = new Size(81, 29);
            CmdSendToSelected.TabIndex = 41;
            CmdSendToSelected.Text = "An jmd Senden";
            CmdSendToSelected.UseVisualStyleBackColor = true;
            CmdSendToSelected.Click += CmdSendToSelected_Click;
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(515, 710);
            Controls.Add(CmdSendToSelected);
            Controls.Add(SelectUserCombobox);
            Controls.Add(Cmd_CloseApplication_Label);
            Controls.Add(textBox1);
            Controls.Add(ServerStatusLabel);
            Controls.Add(NotificationTextbox);
            Controls.Add(BasicChatLabel);
            Controls.Add(cmdExit);
            Controls.Add(cmdStopServer);
            Controls.Add(MessageTextbox);
            Controls.Add(CmdSend);
            Controls.Add(CmdRunServer);
            Controls.Add(ChatListbox);
            Controls.Add(IpTextbox);
            Controls.Add(IpLabel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ServerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ServerForm";
            Load += ServerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label BasicChatLabel;
        private Label cmdExit;
        private Label IpLabel;
        public TextBox NotificationTextbox;
        public Button cmdStopServer;
        public TextBox MessageTextbox;
        public Button CmdSend;
        public Button CmdRunServer;
        public ListBox ChatListbox;
        public TextBox IpTextbox;
        public ComboBox SelectUserCombobox;
        public Button CmdSendToSelected;
        public Label ServerStatusLabel;
        public Label Cmd_CloseApplication_Label;
        public TextBox textBox1;
    }
}