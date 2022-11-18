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
    /// Interaction logic for Playlist_Creation.xaml
    /// </summary>
    public partial class Playlist_Creation : UserControl
    {
        MainWindow baseWindow;
        int UserID;

        public Playlist_Creation(MainWindow main, int userID)
        {
            baseWindow = main;
            UserID = userID;
            InitializeComponent();
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            PlaylistsTableAdapter PT = new PlaylistsTableAdapter();
            PT.Insert(PlaylistText.Text, UserID);
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            //baseWindow.OverrideBorder.Child = null;
        }
    }
}
