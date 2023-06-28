using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Shared;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Diagnostics.Eventing.Reader;

namespace PleasantChat
{
    internal class ChatClient
    {
        private int _port = 13053;
        IPEndPoint? _clientEndpoint;
        private Socket? _clientSocket;
        private string? _nickname;
        private int _personalId;
        private int _selectedItem;
        private Dictionary<int, string> _usersDictionary = new Dictionary<int, string>();
        private ClientForm _clientForm;

        private string _messageIdentifyer = "~*~*~*~";
        private string _listIdentifyer = "~? ~? ~? ~";
        private string IdIntentifyer = "~# ~# ~# ~";
        private string _nicknameIdentifyer = "~§ ~§ ~§ ~";

        public ChatClient(ClientForm theForm)
        {
            _clientForm = theForm;
            //UI
            _clientForm.SelectUserCombobox.SelectedIndexChanged += SelectUserCombobox_SelectedIndexChanged;
            _clientForm.UsersOnlineListbox.DrawMode = DrawMode.OwnerDrawFixed;
        }

        public async Task EstablishConnection()
        {
            _nickname = GetNicknameFromUserInput();
            string? IP = GetIpFromUserInput();

            if (_nickname == null) { }
            {
                DisplayNotification("Username muss aus 4-16 Zeichen bestehen");
            }
            if (IP == null)
            {
                DisplayNotification("Bitte IPv4 korrekt eingeben");
            }
            if (IP != null && _nickname != null)
            {
                await ConnectAsync(IP);
            }
        }

        public async Task ConnectAsync(string ipadress)
        {
            _clientForm.NotificationTextbox.Clear();

            try
            {
                _clientEndpoint = new IPEndPoint(IPAddress.Parse(ipadress), _port);
                _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //_clientSocket.NoDelay = true;
                await _clientSocket.ConnectAsync(_clientEndpoint!);

                byte[] tempbytes = new byte[1024];

                //Wait for ID from Server
                var receivedData = await _clientSocket.ReceiveAsync(tempbytes);

                string messageString = Encoding.UTF8.GetString(tempbytes, 0, receivedData);

                //Check if receivedData is indeed the ID
                if (messageString.StartsWith(IdIntentifyer))
                {

                    string[] parts = messageString.Split(new string[] { IdIntentifyer }, StringSplitOptions.RemoveEmptyEntries);
                    _personalId = Convert.ToInt32(parts[0]);
                    Console.WriteLine("Client hat ID erhalten:" + _personalId);

                    //Send own Nickname to the Server                    
                    tempbytes = Encoding.UTF8.GetBytes(_nicknameIdentifyer + _nickname!);
                    await _clientSocket.SendAsync(tempbytes);

                    //UI
                    SetStatusToConnected();
                    ConnectButtonLogic();
                    DisplayOwnName();

                    //Connection established now, received messages get handled in Task ReceiveMessages
                    _ = ReceiveMessages();
                }
                else
                {
                    Console.WriteLine("Failed to receive ID");
                    //UI
                    DisplayNotification("Konnte ID nicht beziehen, versuchen Sie es erneut.");
                    SetStatusToDisconnected();
                    HideOwnNameLabel();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //UI
                SetStatusToDisconnected();
                HideOwnNameLabel();
            }
        }

        public async void SendAsync(bool whisper)
        {
            _clientForm.NotificationTextbox.Clear();
            //Counter is for the UI to display messages as intended
            int counter = 0;

            if (MessageIsValid(_clientForm.MessageTextbox.Text))
            {
                foreach (var client in _usersDictionary)
                {
                    //If the message is a whisper message, we skip until we find the selected user
                    if (whisper && client.Key != _usersDictionary.ElementAt(_selectedItem).Key)
                    {
                        continue;
                    }

                    //Dont send to myself
                    if (client.Key != _personalId && _nickname != null)
                    {
                        var messageDataModel = new DataModel(_clientForm.MessageTextbox.Text, _personalId, _nickname, client.Key, client.Value, whisper);
                        //Send the Datamodel
                        await SendDatamodelAsync(messageDataModel);

                        //Display Message only once if send to multiple people
                        if (counter == 0)
                        {
                            DisplayMessage(messageDataModel);
                        }
                        counter++;
                    }
                    else
                    {
                        DisplayNotification("Senden der Nachricht fehlgeschlagen");
                    }
                }
                //UI
                ClearChatbox();
            }
            else
            {
                DisplayNotification("Nachricht darf nicht leer sein, oder mehr als 300 Zeichen haben");
            }
        }

        public async Task SendDatamodelAsync(DataModel datamodel)
        {
            _clientForm.NotificationTextbox.Clear();
            byte[] temp = new byte[1024];

            //Check if receiver exists in the current list
            if (_usersDictionary.ContainsKey(datamodel._receiverID))
            {
                //Prepare json
                string json = JsonSerializer.Serialize(datamodel);
                temp = Encoding.UTF8.GetBytes(_messageIdentifyer + json);

                if (_clientSocket != null)
                {
                    try
                    {
                        //Send
                        await _clientSocket.SendAsync(temp);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        DisplayNotification("Senden fehlgeschlagen");
                    }
                }
            }
            else
            {
                DisplayNotification("Empfänger der Nachricht nicht mehr verfügbar");
            }
        }



        private async Task ReceiveMessages()
        {
            Byte[] bytes = new byte[1024];
            while (true)
            {
                if (_clientSocket != null && _clientSocket.Connected)
                {
                    try
                    {
                        //Receive
                        var amountBytes = await _clientSocket.ReceiveAsync(bytes);

                        //If Server closes, we get a nullbyte
                        if (amountBytes == 0)
                        {
                            //UI
                            SetStatusToDisconnected();
                            HideOwnNameLabel();
                            DisplayNotification("Server wurde geschlossen");

                            break;
                        }

                        string decodedMessage = Encoding.UTF8.GetString(bytes, 0, amountBytes);

                        //If we receive a message
                        if (decodedMessage.StartsWith(_messageIdentifyer))
                        {
                            string message = decodedMessage.Substring(_messageIdentifyer.Length);
                            //Prepare the datamodel
                            DataModel? messageModel = JsonSerializer.Deserialize<DataModel>(message);

                            if (messageModel != null)
                            {
                                DisplayMessage(messageModel);
                            }
                        }

                        //If we receive the userlist
                        if (decodedMessage.StartsWith(_listIdentifyer))
                        {
                            _usersDictionary.Clear();

                            //Convert the long string to an Array
                            string[] tempArray = decodedMessage.Split(new[] { _listIdentifyer }, StringSplitOptions.RemoveEmptyEntries);
                            string username = "";
                            int clientID = 0;
                            //we go through the loop with i +=2, since two following array item represent a single user.
                            for (int i = 0; i < tempArray.Length; i += 2)
                            {
                                clientID = Convert.ToInt32(tempArray[i]);
                                username = tempArray[i + 1];
                                //Dont add myself to the userlist
                                if (clientID != _personalId)
                                {
                                    _usersDictionary.Add(clientID, username);
                                }
                            }
                            //UI
                            DisplayOnlineClients();
                            PopulateListBox();
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine($"Client [{_personalId}]" + ex.Message);
                        //UI
                        DisplayNotification("Verbindung zum Server verloren");
                        HideOwnNameLabel();
                        SetStatusToDisconnected();
                        break;
                    }
                }
            }
        }

        public void DisplayMessage(DataModel model)
        {
            //If is whisper message
            if (model != null && model._isWhisperMessage)
            {
                //If we sended the message
                if (model._senderID == _personalId && model._senderName == _nickname)
                    _clientForm.ChatListbox.Invoke((MethodInvoker)delegate
                    {
                        _clientForm.ChatListbox.Items.Add($"[Du flüsterst an {model._receiverName}({model._receiverID})]: " + model._message);
                    });
                //If Someone else sended
                else
                {
                    _clientForm.ChatListbox.Invoke((MethodInvoker)delegate
                    {
                        _clientForm.ChatListbox.Items.Add($"[{model._senderName}({model._senderID})] flüstert: " + model._message);
                    });

                }
            }
            //If message was to all user
            else if (model != null && !model._isWhisperMessage)
            {
                _clientForm.ChatListbox.Invoke((MethodInvoker)delegate
                {
                    _clientForm.ChatListbox.Items.Add($"[{model._senderName}]({model._senderID}): " + model._message);
                });
            }
        }



        public string? GetIpFromUserInput()
        {
            string userinput = _clientForm.IpTextbox.Text;
            bool validIP = (IPAddress.TryParse(userinput, out IPAddress? ipAddress) && ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);

            if (validIP)
            {
                return userinput;
            }
            else
            {
                return null;
            }
        }

        public void DisplayOnlineClients()
        {
            _clientForm.SelectUserCombobox.Invoke((MethodInvoker)delegate
            {
                _clientForm.SelectUserCombobox.DataSource = new BindingSource(_usersDictionary, null);
            });
        }

        public void EmptyListbox()
        {
            _clientForm.ChatListbox.Invoke((MethodInvoker)delegate
            {
                _clientForm.ChatListbox.Items.Clear();
            });
        }





        private bool MessageIsValid(string message)
        {
            if (string.IsNullOrEmpty(message) ||
               message.Length > 300)
            {
                return false;
            }
            return true;
        }

        public string? GetNicknameFromUserInput()
        {
            string userinput = _clientForm.NameTextbox.Text;
            bool validNickname = (userinput.Length >= 4 && userinput.Length <= 16);

            if (validNickname)
            {
                return userinput;
            }
            else
            {
                return null;
            }
        }

        public void ClearChatbox()
        {
            _clientForm.MessageTextbox.Invoke((MethodInvoker)delegate
            {
                _clientForm.MessageTextbox.Clear();
            });
        }

        public void PopulateListBox()
        {
            _clientForm.UsersOnlineListbox.Items.Clear();

            foreach (var client in _usersDictionary)
            {
                _clientForm.UsersOnlineListbox.Items.Add($"{client.Value}({client.Key})"); // Add each value to the ListBox
            }
        }

        private void SetStatusToConnected()
        {
            _clientForm.ConnectionStatusLabel.Invoke((MethodInvoker)delegate
            {
                _clientForm.ConnectionStatusLabel.Text = "Verbunden.";
                _clientForm.ConnectionStatusLabel.BackColor = Color.Green;
            });
        }
        private void SetStatusToDisconnected()
        {
            _clientForm.ConnectionStatusLabel.Invoke((MethodInvoker)delegate
            {
                _clientForm.ConnectionStatusLabel.Text = "Nicht verbunden.";
                _clientForm.ConnectionStatusLabel.BackColor = Color.Red;
            });
        }

        public void Disconnect()
        {
            _clientForm.NotificationTextbox.Clear();

            if (_clientSocket != null)
            {
                try
                {
                    _clientSocket.Shutdown(SocketShutdown.Both);
                    _clientSocket.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    //UI
                    SetStatusToDisconnected();
                    DisconnectButtonLogic();
                    HideOwnNameLabel();
                    ClearChatbox();
                    _clientForm.UsersOnlineListbox.Items.Clear();
                }
            }
        }
        public void ConnectButtonLogic()
        {
            _clientForm.cmdDisconnect.Enabled = true;
            _clientForm.CmdConnectt.Enabled = false;
            _clientForm.MessageTextbox.Enabled = true;
            _clientForm.MessageTextbox.Clear();
            _clientForm.CmdSend.Enabled = true;
            _clientForm.CmdSendToOne.Enabled = true;
        }
        public void DisconnectButtonLogic()
        {
            _clientForm.cmdDisconnect.Enabled = false;
            _clientForm.CmdConnectt.Enabled = true;
            _clientForm.MessageTextbox.Enabled = false;
            _clientForm.MessageTextbox.Clear();
            _clientForm.CmdSend.Enabled = false;
            _clientForm.CmdSendToOne.Enabled = false;
        }


        private void SelectUserCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedItem = _clientForm.SelectUserCombobox.SelectedIndex;
        }

        private void DisplayOwnName()
        {
            _clientForm.OwnName_Label.Invoke((MethodInvoker)delegate
            {

                if (_nickname != null)
                {
                    _clientForm.OwnName_Label.Text = $"{_nickname}({_personalId})";
                    _clientForm.OwnName_Label.Visible = true;
                }
                _clientForm.YouAreLabel.Invoke((MethodInvoker)delegate
                {
                    _clientForm.YouAreLabel.Visible = true;
                });
            });
        }

        private void HideOwnNameLabel()
        {
            _clientForm.OwnName_Label.Invoke((MethodInvoker)delegate
            {
                _clientForm.OwnName_Label.Text = "";
                _clientForm.OwnName_Label.Visible = false;
            });
            _clientForm.YouAreLabel.Invoke((MethodInvoker)delegate
            {
                _clientForm.YouAreLabel.Visible = false;
            });

        }

        public void DisplayNotification(string notification)
        {
            _clientForm.NotificationTextbox.Invoke((MethodInvoker)delegate
            {
                _clientForm.NotificationTextbox.Text = notification;
            });
        }

    }
}
