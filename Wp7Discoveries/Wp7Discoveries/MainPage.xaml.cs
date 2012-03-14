using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Wp7Discoveries.ViewModels;

namespace Wp7Discoveries
{
    public partial class MainPage : PhoneApplicationPage
    {
        private MainViewModel _viewModel;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
            
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel = MainViewModel.Instance;
        }

        private void GetBytesButtonClick(object sender, RoutedEventArgs e)
        {
            _viewModel.FetchGoogleHttpResponseByteCountCommand.Execute(null);
        }


        
    }



}