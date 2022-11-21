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

namespace UI.Queries_UserViews
{
    /// <summary>
    /// Interaction logic for UserSpecs.xaml
    /// </summary>
    public partial class UserSpecs : UserControl
    {
        UserMainView baseWindow;
        int UserID;

        public UserSpecs(UserMainView main, int userID)
        {
            baseWindow = main;
            UserID = userID;


            InitializeComponent();

            using (SqlConnection conn = new SqlConnection("Data Source=cis560-team3.database.windows.net;Initial Catalog=music;Persist Security Info=True;User ID=admin1;Password=Singtome!"))
            {
                //musicDataSet.
                // 1.  create a command object identifying the stored procedure
                SqlCommand cmd3 = new SqlCommand("genreBreakdown_proc", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd3.CommandType = CommandType.StoredProcedure;

                cmd3.Parameters.AddWithValue("@userID", UserID);
                conn.Open();

                // execute the command
                using (SqlDataReader rdr = cmd3.ExecuteReader())
                {
                    // iterate through results, printing each to console
                    while (rdr.Read())
                    {
                        var song = new
                        {
                            GenreName = rdr["GenreName"],
                            Proportion = rdr["Proportion"]
                        };

                        GenreBreakdown.Items.Add(song.GenreName + " - " + song.Proportion);
                    }


                }

                SqlCommand cmd2 = new SqlCommand("avgUserPlaylistRating_proc", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd2.CommandType = CommandType.StoredProcedure;

                cmd2.Parameters.AddWithValue("@userID", UserID);


                // execute the command
                using (SqlDataReader rdr2 = cmd2.ExecuteReader())
                {
                    // iterate through results, printing each to console
                    while (rdr2.Read())
                    {
                        var rating = new
                        {
                            AvgRating = rdr2["AvgRating"],
                        };

                        PopulateAvgRating.Text = rating.AvgRating.ToString();
                    }

                }
            }

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            baseWindow.OverrideBorder.Child = null;
        }
    }
}
