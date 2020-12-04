using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalProject.Views.MainView.MainViewChildren
{
    /// <summary>
    /// Interaction logic for AddElementView.xaml
    /// </summary>
    public partial class AddElementView : UserControl
    {
        public AddElementView()
        {
            InitializeComponent();
        }
       
        private void LocalRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.textBox.IsEnabled = false;
            this.btnChoose.IsEnabled = true;
        }
        private void URLRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.textBox.IsEnabled = true;
            this.btnChoose.IsEnabled = false;
        }

      
    }
}
