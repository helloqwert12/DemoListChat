using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DemoSocket
{
    class ChatMessegeViewModel : INotifyPropertyChanged

        
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IHavePassword password;

        ChatMessegeModel model;

        

        public ChatMessegeViewModel()
        {
            model = new ChatMessegeModel();
        }

        public string TxtInput
        {
            get { return model.CurrMessege.CurrentContent.ToString(); }
            set {
                model.CurrMessege.CurrentContent = Convert.ToString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("TxtInput"));
            }
        }

        public List<string> LvMessege
        {
            get;set;
        }

    
    }
}
