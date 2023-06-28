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
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.Metrics;
using Shared;
using System.Collections;
using Newtonsoft.Json;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.VisualBasic.ApplicationServices;

namespace PleasantChat
{
    public partial class ClientForm : Form
    {
        private ChatClient _clientInstance;
        private int selectedItem;

        public ClientForm()
        {
            InitializeComponent();
        }


        private void ClientForm_Load(object sender, EventArgs e)
        {
            _clientInstance = new ChatClient(this);
        }

        private async void CmdConnectt_Click(object sender, EventArgs e)
        {
            await _clientInstance.EstablishConnection();
        }

        //Send to all
        private void CmdSend_Click(object sender, EventArgs e)
        {
            _clientInstance.SendAsync(false);
        }
        //Send to one
        private async void CmdSendToOne_Click(object sender, EventArgs e)
        {
            _clientInstance.SendAsync(true);
        }

        private void cmdDisconnect_Click(object sender, EventArgs e)
        {
            _clientInstance.Disconnect();
        }
        private void cmdExit_Click(object sender, EventArgs e)
        {

            _clientInstance?.Disconnect();
            this.Close();
        }



        //Pressing enter sends message
        private void MessageTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                CmdSend_Click(sender, e);
                e.Handled = true;
            }
        }
        //Pressing enter connects to server
        private void NameTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                CmdConnectt_Click(sender, e);
            }
        }
        //Pressing enter connects to server
        private void IpTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                CmdConnectt_Click(sender, e);
            }
        }



        //Allow the window to be moved by holding the invisible textbox at the top
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void DragTextbox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        //Keep track of selected item
        private void SelectUserCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItem = SelectUserCombobox.SelectedIndex;
        }
        //Draw green dot for online Users
        private void UsersOnlineListbox_DrawItem(object sender, DrawItemEventArgs e)
        {


            e.DrawBackground(); // Draw the background of the item

            if (e.Index >= 0)
            {
                // Get the text of the item
                string itemText = UsersOnlineListbox.Items[e.Index].ToString();

                // Set the color for the dot (green)
                Color dotColor = Color.Green;

                // Calculate the position of the dot
                int dotSize = 10;
                int dotX = e.Bounds.Left + (e.Bounds.Width - dotSize - 5 - e.Graphics.MeasureString(itemText, e.Font).ToSize().Width) / 2;
                int dotY = e.Bounds.Top + (e.Bounds.Height - dotSize) / 2;

                // Calculate the position of the text
                int textX = dotX + dotSize + 5;
                int textY = e.Bounds.Top + (e.Bounds.Height - e.Font.Height) / 2;

                // Draw the dot on the left side of the item
                e.Graphics.FillEllipse(new SolidBrush(dotColor), dotX, dotY, dotSize, dotSize);

                // Draw the item's text next to the dot
                e.Graphics.DrawString(itemText, e.Font, new SolidBrush(e.ForeColor), textX, textY);
            }

            e.DrawFocusRectangle(); // Draw the focus rectangle if the item is selected
        }
    }


}







