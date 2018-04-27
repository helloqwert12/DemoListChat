using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSocket
{
    public class Window2ViewModel: INotifyPropertyChanged
    {
        private string str;

        public event PropertyChangedEventHandler PropertyChanged;

        public DelegateCommand TestCommand { get; set; }
        public string Str
        {
            get { return str; }
            set { str = value; PropertyChanged(this, new PropertyChangedEventArgs("Str")); }
        }
        public Window2ViewModel()
        {
            TestCommand = new DelegateCommand(Test);
        }

        public void Test()
        {
            Str = "Test successfully";
        }
    }
}
