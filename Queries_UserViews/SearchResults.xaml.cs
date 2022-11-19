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
using UI.musicDataSetTableAdapters;

namespace UI
{
    /// <summary>
    /// Interaction logic for SearchResults.xaml
    /// </summary>
    public partial class SearchResults : UserControl
    {
        AdminHomePage baseWindow;
        int UserID;

        public SearchResults(AdminHomePage main, int userID, string song, string genre, string musician, string year, string rating)
        {
            baseWindow = main;
            UserID = userID;

            InitializeComponent();

            SongsTableAdapter ST = new SongsTableAdapter();
            EnumerableRowCollection<musicDataSet.SongsRow> songsList;
            if (song.Equals(""))
                songsList = ST.GetData().Where(Q => true);
            else
                songsList = ST.GetData().Where(Q => Q.SongName.Contains(song));

            GenreTableAdapter GT = new GenreTableAdapter();
            EnumerableRowCollection<musicDataSet.GenreRow> genresList;
            if(genre.Equals("Any"))
                genresList = GT.GetData().Where(Q => true);
            else
                genresList = GT.GetData().Where(Q => Q.GenreName == genre);

            MusiciansTableAdapter MT = new MusiciansTableAdapter();
            EnumerableRowCollection<musicDataSet.MusiciansRow> musicianList;
            if (!musician.Equals(""))
                musicianList = MT.GetData().Where(Q => true);
            else
                musicianList = MT.GetData().Where(Q => Q.MusicianName.Contains(musician));

            AlbumsTableAdapter AT = new AlbumsTableAdapter();
            EnumerableRowCollection<musicDataSet.AlbumsRow> albumsList;
            if (song.Equals(""))
                albumsList = AT.GetData().Where(Q => true);
            else
                albumsList = AT.GetData().Where(Q => Q.ReleaseYear == Int32.Parse(year));

            UserRatingsTableAdapter RT = new UserRatingsTableAdapter();
            EnumerableRowCollection<musicDataSet.UserRatingsRow> ratingsList;
            if (rating.Equals("Any"))
                ratingsList = RT.GetData().Where(Q => true);
            else
                ratingsList = RT.GetData().Where(Q => Q.Rating == Int32.Parse(rating) && Q.UserID == UserID);


            //var asdfs =
            //    from s in songsList
            //    from a in albumsList
            //    from g in genresList
            //    from m in musicianList
            //    from r in ratingsList
            //    where 
            //        s.AlbumID == a.AlbumID &&
            //        g.GenreID == a.GenreID &&
            //        m.MusicianID == a.MusicianID &&
            //        r.SongID == s.SongID
            //    select new QueryResult()
            //    {
            //        SongName = s.SongName,
            //        MusicianName = m.MusicianName,
            //        AlbumName = a.AlbumName,
            //        GenreName = g.GenreName,
            //        ReleaseYear = a.ReleaseYear,
            //        Rating = r.Rating
            //    };

            //TODO IMPLIMENT temp 0 for userID

            var temp1 =
                from s in songsList
                from r in ratingsList
                where s.SongID == r.SongID
                select new
                {
                    s.SongName,
                    s.AlbumID,
                    r.Rating,
                    s.SongID
                };
            var temp2 =
                from q in temp1
                from a in albumsList
                where q.AlbumID == a.AlbumID
                select new
                {
                    q.SongName,
                    q.Rating,
                    a.AlbumName,
                    a.ReleaseYear,
                    a.GenreID,
                    a.MusicianID
                };
            var temp3 =
                from q in temp2
                from g in genresList
                where q.GenreID == g.GenreID
                select new
                {
                    q.SongName,
                    q.Rating,
                    q.AlbumName,
                    q.ReleaseYear,
                    g.GenreName,
                    q.MusicianID
                };
            var temp4 =
                from q in temp3
                from m in musicianList
                where q.MusicianID == m.MusicianID
                select new
                {
                    SongName = q.SongName,
                    Rating = q.Rating,
                    AlbumName = q.AlbumName,
                    ReleaseYear = q.ReleaseYear,
                    GenreName = q.GenreName,
                    MusicianName = m.MusicianName
                };

            Resutls_Table.ItemsSource = temp4;
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            baseWindow.OverrideBorder.Child = new SearchMusic(baseWindow, UserID);
        }

        //TODO Hook up edit button
        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            baseWindow.OverrideBorder.Child = new UserEditSong(baseWindow, this, UserID, 7);
        }
    }
}
