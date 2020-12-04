using BLL.DTO;

using BLL.Services;
using FinalProject.Infrastructure;
using FinalProject.Views;
using FinalProject.Views.MainView.MainViewChildren;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FinalProject.ViewModels
{
    class StartViewModel : ICloseWindows
    {
        public Action Close { get; set; }
        private void CloseWindow() => Close?.Invoke();       
        public StartViewModel()
        {
            InitCommands();
        }
        private void InitCommands()
        {
            CreateMainWindowCommandFromDB = new RelayCommand(x =>
            {
                MainViewProxy.Proxy.StartUpKey = "DB";
                var window = new MainWindow();
                window.Show();
                CloseWindow();
            });
            CreateMainWindowCommandFromFile = new RelayCommand(x =>
            {
                MainViewProxy.Proxy.StartUpKey = "File";
                var window = new MainWindow();
                window.Show();
                CloseWindow();
            });
            ChangeLanguageCommand = new RelayCommand(x =>
            {
                var window = new StartView(x.ToString());
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.Show();
                CloseWindow();
            });          
        }
        #region Commands
        public ICommand CreateMainWindowCommandFromDB { get; set; }
        public ICommand CreateMainWindowCommandFromFile { get; set; }
        public ICommand ChangeLanguageCommand { get; set; }

        #endregion
    }
}
