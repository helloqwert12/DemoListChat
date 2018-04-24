using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSocket
{
    public class ChatMessegeModel
    {
        MessegeModel currMessege;
        List<MessegeModel> list;
        Socket socket;

        public MessegeModel CurrMessege
        {
            get { return currMessege; }
            set { currMessege = value; }
        }

        public List<MessegeModel> ListMessege
        {
            get { return list; }
            set { list = value; }
        }

        public ChatMessegeModel()
        {
            currMessege = new MessegeModel();
            list = new List<MessegeModel>();
            socket = SocketAPI.GetInstance().GetSocket();

            socket.On("dotnet_new_message", (message) =>
            {
                list.Add((MessegeModel)message);
            });
        }

        public bool sendMessege()
        {
            socket.Emit("dotnet_new_message", currMessege);
            return true;
        }

    }
}
