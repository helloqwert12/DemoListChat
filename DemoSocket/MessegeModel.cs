using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSocket
{
    public class MessegeModel
    {
        string currContent;

        public string CurrentContent
        {
            get { return currContent; }
            set { currContent = value; }
        }

        public MessegeModel()
        {
            currContent = "";        
        }

        //public bool sendMessage()
        //{
        //    if (currContent.Length > 0)
        //    {
        //        socket.Emit("dotnet_new_message", currContent);
        //        return true;
        //    }

        //    return false;
        //}
    }
}
