using Newtonsoft.Json.Linq;
using Prism.Commands;
using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DemoSocket
{
    class ChatViewModel: INotifyPropertyChanged
    {
        private Socket socket;
        private string selectedString;
        private ListChatModel listChatModel;
        public DelegateCommand<ChatModel> ItemSelectedCommand { get; set; } //Command use for SelectedChanged event of listview (or listbox, ...)
        
        public ObservableCollection<ChatModel> ListChat
        {
            get
            {
                return listChatModel.ListChat;
            }
            set
            {
                listChatModel.ListChat = value;
                NotifyPropertyChanged("ListChat");
            }
        }
        public string TextInput { get; set; }
        public DelegateCommand SendCommand { get; set; }    // Command for button send

        public ChatModel ItemSelected   // Property for binding when item was selected
        {
            get
            {
                return ItemSelected;
            }
            set
            {
                if (ItemSelected != null) 
                {
                    ItemSelected = value;
                    ChatModel obj = value as ChatModel;
                    CurrentSelected = obj.Name;
                    NotifyPropertyChanged("CurrentSelected");
                }
            }
        }
        public string CurrentSelected
        {
            get { return selectedString; }
            set
            {
                if (value!=selectedString)
                {
                    selectedString = value;
                    NotifyPropertyChanged("CurrentSelected");
                }
            }
        }

        public void SendMessege()
        {
            JObject msgObj = new JObject();
            msgObj.Add("name", "Quan");
            msgObj.Add("content", TextInput);

            socket.Emit("dotnet_new_message", msgObj);
            //NotifyPropertyChanged("ListChat");
            TextInput = "";
            NotifyPropertyChanged("TextInput");
        }
        
       
        public ChatViewModel()
        {
            selectedString = "";
            socket = SocketAPI.GetInstance().GetSocket();
            SendCommand = new DelegateCommand(SendMessege);
            ItemSelectedCommand = new DelegateCommand<ChatModel>(HandleSelectedItem);

            listChatModel = new ListChatModel();

            // Some sample instances
            listChatModel.Add(new ChatModel() { Name = "Name 1", Content = "Test content 1" });
            listChatModel.Add(new ChatModel() { Name = "Name 2", Content = "Test content 2" });
            listChatModel.Add(new ChatModel() { Name = "Name 3", Content = "Test content 3" });
            listChatModel.Add(new ChatModel() { Name = "Name 4", Content = "Test content 4" });
            listChatModel.Add(new ChatModel() { Name = "Name 5", Content = "Test content 5" });

            RecieveMessege();
        }

        private void RecieveMessege()
        {
            socket.On("dotnet_new_message", (messege) =>
            {
                JObject jobjet = messege as JObject;
                ChatModel element = new ChatModel();
                element.Name = jobjet.GetValue("name").ToString();
                element.Content = jobjet.GetValue("content").ToString();
                
                App.Current.Dispatcher.Invoke((Action)delegate
               {
                   listChatModel.Add(element);
               });
            });
        }

        private void HandleSelectedItem(ChatModel obj)
        {
            CurrentSelected = obj.Name;
        }

        // implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        // this method is just for convenience
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
