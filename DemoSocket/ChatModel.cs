using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSocket
{
    public class ChatModel: INotifyPropertyChanged
    {
        private Socket socket;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }
        public string Content { get; set; }

        public ChatModel()
        {
            Name = "";
            Content = "";
            socket = SocketAPI.GetInstance().GetSocket();
        }

        public void SendMessege()
        {
            
        }
    }
}
