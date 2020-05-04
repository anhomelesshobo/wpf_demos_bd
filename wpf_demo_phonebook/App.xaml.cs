using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using wpf_demo_phonebook.ViewModels;

namespace wpf_demo_phonebook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public MainWindow _wnd;

        public App()
        {
            _wnd = new MainWindow();
            _wnd.Height = 300;
            _wnd.Width = 800;
            _wnd.DataContext = new MainViewModel();
            _wnd.Show();
        }
    }
}
