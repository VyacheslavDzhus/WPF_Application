using FinalProject.Infrastructure;
using FinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinalProject.Views
{
    /// <summary>
    /// Interaction logic for StartView.xaml
    /// </summary>
    public partial class StartView : Window
    {

        public StartView()
        {
            ResourceDictionary theme = new ResourceDictionary();
            theme.Source = new Uri($"{Environment.CurrentDirectory}\\LightTheme.xaml");
            App.Current.Resources.MergedDictionaries.Add(theme);
            Properties.Resources.Culture = new CultureInfo(ConfigurationManager.AppSettings[$"en-US"]);
            MainViewProxy.Proxy.Language = "Eng";

            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Loaded += StartWindow_Loaded;
        }
        public StartView(string text)
        {
            if(text == "en-US")
                MainViewProxy.Proxy.Language = "Eng";
            else if(text == "ru-RU")
                MainViewProxy.Proxy.Language = "Rus";

            Properties.Resources.Culture = new CultureInfo(ConfigurationManager.AppSettings[$"{text}"]);
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Loaded += StartWindow_Loaded;
        }
        private void StartWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICloseWindows vm)
            {
                vm.Close += () =>
                {
                    this.Close();
                };
            }
        }
    }
}
