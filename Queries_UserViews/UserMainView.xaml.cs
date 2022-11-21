using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Xml.Linq;
using UI.musicDataSetTableAdapters;
using UI.Tables;

namespace UI.Queries_UserViews
{
    /// <summary>
    /// Interaction logic for UserMainView.xaml
    /// </summary>
    public partial class UserMainView : UserControl
    {
        MainWindow baseWindow;
        int UserID;

        public UserMainView(MainWindow main, int userID, string name)
        {
            baseWindow = main;
            UserID = userID;

            InitializeComponent();

            HelloText.Text = $"Hello, {name}!";

            PlaylistsTableAdapter PLT = new PlaylistsTableAdapter();
            var PLs = PLT.GetData().Where(Q => Q.UserID == UserID);
            foreach (var item in PLs)
            {
                PlaylistList.Items.Add(item.PlaylistName);
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            UsersTableAdapter UT = new UsersTableAdapter();
            var user = UT.GetData().Where(Q => Q.UserID == UserID);
            UT.Update(user.Min().Username, user.Min().UserEmail, false, user.Min().UserID, user.Min().Username, user.Min().UserEmail, user.Min().IsActive);
            baseWindow.OverrideBorder.Child = null;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            OverrideBorder.Child = new SearchMusic(this, UserID);
        }

        private void ViewPlaylistButton_Click(object sender, RoutedEventArgs e)
        {
            dynamic row = PlaylistList.SelectedItems[0];

            PlaylistsTableAdapter PT = new PlaylistsTableAdapter();
            var playlist = PT.GetData().Where(Q => Q.UserID == UserID && Q.PlaylistName == row).Min();


            OverrideBorder.Child = new SearchResults(this, UserID, (int)playlist.PlaylistID);
        }

        private void CreatePlaylistButton_Click(object sender, RoutedEventArgs e)
        {
            OverrideBorder.Child = new Playlist_Creation(this, UserID);
        }

        private void SpecsButton_Click(object sender, RoutedEventArgs e)
        {

            using (SqlConnection conn = new SqlConnection("Data Source=cis560-team3.database.windows.net;Initial Catalog=music;Persist Security Info=True;User ID=admin1;Password=Singtome!"))
            {
                conn.Open();
                //musicDataSet.
                // 1.  create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("topCharts_proc", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;


                // execute the command
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // iterate through results, printing each to console
                    while (rdr.Read())
                    {
                        var song = new
                        {
                            SongName = rdr["SongName"],
                            MusicianName = rdr["MusicianName"]
                        };

                        //TopChart.Items.Add(song.SongName + " - " + song.MusicianName);
                    }


                }

                SqlCommand cmd2 = new SqlCommand("mostPlaylisted_proc", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd2.CommandType = CommandType.StoredProcedure;


                // execute the command
                using (SqlDataReader rdr2 = cmd2.ExecuteReader())
                {
                    // iterate through results, printing each to console
                    while (rdr2.Read())
                    {
                        var song = new
                        {
                            SongName = rdr2["SongName"],
                            MusicianName = rdr2["MusicianName"]
                        };

                        //playlistChart.Items.Add(song.SongName + " - " + song.MusicianName);
                    }

                }
            }

        }
    }
}
