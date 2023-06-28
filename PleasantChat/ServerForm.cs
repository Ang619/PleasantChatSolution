using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Shared;
using System.Drawing.Text;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace PleasantChat
{
    public partial class ServerForm : Form
    {

        private ChatServer _serverInstance;
        private int selectedItem;
        public ServerForm()
        {
            InitializeComponent();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            _serverInstance = new ChatServer(this);
            _serverInstance.StartServer();

            if (Utilities.GetLocalIPAddress() != null)
            {
                IpTextbox.Text = Utilities.GetLocalIPAddress().ToString();
            }

        }

        private void CmdRunServer_Click(object sender, EventArgs e)
        {
            _serverInstance.StartServer();
        }

        //Send to all
        private void CmdSend_Click(object sender, EventArgs e)
        {
            _serverInstance.Send(false);
        }
        //Send to one
        private void CmdSendToSelected_Click(object sender, EventArgs e)
        {
            _serverInstance.Send(true);

        }


        private void cmdStopServer_Click(object sender, EventArgs e)
        {
            _serverInstance.StopServer();
        }

        private void MessageTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                CmdSend_Click(sender, e);
                e.Handled = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            cmdStopServer_Click(sender, e);
            this.Close();
        }


        //This Code is to be able to move the window by holding the element you wish
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void SelectUserCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItem = SelectUserCombobox.SelectedIndex;
        }
    }
}





