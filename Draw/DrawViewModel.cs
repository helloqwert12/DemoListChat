using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Draw
{
    public class DrawViewModel
    {
        public DelegateCommand<MouseButtonEventArgs> MouseDownCommand { get; set; }
        public DrawViewModel()
        {
            MouseDownCommand = new DelegateCommand<MouseButtonEventArgs>(MouseDown);
        }

        public void MouseDown(MouseButtonEventArgs p)
        {
            Debug.WriteLine(p);
        }
    }
}
