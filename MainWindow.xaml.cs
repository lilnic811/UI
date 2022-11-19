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
                UT.Update(user.Min().Username, user.Min().UserEmail, true, user.Min().UserID, user.Min().Username, user.Min().UserEmail, false);

                OverrideBorder.Child = new UserHomePage(this, Convert.ToInt32(user.Min().UserID), user.Min().Username);
            }
        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            OverrideBorder.Child = new User_Creation(this);
        }
    }
}
