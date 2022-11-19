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
using System.Text.RegularExpressions;

namespace UI.Tables
{
    /// <summary>
    /// Interaction logic for Song_Creation.xaml
    /// </summary>
    public partial class Song_Creation : UserControl
    {
        AdminHomePage baseWindow;
        AlbumsTableAdapter AT = new AlbumsTableAdapter();
        ProvidersTableAdapter PT = new ProvidersTableAdapter();

        public Song_Creation(AdminHomePage main)
        {
            baseWindow = main;
            InitializeComponent();

            foreach (AlbumsRow item in AT.GetData())
                AlbumBox.Items.Add(item.AlbumName);

            foreach (ProvidersRow item in PT.GetData())
                ProviderBox.Items.Add(item.ProviderName);
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            var album = AT.GetData().Where(Q => Q.AlbumName == AlbumBox.Text).Min();
            SongsTableAdapter ST = new SongsTableAdapter();
            ST.Insert(SongText.Text, album.AlbumID, Int32.Parse(TrackText.Text));

            var song = ST.GetData().Where(Q => Q.SongName == SongText.Text && Q.AlbumID == album.AlbumID && Q.TrackNumber == Int32.Parse(TrackText.Text)).Min();
            var provider = PT.GetData().Where(Q => Q.ProviderName == ProviderBox.Text).Min();
            ProviderSongsTableAdapter PST = new ProviderSongsTableAdapter();
            PST.Insert(song.SongID, provider.ProviderID, ProviderBox.Text); 
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            baseWindow.OverrideBorder.Child = null;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
