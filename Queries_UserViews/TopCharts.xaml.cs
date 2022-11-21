using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for TopCharts.xaml
    /// </summary>
    public partial class TopCharts : UserControl
    {
        UserMainView baseWindow;
        int UserID;


        public TopCharts(UserMainView main, int userID)
        {
            InitializeComponent();
            baseWindow = main;
            UserID = userID;

            //SqlCommand getTop50 = new SqlCommand("dbo.topCharts_proc");
            //getTop50.CommandType = CommandType.StoredProcedure;
            //SongsTableAdapter ST = new SongsTableAdapter();
            //EnumerableRowCollection<musicDataSet.SongsRow> topSongs;

            //topSongs = getTop50;
            //foreach (var item in topSongs)
            //{
            //    TopChart.Items.Add(item);
            //}

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

                        TopChart.Items.Add(song);
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

                        playlistChart.Items.Add(song);
                    }

                }
            }

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            baseWindow.OverrideBorder.Child = new SearchMusic(baseWindow, UserID);
        }
    }
}
