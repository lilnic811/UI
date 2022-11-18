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
    /// Interaction logic for UserHomePage.xaml
    /// </summary>
    public partial class UserHomePage : UserControl
    {
        MainWindow baseWindow;
        long UserID;

        public UserHomePage(MainWindow main, long userID, string name)
        {
            baseWindow = main;
            UserID = userID;

            InitializeComponent();

            HelloText.Text = $"Hello, {name}!";
        }

        private void Query_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Artist_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Album_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Genre_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Song_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Playlist_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Provider_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_User_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
