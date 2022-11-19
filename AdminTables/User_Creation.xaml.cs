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
using static UI.musicDataSet;
using UI.musicDataSetTableAdapters;

namespace UI.Tables
{
    /// <summary>
    /// Interaction logic for User_Creation.xaml
    /// </summary>
    public partial class User_Creation : UserControl
    {
        MainWindow baseWindow;

        public User_Creation(MainWindow main)
        {
            baseWindow = main;

            InitializeComponent();
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            UsersTableAdapter UT = new UsersTableAdapter();
            UT.Insert(UsernameText.Text, EmailText.Text, false);

            baseWindow.OverrideBorder.Child = null;
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            baseWindow.OverrideBorder.Child = null;
        }
    }
}
