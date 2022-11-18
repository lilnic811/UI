using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace UI.Tables
{
    /// <summary>
    /// Interaction logic for Album.xaml
    /// </summary>
    public partial class Album : UserControl
    {
        MainWindow baseWindow;

        public Album(MainWindow main)
        {
            baseWindow = main;
            InitializeComponent();

            MusiciansTableAdapter MT = new MusiciansTableAdapter();
            foreach (musicDataSet.MusiciansRow item in MT.GetData())
                GenreBox.Items.Add(item.MusicianName);

            GenreTableAdapter GT = new GenreTableAdapter();
            foreach (musicDataSet.GenreRow item in GT.GetData())
                GenreBox.Items.Add(item.GenreName);
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            MusiciansTableAdapter MT = new MusiciansTableAdapter();
            var artist = MT.GetData().Where(Q => Q.MusicianName == ArtistBox.Text).Min();

            GenreTableAdapter GT = new GenreTableAdapter();
            var genre = GT.GetData().Where(Q => Q.GenreName == GenreBox.Text).Min();

            AlbumsTableAdapter AT = new AlbumsTableAdapter();
            AT.Insert(AlbumText.Text, artist.MusicianID, Int32.Parse(YearText.Text), genre.GenreID);
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            //baseWindow.OverrideBorder.Child = null;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
