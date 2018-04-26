using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSocket
{
    public class ListChatModel
    {
        private ObservableCollection<ChatModel> list;
        private Socket socket;

        public ObservableCollection<ChatModel> ListChat
        {
            get { return list; }
            set { list = value; }
        }

        public ListChatModel()
        {
            list = new ObservableCollection<ChatModel>();
        }

        public void Add(ChatModel element)
        {
            list.Add(element);
        }
    }
}
