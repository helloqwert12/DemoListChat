using Newtonsoft.Json;
using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoSocket
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Socket socket;

        public MainWindow()
        {
            InitializeComponent();
            socket = SocketAPI.GetInstance().GetSocket();
            //DataContext = new ChatViewModel();
        }

        //public void InitSocket()
        //{
        //    socket = IO.Socket("http://hybershift-server-helloqwert12.c9users.io/");

        //    socket.On(Socket.EVENT_CONNECT, () =>
        //    {
        //        Console.Write("Client connected to server");
        //    }).On(Socket.EVENT_DISCONNECT, ()=>
        //    {

        //        Console.Write("Client disconnected to server");
        //    });

        //    //message event
        //    socket.On("dotnet_new_message", (message) =>
        //    {
        //        this.Dispatcher.Invoke(() =>
        //        {
        //            lvMessage.Items.Add(message);
        //        });
        //    });
        //}
    }
}
