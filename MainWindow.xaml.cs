using System;
using System.Collections.Generic;
using System.Data;
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
using UI.Queries_UserViews;
using UI.Tables;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            UsersTableAdapter UT = new UsersTableAdapter();
            var user = UT.GetData().Where(Q => Q.UserEmail == EmailText.Text && Q.Username == UsernameText.Text);

            if (user.Count() == 0)
                invalidAttempt.Visibility = Visibility.Visible;
            else
            {
                var min = user.Min();
                UT.Update(min.Username, min.UserEmail, true, min.UserID, min.Username, min.UserEmail, min.IsActive);

                UsernameText.Text = "";
                EmailText.Text = "";
                invalidAttempt.Visibility = Visibility.Hidden;

                if (min.Username.Equals("Admin") && min.UserEmail.Equals("Admin") && min.UserID == 1)
                    OverrideBorder.Child = new AdminHomePage(this, Convert.ToInt32(min.UserID), min.Username);
                else
                    OverrideBorder.Child = new UserMainView(this, Convert.ToInt32(min.UserID), min.Username);
            }
        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            OverrideBorder.Child = new User_Creation(this);
        }
    }
}
