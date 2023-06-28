using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shared
{
    public class Chatlog
    {
        private DateTime _datetimeChat { get; }
        private List<DataModel> _chatList { get; }

        public Chatlog(List<DataModel> dataModels)
        {
            this._chatList = dataModels;
            this._datetimeChat = DateTime.Now;
        }

        public string? getJsonAsString()
        {
            string result = string.Empty;
            foreach(var model in _chatList)
            {
                result += JsonSerializer.Serialize<DataModel>(model);
            }
            if(result !=  string.Empty)
            {
                return result;
            }
            else
            {
                return null;
            }
        }




    }
}
