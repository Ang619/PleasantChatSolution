namespace PleasantChat
{
    partial class ClientForm
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
            DragTextbox = new TextBox();
            ConnectionStatusLabel = new Label();
            NotificationTextbox = new TextBox();
            BasicChatLabel = new Label();
            label2 = new Label();
            cmdExit = new Label();
            cmdDisconnect = new Button();
            MessageTextbox = new TextBox();
            CmdSend = new Button();
            ChatListbox = new ListBox();
            CmdConnectt = new Button();
            IpTextbox = new TextBox();
            NameTextbox = new TextBox();
            NameLabel = new Label();
            SelectUserCombobox = new ComboBox();
            CmdSendToOne = new Button();
            OwnUserLabel = new Label();
            YouAreLabel = new Label();
            UsersOnlineListbox = new ListBox();
            UserOnlineListboxLabel = new Label();
            OwnName_Label = new Label();
            SuspendLayout();
            // 
            // DragTextbox
            // 
            DragTextbox.BackColor = SystemColors.ControlDarkDark;
            DragTextbox.BorderStyle = BorderStyle.None;
            DragTextbox.Location = new Point(0, 6);
            DragTextbox.Name = "DragTextbox";
            DragTextbox.ReadOnly = true;
            DragTextbox.Size = new Size(880, 20);
            DragTextbox.TabIndex = 40;
            DragTextbox.MouseDown += DragTextbox_MouseDown;
            // 
            // ConnectionStatusLabel
            // 
            ConnectionStatusLabel.AutoSize = true;
            ConnectionStatusLabel.BackColor = Color.Red;
            ConnectionStatusLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            ConnectionStatusLabel.ForeColor = Color.WhiteSmoke;
            ConnectionStatusLabel.Location = new Point(10, 119);
            ConnectionStatusLabel.Name = "ConnectionStatusLabel";
            ConnectionStatusLabel.Size = new Size(146, 23);
            ConnectionStatusLabel.TabIndex = 39;
            ConnectionStatusLabel.Text = "Keine Verbindung";
            // 
            // NotificationTextbox
            // 
            NotificationTextbox.BackColor = Color.WhiteSmoke;
            NotificationTextbox.BorderStyle = BorderStyle.None;
            NotificationTextbox.Enabled = false;
            NotificationTextbox.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            NotificationTextbox.Location = new Point(10, 159);
            NotificationTextbox.Name = "NotificationTextbox";
            NotificationTextbox.ReadOnly = true;
            NotificationTextbox.Size = new Size(601, 20);
            NotificationTextbox.TabIndex = 38;
            // 
            // BasicChatLabel
            // 
            BasicChatLabel.AutoSize = true;
            BasicChatLabel.BackColor = SystemColors.ControlDarkDark;
            BasicChatLabel.Font = new Font("Lucida Sans Unicode", 24F, FontStyle.Regular, GraphicsUnit.Point);
            BasicChatLabel.ForeColor = Color.WhiteSmoke;
            BasicChatLabel.Location = new Point(0, 24);
            BasicChatLabel.Name = "BasicChatLabel";
            BasicChatLabel.Size = new Size(334, 48);
            BasicChatLabel.TabIndex = 37;
            BasicChatLabel.Text = "BasicChat Client";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ControlDarkDark;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(664, 57);
            label2.Name = "label2";
            label2.Size = new Size(35, 28);
            label2.TabIndex = 35;
            label2.Text = "IP:";
            // 
            // cmdExit
            // 
            cmdExit.AutoSize = true;
            cmdExit.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point);
            cmdExit.ForeColor = Color.WhiteSmoke;
            cmdExit.Location = new Point(883, -18);
            cmdExit.Name = "cmdExit";
            cmdExit.Size = new Size(39, 50);
            cmdExit.TabIndex = 34;
            cmdExit.Text = "x";
            cmdExit.Click += cmdExit_Click;
            // 
            // cmdDisconnect
            // 
            cmdDisconnect.Enabled = false;
            cmdDisconnect.Location = new Point(793, 131);
            cmdDisconnect.Name = "cmdDisconnect";
            cmdDisconnect.Size = new Size(94, 29);
            cmdDisconnect.TabIndex = 33;
            cmdDisconnect.Text = "Trennen";
            cmdDisconnect.UseVisualStyleBackColor = true;
            cmdDisconnect.Click += cmdDisconnect_Click;
            // 
            // MessageTextbox
            // 
            MessageTextbox.Enabled = false;
            MessageTextbox.Location = new Point(10, 485);
            MessageTextbox.Name = "MessageTextbox";
            MessageTextbox.PlaceholderText = "Enter...";
            MessageTextbox.Size = new Size(674, 27);
            MessageTextbox.TabIndex = 32;
            MessageTextbox.KeyPress += MessageTextbox_KeyPress;
            // 
            // CmdSend
            // 
            CmdSend.Enabled = false;
            CmdSend.Location = new Point(690, 483);
            CmdSend.Name = "CmdSend";
            CmdSend.Size = new Size(98, 29);
            CmdSend.TabIndex = 31;
            CmdSend.Text = "An alle Senden";
            CmdSend.UseVisualStyleBackColor = true;
            CmdSend.Click += CmdSend_Click;
            // 
            // ChatListbox
            // 
            ChatListbox.BackColor = SystemColors.Window;
            ChatListbox.FormattingEnabled = true;
            ChatListbox.ItemHeight = 20;
            ChatListbox.Location = new Point(10, 185);
            ChatListbox.Name = "ChatListbox";
            ChatListbox.Size = new Size(778, 284);
            ChatListbox.TabIndex = 30;
            // 
            // CmdConnectt
            // 
            CmdConnectt.BackColor = Color.Gainsboro;
            CmdConnectt.Location = new Point(793, 96);
            CmdConnectt.Name = "CmdConnectt";
            CmdConnectt.Size = new Size(94, 29);
            CmdConnectt.TabIndex = 29;
            CmdConnectt.Text = "Verbinden";
            CmdConnectt.UseVisualStyleBackColor = false;
            CmdConnectt.Click += CmdConnectt_Click;
            // 
            // IpTextbox
            // 
            IpTextbox.Location = new Point(743, 63);
            IpTextbox.Name = "IpTextbox";
            IpTextbox.PlaceholderText = "z.B. 192.168.2.1";
            IpTextbox.Size = new Size(144, 27);
            IpTextbox.TabIndex = 27;
            IpTextbox.KeyPress += IpTextbox_KeyPress;
            // 
            // NameTextbox
            // 
            NameTextbox.Location = new Point(743, 29);
            NameTextbox.Name = "NameTextbox";
            NameTextbox.PlaceholderText = "z.B. Felix";
            NameTextbox.Size = new Size(144, 27);
            NameTextbox.TabIndex = 41;
            NameTextbox.KeyPress += NameTextbox_KeyPress;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            NameLabel.ForeColor = Color.WhiteSmoke;
            NameLabel.Location = new Point(591, 30);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(108, 28);
            NameLabel.TabIndex = 42;
            NameLabel.Text = "Nickname:";
            // 
            // SelectUserCombobox
            // 
            SelectUserCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            SelectUserCombobox.FormattingEnabled = true;
            SelectUserCombobox.Location = new Point(794, 441);
            SelectUserCombobox.Name = "SelectUserCombobox";
            SelectUserCombobox.Size = new Size(93, 28);
            SelectUserCombobox.TabIndex = 45;
            SelectUserCombobox.SelectedIndexChanged += SelectUserCombobox_SelectedIndexChanged;
            // 
            // CmdSendToOne
            // 
            CmdSendToOne.Enabled = false;
            CmdSendToOne.Location = new Point(794, 483);
            CmdSendToOne.Name = "CmdSendToOne";
            CmdSendToOne.Size = new Size(93, 29);
            CmdSendToOne.TabIndex = 46;
            CmdSendToOne.Text = "Flüstern";
            CmdSendToOne.UseVisualStyleBackColor = true;
            CmdSendToOne.Click += CmdSendToOne_Click;
            // 
            // OwnUserLabel
            // 
            OwnUserLabel.AutoSize = true;
            OwnUserLabel.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            OwnUserLabel.ForeColor = Color.WhiteSmoke;
            OwnUserLabel.Location = new Point(120, 72);
            OwnUserLabel.Name = "OwnUserLabel";
            OwnUserLabel.Size = new Size(0, 25);
            OwnUserLabel.TabIndex = 47;
            // 
            // YouAreLabel
            // 
            YouAreLabel.AutoSize = true;
            YouAreLabel.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            YouAreLabel.ForeColor = Color.WhiteSmoke;
            YouAreLabel.Location = new Point(8, 74);
            YouAreLabel.Name = "YouAreLabel";
            YouAreLabel.Size = new Size(106, 25);
            YouAreLabel.TabIndex = 48;
            YouAreLabel.Text = "Im Chat als:";
            YouAreLabel.Visible = false;
            // 
            // UsersOnlineListbox
            // 
            UsersOnlineListbox.DrawMode = DrawMode.OwnerDrawFixed;
            UsersOnlineListbox.FormattingEnabled = true;
            UsersOnlineListbox.ItemHeight = 20;
            UsersOnlineListbox.Location = new Point(794, 185);
            UsersOnlineListbox.Name = "UsersOnlineListbox";
            UsersOnlineListbox.Size = new Size(93, 244);
            UsersOnlineListbox.TabIndex = 49;
            UsersOnlineListbox.DrawItem += UsersOnlineListbox_DrawItem;
            // 
            // UserOnlineListboxLabel
            // 
            UserOnlineListboxLabel.AutoSize = true;
            UserOnlineListboxLabel.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            UserOnlineListboxLabel.ForeColor = Color.WhiteSmoke;
            UserOnlineListboxLabel.Location = new Point(767, 157);
            UserOnlineListboxLabel.Name = "UserOnlineListboxLabel";
            UserOnlineListboxLabel.Size = new Size(120, 25);
            UserOnlineListboxLabel.TabIndex = 50;
            UserOnlineListboxLabel.Text = "Users online:";
            // 
            // OwnName_Label
            // 
            OwnName_Label.AutoSize = true;
            OwnName_Label.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            OwnName_Label.ForeColor = Color.WhiteSmoke;
            OwnName_Label.Location = new Point(117, 74);
            OwnName_Label.Name = "OwnName_Label";
            OwnName_Label.Size = new Size(53, 23);
            OwnName_Label.TabIndex = 51;
            OwnName_Label.Text = "name";
            OwnName_Label.Visible = false;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(914, 525);
            Controls.Add(OwnName_Label);
            Controls.Add(UserOnlineListboxLabel);
            Controls.Add(UsersOnlineListbox);
            Controls.Add(YouAreLabel);
            Controls.Add(OwnUserLabel);
            Controls.Add(CmdSendToOne);
            Controls.Add(SelectUserCombobox);
            Controls.Add(NameLabel);
            Controls.Add(NameTextbox);
            Controls.Add(DragTextbox);
            Controls.Add(ConnectionStatusLabel);
            Controls.Add(NotificationTextbox);
            Controls.Add(BasicChatLabel);
            Controls.Add(label2);
            Controls.Add(cmdExit);
            Controls.Add(cmdDisconnect);
            Controls.Add(MessageTextbox);
            Controls.Add(CmdSend);
            Controls.Add(ChatListbox);
            Controls.Add(CmdConnectt);
            Controls.Add(IpTextbox);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ClientForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClientForm";
            Load += ClientForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox DragTextbox;
        private Label BasicChatLabel;
        private Label label2;
        private Label NameLabel;
        public Label ConnectionStatusLabel;
        public TextBox NotificationTextbox;
        public Button cmdDisconnect;
        public TextBox MessageTextbox;
        public Button CmdSend;
        public ListBox ChatListbox;
        public Button CmdConnectt;
        public TextBox IpTextbox;
        public TextBox NameTextbox;
        public Button CmdSendToOne;
        public Label cmdExit;
        public Label OwnUserLabel;
        public Label YouAreLabel;
        private Label UserOnlineListboxLabel;
        internal ComboBox SelectUserCombobox;
        public ListBox UsersOnlineListbox;
        public Label OwnName_Label;
    }
}