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
using UI.Tables;

namespace UI
{
    /// <summary>
    /// Interaction logic for UserHomePage.xaml
    /// </summary>
    public partial class UserHomePage : UserControl
    {
        MainWindow baseWindow;
        int UserID;

        public UserHomePage(MainWindow main, int userID, string name)
        {
            baseWindow = main;
            UserID = userID;

            InitializeComponent();

            HelloText.Text = $"Hello, {name}!";
        }

        private void Query_Button_Click(object sender, RoutedEventArgs e)
        {
            OverrideBorder.Child = new SearchMusic(this, UserID);
        }

        private void Add_Artist_Button_Click(object sender, RoutedEventArgs e)
        {
            OverrideBorder.Child = new Musicians_Creation(this);
        }

        private void Add_Album_Button_Click(object sender, RoutedEventArgs e)
        {
            OverrideBorder.Child = new Album(this);
        }

        private void Add_Genre_Button_Click(object sender, RoutedEventArgs e)
        {
            OverrideBorder.Child = new Genre(this);
        }

        private void Add_Song_Button_Click(object sender, RoutedEventArgs e)
        {
            OverrideBorder.Child = new Song_Creation(this);
        }

        private void Add_Playlist_Button_Click(object sender, RoutedEventArgs e)
        {
            OverrideBorder.Child = new Playlist_Creation(this, UserID);
        }

        private void Add_Provider_Button_Click(object sender, RoutedEventArgs e)
        {
            OverrideBorder.Child = new Provider_Creation(this);
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            baseWindow.OverrideBorder.Child = null;
        }
    }
}
