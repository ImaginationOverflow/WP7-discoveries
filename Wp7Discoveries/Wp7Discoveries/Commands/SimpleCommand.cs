using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Wp7Discoveries.Commands
{
    public class SimpleCommand : ICommand
    {
        private readonly Action _cmd;

        public SimpleCommand(Action cmd)
        {
            _cmd = cmd;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _cmd();
        }

        public event EventHandler CanExecuteChanged;
    }
}
