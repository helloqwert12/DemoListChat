using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSocket
{
    public class SocketAPI
    {
        private static Socket socket;
        private static SocketAPI instance;
        private static bool isConnected;

        public SocketAPI()
        {
            socket = IO.Socket("http://hybershift-server-helloqwert12.c9users.io/");
            isConnected = false;
            this.EstablishConnection();
        }

        public static SocketAPI GetInstance()
        {
            if (instance == null)
                instance = new SocketAPI();
            return instance;
        }

        public Socket GetSocket()
        {
            return socket;
        }

        public void Connect()
        {
            if (!isConnected)
            {
                socket.Connect();
                isConnected = true;
                this.EstablishConnection();
            }
        }

        public void Disconnect()
        {
            if (isConnected)
            {
                socket.Disconnect();
                isConnected = false;
            }
        }

        public void EstablishConnection()
        {
            socket.On(Socket.EVENT_CONNECT, () =>
            {
               
            }).On(Socket.EVENT_DISCONNECT, () =>
            {
                
            });
        }
    }
}
