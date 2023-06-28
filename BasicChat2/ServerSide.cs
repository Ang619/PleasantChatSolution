using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace BasicChat2
{
    internal class ServerSide
    {
        
        private Socket? _serverSocket;
        private IPEndPoint? _serverEndpoint;
        private List<Socket> _clientSocketList = new List<Socket>();
        private int _amountConectionsAllowed = 10;

        public ServerSide(IPEndPoint serverEndpoint)
        {
            
            //Erstelle den Socket
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);           
            //Binde den Endpoint
            _serverSocket.Bind(serverEndpoint);
            _serverSocket.Listen(_amountConectionsAllowed);
            Console.WriteLine("Server lauscht...");
            //NotificationTextbox.Text = "Server erfolgreich gestartet.";
        }

        private async Task AcceptClient()
        {
            await Task.Run(async () =>
                        {
                            try
                            {
                                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                                while (true)
                                {
                                    clientSocket = await _serverSocket.AcceptAsync();
                                    //SetStatusToConnected(clientSocket);
                                    _clientSocketList.Add(clientSocket);

                                    Console.WriteLine($"Client {clientSocket.RemoteEndPoint} verbunden.");

                                    Task singleClientTask = Task.Run(() => HandleClient(clientSocket));                                    

                                    if (!clientSocket.Connected)
                                    {
                                        break;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        });
        }



        private async Task SendToAllAsync(string message, Socket ownSocket)
        {
            //GetBytes gibt mir schon ein Array in der richtigen Größe
            //byte[] tempbytes = new byte[1024];
            byte[] tempbytes = Encoding.UTF8.GetBytes(message);


            foreach (Socket clientSocket in _clientSocketList)
            {
                //Hier könnte ich den eigenen Socket auschließen, und die eigene Nachricht einfach der eigenen Textbox hinzufügen.
                if (clientSocket is not null /*&& clientSocket != ownSocket*/)
                {
                    await clientSocket.SendAsync(tempbytes);
                    Console.WriteLine($"Send to all " + message);
                }

            }
        }
    }
}
