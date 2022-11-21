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

namespace UI
{
    /// <summary>
    /// Interaction logic for UserEditSong.xaml
    /// </summary>
    public partial class UserEditSong : UserControl
    {
        UserMainView baseWindow;
        SearchResults searchWindow;
        int UserID;
        int SongID;
        PlaylistsTableAdapter PT = new PlaylistsTableAdapter();

        public UserEditSong(UserMainView main, SearchResults results, int userID, int songID)
        {
            baseWindow = main;
            searchWindow = results;
            UserID = userID;
            SongID = songID;

            InitializeComponent();

            foreach (musicDataSet.PlaylistsRow item in PT.GetData().Where(Q => Q.UserID == UserID))
                PlaylistDropDown.Items.Add(item.PlaylistName);
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            baseWindow.OverrideBorder.Child = searchWindow;
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            musicDataSet MD = new musicDataSet();

            PlaylistSongsTableAdapter PST = new PlaylistSongsTableAdapter();
            var playlistListSongs = PST.GetData().Where(Q => Q.SongID == SongID);
            if (PlaylistDropDown.Items.Count != 0 && playlistListSongs.Count() == 0)
            {
                var playlist = PT.GetData().Where(Q => Q.UserID == UserID && Q.PlaylistName == PlaylistDropDown.Text).Min();

                PlaylistSongsTableAdapter PLS = new PlaylistSongsTableAdapter();
                PLS.Insert(playlist.PlaylistID, SongID);
            }

            UserRatingsTableAdapter URT = new UserRatingsTableAdapter();
            var songs = URT.GetData().Where(Q => Q.SongID == SongID && Q.UserID == UserID);
            if (songs.Count() == 0)
            {
                URT.Insert(UserID, SongID, (int)RateSlider.Value, DateTime.Now, null);
            }
            else
            {
                var song = songs.Min();
                URT.Update(UserID, SongID, (int)RateSlider.Value, DateTime.Now, null, song.UserRatingID,
                            UserID, SongID, song.Rating, DateTime.Now, null);
            }

            baseWindow.OverrideBorder.Child = searchWindow;

        }
    }
}
