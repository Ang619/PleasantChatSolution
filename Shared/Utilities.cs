using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;

namespace Shared
{
    public static class Utilities
    {
        
        public static IPAddress GetLocalIPAddress()
        {
            IPAddress? myAddress;

            // Durchlaufen aller Netzwerkinterfaces auf dem Host
            foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Überprüfen, ob das Interface aktiv und eine IP-Adresse zugewiesen hat
                if (networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    // Durchlaufen aller IP-Adressen auf dem Interface
                    foreach (UnicastIPAddressInformation ip in networkInterface.GetIPProperties().UnicastAddresses)
                    {
                        // Überprüfen, ob die IP-Adresse eine IPv4-Adresse ist und nicht "localhost" loopback sind die Adressen die zurück auf den rechner zeigen
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork && !IPAddress.IsLoopback(ip.Address))
                        {
                            // Setzen der IP-Adresse als Ergebnis und Abbrechen der Schleife
                            myAddress = ip.Address;
                            return myAddress;


                            //Anstatt return füge ich die ip adressen einer liste hinzu, dann teste ich welche eine Internetverbindung hat, und returne die richtige IP Adresse

                        }
                    }
                }
            }
            return null;
        }

        public static int GetRandomPortNumber()
        {
            Random random = new Random();
            int rNum = random.Next(1024, 49151);

            return rNum;
        }

        public static bool CheckConnection(IPEndPoint theEndpoint)
        {
            if (theEndpoint.Address == null || theEndpoint.Port == 0)
            {
                //NotificationTextbox.Text = "Endpoint nicht gefunden";
                return false;
            }

            IPAddress ipAddress = theEndpoint.Address;
            int port = theEndpoint.Port;

            if (ipAddress.ToString() == "0.0.0.0")
            {
                //ChatListbox.Items.Add("Keine eigene IP-Adresse gefunden, bitte überprüfen Sie Ihren Netzweradapter.");
                return false;
            }

            try
            {
                Socket testConnectSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                testConnectSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.DontLinger, true);

                testConnectSocket.Connect("8.8.8.8", 53);

                //NotificationTextbox.Text = "Server bereit gestartet zu werden.";                

                testConnectSocket.Shutdown(SocketShutdown.Both);
                testConnectSocket.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }       
    }

    public class UniqueIdGenerator
    {
        //ID zero is reserverd for the Server
        private static int counter = 1;
        private static object lockObject = new object();

        public static int GetNextId()
        {
            lock (lockObject)
            {
                return counter++;
            }
        }
    }

    public class UniqueIdGeneratorMessages
    {
        //ID zero is reserverd for the Server
        private static int counter = 1;
        private static object lockObject = new object();

        public static int GetNextId()
        {
            lock (lockObject)
            {
                return counter++;
            }
        }
    }


}