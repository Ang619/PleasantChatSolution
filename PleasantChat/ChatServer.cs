using System.Net.Sockets;
using System.Net;
using System.Text;
using Shared;
using System.Text.Json;
using System.Security.Cryptography;

namespace PleasantChat
{
    internal class ChatServer
    {
        private IPEndPoint? _serverEndpoint;
        private Socket _serverSocket;
        private int _port = 13053;
        private Dictionary<int, ClientModel> _clientDictionary = new Dictionary<int, ClientModel>();
        private int _serverID = 0;
        private string _serverName = "Server";
        private int _amountConectionsAllowed = 20;
        private ServerForm _serverForm;
        private int selectedItem;
        //TODO bessere Identifyer
        private string _messageIdentifyer = "~*~*~*~";
        private string _listIdentifyer = "~? ~? ~? ~";
        private string _IDIdentifyer = "~# ~# ~# ~";
        private string _nicknameIdentifyer = "~§ ~§ ~§ ~";


        public ChatServer(ServerForm form)
        {
            this._serverForm = form;
            //UI
            _serverForm.SelectUserCombobox.SelectedIndexChanged += SelectUserCombobox_SelectedIndexChanged;
        }

        public async void StartServer()
        {
            try
            {
                //Create a serversocket that listens for incoming clients         
                ServerListen();

                if (_serverEndpoint != null)
                {
                    //Check if the endpoint can connect with google servers
                    if (CheckConnection(_serverEndpoint))
                    {
                        //Create own Model and add it to the dictionary
                        var ServerModel = new ClientModel(_serverID, _serverName, _serverSocket);
                        _clientDictionary.Add(0, ServerModel);

                        //UI
                        Console.WriteLine($"Server is listening for incoming clients on {_serverEndpoint.Address.ToString()}");
                        SetStatusToRunning();
                        ButtonLogicConnect();

                        //Accept clients in a loop
                        while (true)
                        {
                            try
                            {
                                //Exchange ID and Username with Clients
                                Task<ClientModel> acceptClientsTask = AcceptClients();
                                ClientModel client = await acceptClientsTask;

                                //Receive messages on its own task, we dont await for it so we can continue accepting new clients
                                ReceiveMessages(client);

                            }
                            catch (Exception ex)
                            {
                                SetStatusToStopped();
                                break;
                            }
                        }
                    }
                    else
                    {
                        //UI
                        DisplayNotification("Server kann keine Verbindung zum Internet aufbauen. Netzwerkadapter überprüfen.");
                        SetStatusToStopped();
                    }
                }
                else
                {
                    //UI
                    SetStatusToStopped();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //UI
                DisplayNotification("Server kann nicht gestartet werden.");
                SetStatusToStopped();
            }
        }

        private void ServerListen()
        {
            try
            {
                _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _serverEndpoint = new IPEndPoint(Utilities.GetLocalIPAddress()!, _port);
                _serverSocket.Bind(_serverEndpoint);
                _serverSocket.Listen(_amountConectionsAllowed);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void StopServer()
        {
            //Try to close and shutdown all client sockets           
            foreach (KeyValuePair<int, ClientModel> ClientSocketInstance in _clientDictionary)
            {
                if (ClientSocketInstance.Value.socket != null && ClientSocketInstance.Value.socket.Connected)
                {
                    try
                    {
                        ClientSocketInstance.Value.socket.Shutdown(SocketShutdown.Both);
                        ClientSocketInstance.Value.socket.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            //Try to close the listening socket
            try
            {
                _serverSocket.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //UI
                SetStatusToStopped();
                ButtonLogicDisonnect();
                _clientDictionary.Clear();
            }

        }

        public async Task SendDatamodelAsync(DataModel datamodel)
        {
            byte[] temp = new byte[1024];

            //Check if Receiver and Sender exist in the Database
            if (_clientDictionary.ContainsKey(datamodel._senderID) && _clientDictionary.ContainsKey(datamodel._receiverID))
            {
                //Prepare
                string json = JsonSerializer.Serialize(datamodel);
                temp = Encoding.UTF8.GetBytes(_messageIdentifyer + json);

                //Send
                try
                {
                    await _clientDictionary[datamodel._receiverID].socket.SendAsync(temp);
                }
                //If message cant be send to the client, we remove him
                catch
                {
                    _clientDictionary.Remove(datamodel._receiverID);
                    SendListToUsers();
                    //UI
                    DisplayNotification("Senden der Nachricht fehlgeschlagen, bitte versuchen Sie es erneut.");
                }
            }
        }

        public async void Send(bool whisper)
        {
            int counter = 0;

            if (MessageIsValid(_serverForm.MessageTextbox.Text))
            {
                foreach (var client in _clientDictionary)
                {
                    //Loop till we find the selected client for whisper message
                    if (whisper && client.Key != _clientDictionary.ElementAt(selectedItem).Key)
                    {
                        continue;
                    }

                    //Dont send to myself
                    if (client.Key != _serverID && _serverName != null)
                    {
                        var messageDataModel = new DataModel(_serverForm.MessageTextbox.Text, _serverID, _serverName, client.Key, client.Value._name, whisper);
                        await SendDatamodelAsync(messageDataModel);

                        //Display Message only once if send to multiple people
                        if (counter == 0)
                        {
                            DisplayMessage(messageDataModel);
                        }
                        counter++;
                    }
                }
            }
            else
            {
                DisplayNotification("Nachricht darf nicht leer sein oder mehr als 300 Zeichen beinhalten.");
            }
        }

        private async Task<ClientModel> AcceptClients()
        {
            DisplayNotification("");


            //Create socket for incoming client
            Socket clientSocket;
            //Wait for client
            clientSocket = await _serverSocket.AcceptAsync();

            //Generate Unique ID 
            int PersonalID = UniqueIdGenerator.GetNextId();

            //Send ID to the client
            byte[] bytes = Encoding.UTF8.GetBytes(_IDIdentifyer + PersonalID.ToString());
            await clientSocket.SendAsync(bytes);

            //Wait for nickname
            byte[] tempBytes = new byte[1024];
            var amountBytes = await clientSocket.ReceiveAsync(tempBytes);
            string responeNickname = Encoding.UTF8.GetString(tempBytes, 0, amountBytes);

            if (responeNickname.StartsWith(_nicknameIdentifyer))
            {
                string[] parts = responeNickname.Split(new string[] { _nicknameIdentifyer }, StringSplitOptions.RemoveEmptyEntries);

                Console.WriteLine("Server received Nickname:" + parts[0]);

                //Create client model since we have all informations now
                var client = new ClientModel(PersonalID, parts[0], clientSocket);
                _clientDictionary.Add(PersonalID, client);

                //UI
                DisplayUsers();
                SendListToUsers();

                return client;
            }
            else
            {
                //UI
                Console.WriteLine($"Failed to receive Nickname from client {PersonalID}.");
                DisplayNotification($"Failed to receive Nickname from client {PersonalID}");
                return null;
            }

        }

        private async Task ReceiveMessages(ClientModel client)
        {
            //Counter is for displaying messages as intended
            int counter = 0;
            byte[] tempBytes = new byte[1024];

            try
            {
                while (client != null && client.socket.Connected)
                {
                    //TODO Buffer Problem
                    //ReceiveMessage
                    var receivedData = await client.socket.ReceiveAsync(tempBytes);
                    

                    //We receive a nullbyte if the client disconnects
                    if (receivedData == 0)
                    {
                        RemoveClient(client.Id);
                        break;
                    }

                    //Decode message
                    string decodedMessage = Encoding.UTF8.GetString(tempBytes, 0, receivedData);
                    Console.WriteLine($"Server has received: {decodedMessage}");

                    //If we received a message
                    if (decodedMessage.StartsWith(_messageIdentifyer))
                    {
                        string dataString = decodedMessage.Substring(_messageIdentifyer.Length);

                        string[] messages = dataString.Split(new[] { _messageIdentifyer }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (var message in messages)
                        {
                            //Prepare datamodel
                            DataModel? receivedModel = JsonSerializer.Deserialize<DataModel>(message);

                            //If the message is to be transfered to another client
                            if (_clientDictionary.ContainsKey(receivedModel._senderID) && _clientDictionary.ContainsKey(receivedModel._receiverID) && receivedModel._receiverID != _serverID)
                            {
                                await SendDatamodelAsync(receivedModel);
                            }
                            else
                            {
                                DisplayMessage(receivedModel);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.Write(ex.Message);
                try
                {
                    RemoveClient(client.Id);
                }
                catch (Exception exep)
                {
                    Console.WriteLine(exep.StackTrace);

                }
            }
        }



        private async void SendListToUsers()
        {
            if (_clientDictionary.Count > 1)
            {
                string availibleUsers = "";
                byte[] data = new byte[1024];

                foreach (KeyValuePair<int, ClientModel> ClientSocketInstance in _clientDictionary)
                {
                    if (ClientSocketInstance.Value.socket != null)
                    {
                        //Add each Client-Key and each Client-name to the string, seperated by identidyer
                        availibleUsers += _listIdentifyer + ClientSocketInstance.Key + _listIdentifyer + ClientSocketInstance.Value._name;
                    }
                }
                data = Encoding.UTF8.GetBytes(availibleUsers);

                foreach (KeyValuePair<int, ClientModel> ClientSocketInstance in _clientDictionary)
                {
                    //Dont send to myself
                    if (ClientSocketInstance.Key != _serverID)
                    {
                        //Send Userslist to all Users
                        await ClientSocketInstance.Value.socket.SendAsync(data);
                    }
                }
            }
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


        public void RemoveClient(int ID)
        {
            if (_clientDictionary.ContainsKey(ID))
            {
                _clientDictionary.Remove(ID);
                if (_clientDictionary.Count > 0)
                {
                    SendListToUsers();
                }
            }
        }

        public bool CheckConnection(IPEndPoint theEndpoint)
        {

            if (theEndpoint != null)
            {
                if (theEndpoint.Address == null || theEndpoint.Port == 0)
                {
                    return false;
                }

                if (theEndpoint.Address.ToString() == "0.0.0.0")
                {
                    return false;
                }

                IPAddress ipAddress = theEndpoint.Address;
                int port = theEndpoint.Port;

                try
                {
                    
                    Socket testConnectSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    // Try to connect to Google servers using UDP
                    testConnectSocket.Connect("8.8.8.8", 53);

                    // Close the test socket
                    testConnectSocket.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void DisplayUsers()
        {
            _serverForm.SelectUserCombobox.Invoke((MethodInvoker)delegate
            {
                _serverForm.SelectUserCombobox.Items.Clear();

                foreach (var client in _clientDictionary.Values)
                {
                    string displayText = $"({client.Id}) {client._name}";
                    _serverForm.SelectUserCombobox.Items.Add(displayText);
                }
            });
        }



        public void DisplayMessage(DataModel model)
        {
            //If is whisper message
            if (model != null && model._isWhisperMessage)
            {
                //If we sended the message
                if (model._senderID == _serverID && model._senderName == _serverName)
                    _serverForm.ChatListbox.Invoke((MethodInvoker)delegate
                    {
                        _serverForm.ChatListbox.Items.Add($"[Du flüsterst an {model._receiverName}({model._receiverID})]: " + model._message);
                    });
                //If someone else sended
                else
                {
                    _serverForm.ChatListbox.Invoke((MethodInvoker)delegate
                    {
                        _serverForm.ChatListbox.Items.Add($"[{model._senderName}({model._senderID})] flüstert zu [{model._receiverName}({model._receiverID})]: " + model._message);
                    });

                }
            }
            //If message to all
            else if (model != null && !model._isWhisperMessage)
            {
                _serverForm.ChatListbox.Invoke((MethodInvoker)delegate
                {
                    _serverForm.ChatListbox.Items.Add($"[{model._senderName}]({model._senderID}): " + model._message);
                });
            }
        }


        private void SelectUserCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItem = _serverForm.SelectUserCombobox.SelectedIndex;
        }

        private void SetStatusToRunning()
        {

            _serverForm.ServerStatusLabel.Invoke((MethodInvoker)delegate
            {
                _serverForm.ServerStatusLabel.Text = "Server aktiv";
                _serverForm.ServerStatusLabel.BackColor = Color.Green;
            });

        }

        private void SetStatusToStopped()
        {

            _serverForm.ServerStatusLabel.Invoke((MethodInvoker)delegate
            {
                _serverForm.ServerStatusLabel.Text = "Gestoppt";
                _serverForm.ServerStatusLabel.BackColor = Color.Red;
            });

        }

        public void DisplayNotification(string notification)
        {
            _serverForm.NotificationTextbox.Invoke((MethodInvoker)delegate
            {
                _serverForm.NotificationTextbox.Text = notification;
            });
        }

        private void ButtonLogicConnect()
        {
            _serverForm.CmdRunServer.Invoke((MethodInvoker)delegate
            {
                _serverForm.CmdRunServer.Enabled = false;
            });
            _serverForm.cmdStopServer.Invoke((MethodInvoker)delegate
            {
                _serverForm.cmdStopServer.Enabled = true;
            });
            _serverForm.MessageTextbox.Invoke((MethodInvoker)delegate
            {
                _serverForm.MessageTextbox.Enabled = true;
            });
            _serverForm.CmdSend.Invoke((MethodInvoker)delegate
            {
                _serverForm.CmdSend.Enabled = true;
            });
            _serverForm.CmdSendToSelected.Invoke((MethodInvoker)delegate
            {
                _serverForm.CmdSendToSelected.Enabled = true;
            });
        }
        private void ButtonLogicDisonnect()
        {
            _serverForm.CmdRunServer.Invoke((MethodInvoker)delegate
            {
                _serverForm.CmdRunServer.Enabled = true;
            });
            _serverForm.cmdStopServer.Invoke((MethodInvoker)delegate
            {
                _serverForm.cmdStopServer.Enabled = false;
            });
            _serverForm.MessageTextbox.Invoke((MethodInvoker)delegate
            {
                _serverForm.MessageTextbox.Enabled = false;
            });
            _serverForm.CmdSend.Invoke((MethodInvoker)delegate
            {
                _serverForm.CmdSend.Enabled = false;
            });
            _serverForm.CmdSendToSelected.Invoke((MethodInvoker)delegate
            {
                _serverForm.CmdSendToSelected.Enabled = false;
            });
        }

        




    }
}

