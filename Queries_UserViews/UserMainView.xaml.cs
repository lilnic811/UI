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
using System.Xml.Linq;

namespace UI.Queries_UserViews
{
    /// <summary>
    /// Interaction logic for UserMainView.xaml
    /// </summary>
    public partial class UserMainView : UserControl
    {
        public UserMainView()
        {
            InitializeComponent();

            HelloText.Text = $"Hello, {name}!";
        }


        private void OnSearchButtonClick(object sender, RoutedEventArgs e)
        {
            
        }





        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ViewPlaylistButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreatePlaylistButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
