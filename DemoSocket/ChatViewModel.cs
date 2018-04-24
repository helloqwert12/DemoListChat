using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DemoSocket
{
    class ChatViewModel: INotifyPropertyChanged
    {
        private string selectedString;
        public DelegateCommand<ChatModel> ItemSelectedCommand { get; set; } //Command use for SelectedChanged event of listview (or listbox, ...)
        
        public List<ChatModel> ListChat { get; set; }

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
            // TO-DO: implement sending with socket here
        }
        
       
        public ChatViewModel()
        {
            selectedString = "";

            SendCommand = new DelegateCommand(SendMessege);
            ItemSelectedCommand = new DelegateCommand<ChatModel>(HandleSelectedItem);
            
            ListChat = new List<ChatModel>();

            // Some sample instances
            ListChat.Add(new ChatModel() { Name = "Name 1", Content = "Test content 1" });
            ListChat.Add(new ChatModel() { Name = "Name 2", Content = "Test content 2" });
            ListChat.Add(new ChatModel() { Name = "Name 3", Content = "Test content 3" });
            ListChat.Add(new ChatModel() { Name = "Name 4", Content = "Test content 4" });
            ListChat.Add(new ChatModel() { Name = "Name 5", Content = "Test content 5" });
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
