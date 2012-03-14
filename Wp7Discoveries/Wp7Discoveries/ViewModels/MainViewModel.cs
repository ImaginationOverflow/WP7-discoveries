using System;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Wp7Discoveries.Commands;
using Wp7Discoveries.Model;

namespace Wp7Discoveries.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IWebRequestResultCounter _counterService;


        public event PropertyChangedEventHandler PropertyChanged;

        public int _byteCount;
        public int ByteCount
        {
            get { return _byteCount; }
            set
            {
                if (_byteCount == value)
                    return;
                _byteCount = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ByteCount"));
            }
        }

        

        public ICommand FetchGoogleHttpResponseByteCountCommand { get; private set; }

        public static MainViewModel Instance { get; private set; }

        static MainViewModel()
        {
            Instance = new MainViewModel(new SimpleWebRequestResultCounter());
        }

        public MainViewModel(IWebRequestResultCounter counterService)
        {
            _counterService = counterService;
            FetchGoogleHttpResponseByteCountCommand = new SimpleCommand(() => _counterService.GetCountFor
                (
                    new Uri("http://www.google.com",UriKind.Absolute),
                    count => Deployment.Current.Dispatcher.BeginInvoke(() => ByteCount = count))
                );
        }
    }
}
