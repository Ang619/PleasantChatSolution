using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class DataModel
    {
        public DataModel(string _message, int _senderID, string _senderName, int _receiverID, string _receiverName, bool _isWhisperMessage)
        {
            this._messageID = UniqueIdGeneratorMessages.GetNextId();
            this._message = _message;
            this._senderID = _senderID;
            this._senderName = _senderName;
            this._receiverID = _receiverID;
            this._receiverName = _receiverName;
            this._isWhisperMessage = _isWhisperMessage;
        }

        public int _messageID { get; private set; }
        public string _message { get; private set; }
        public int _senderID { get; private set; }
        public string _senderName { get; private set; }
        public int _receiverID { get; private set; }
        public string _receiverName { get; private set; }
        public bool _isWhisperMessage { get; private set; }


    }
}
