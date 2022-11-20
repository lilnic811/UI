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
using UI.musicDataSetTableAdapters;
using UI.Tables;

namespace UI
{
    /// <summary>
    /// Interaction logic for AdminHomePage.xaml
    /// </summary>
    public partial class AdminHomePage : UserControl
    {
        MainWindow baseWindow;
        int UserID;

        public AdminHomePage(MainWindow main, int userID, string name)
        {
            baseWindow = main;
            UserID = userID;

            InitializeComponent();

            HelloText.Text = $"Hello, {name}!";
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

        private void Add_Provider_Button_Click(object sender, RoutedEventArgs e)
        {
            OverrideBorder.Child = new Provider_Creation(this);
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            UsersTableAdapter UT = new UsersTableAdapter();
            var user = UT.GetData().Where(Q => Q.UserID == UserID);
            UT.Update(user.Min().Username, user.Min().UserEmail, false, user.Min().UserID, user.Min().Username, user.Min().UserEmail, true);
            baseWindow.OverrideBorder.Child = null;
        }
    }
}
