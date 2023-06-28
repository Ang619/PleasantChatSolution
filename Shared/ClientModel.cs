using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ClientModel
    {
        public int Id { get; private set; }
        public string _name { get; private set; }
        public Socket socket { get; private set; }

        public ClientModel(int id, string name, Socket socket)
        {
            this.Id = id;
            this._name = name;
            this.socket = socket;   
        }


    }


}
