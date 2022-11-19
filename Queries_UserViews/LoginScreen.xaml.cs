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

namespace UI
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : UserControl
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// resets the order
        /// </summary>
        /// <param name="sender">CancelOrderButton</param>
        /// <param name="e">click</param>
        public void OnLoginButtonClick(object sender, RoutedEventArgs e)
        {
            //chain main window view to search // user main
        }


    }
}
