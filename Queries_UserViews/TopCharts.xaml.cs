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

            SqlCommand getTop50 = new SqlCommand("dbo.topCharts_proc");
            getTop50.CommandType = CommandType.StoredProcedure;
            SongsTableAdapter ST = new SongsTableAdapter();
            EnumerableRowCollection<musicDataSet.SongsRow> topSongs;
            //topSongs = getTop50;
            //foreach (var item in topSongs)
            //{
            //    TopChart.Items.Add(item);
            //}

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            baseWindow.OverrideBorder.Child = new SearchMusic(baseWindow, UserID);
        }
    }
}
