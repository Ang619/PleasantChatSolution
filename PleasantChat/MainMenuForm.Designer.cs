namespace PleasantChat
{
    partial class MainMenuForm
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
            cmdExit = new Label();
            BasicChatLabel = new Label();
            CmdJoin = new Button();
            CmdCreate = new Button();
            ChooseLabel = new Label();
            SuspendLayout();
            // 
            // cmdExit
            // 
            cmdExit.AutoSize = true;
            cmdExit.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point);
            cmdExit.ForeColor = Color.WhiteSmoke;
            cmdExit.Location = new Point(550, -5);
            cmdExit.Name = "cmdExit";
            cmdExit.Size = new Size(39, 50);
            cmdExit.TabIndex = 35;
            cmdExit.Text = "x";
            cmdExit.Click += cmdExit_Click;
            // 
            // BasicChatLabel
            // 
            BasicChatLabel.AutoSize = true;
            BasicChatLabel.BackColor = SystemColors.ControlDarkDark;
            BasicChatLabel.Font = new Font("Lucida Sans Unicode", 24F, FontStyle.Regular, GraphicsUnit.Point);
            BasicChatLabel.ForeColor = Color.WhiteSmoke;
            BasicChatLabel.Location = new Point(21, 19);
            BasicChatLabel.Name = "BasicChatLabel";
            BasicChatLabel.Size = new Size(207, 48);
            BasicChatLabel.TabIndex = 37;
            BasicChatLabel.Text = "BasicChat";
            // 
            // CmdJoin
            // 
            CmdJoin.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            CmdJoin.Location = new Point(148, 175);
            CmdJoin.Name = "CmdJoin";
            CmdJoin.Size = new Size(94, 29);
            CmdJoin.TabIndex = 38;
            CmdJoin.Text = "Beitreten";
            CmdJoin.UseVisualStyleBackColor = true;
            CmdJoin.Click += CmdJoin_Click;
            // 
            // CmdCreate
            // 
            CmdCreate.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            CmdCreate.Location = new Point(356, 175);
            CmdCreate.Name = "CmdCreate";
            CmdCreate.Size = new Size(94, 29);
            CmdCreate.TabIndex = 39;
            CmdCreate.Text = "Erstellen";
            CmdCreate.UseVisualStyleBackColor = true;
            CmdCreate.Click += CmdCreate_Click;
            // 
            // ChooseLabel
            // 
            ChooseLabel.AutoSize = true;
            ChooseLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            ChooseLabel.ForeColor = Color.WhiteSmoke;
            ChooseLabel.Location = new Point(8, 114);
            ChooseLabel.Name = "ChooseLabel";
            ChooseLabel.Size = new Size(577, 28);
            ChooseLabel.TabIndex = 41;
            ChooseLabel.Text = "Möchten Sie einem Chatroom beitreten, oder einen erstellen?";
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(596, 232);
            Controls.Add(ChooseLabel);
            Controls.Add(CmdCreate);
            Controls.Add(CmdJoin);
            Controls.Add(BasicChatLabel);
            Controls.Add(cmdExit);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainMenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainMenuForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label cmdExit;
        private Label BasicChatLabel;
        private Button CmdJoin;
        private Button CmdCreate;
        private Label ChooseLabel;
    }
}