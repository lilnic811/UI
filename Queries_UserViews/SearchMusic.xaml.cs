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

namespace UI
{
    /// <summary>
    /// Interaction logic for SearchMusic.xaml
    /// </summary>
    public partial class SearchMusic : UserControl
    {
        AdminHomePage baseWindow;
        int UserID;

        public SearchMusic(AdminHomePage main, int userID)
        {
            baseWindow = main;
            UserID = userID;
            InitializeComponent();

            GenreTableAdapter GT = new GenreTableAdapter();
            foreach(musicDataSet.GenreRow item in GT.GetData())
                GenreDropDown.Items.Add(item.GenreName);
        }
        /// <summary>
        /// resets the order
        /// </summary>
        /// <param name="sender">CancelOrderButton</param>
        /// <param name="e">click</param>
        public void OnSearchButtonClick(object sender, RoutedEventArgs e)
        {
            //baseWindow.OverrideBorder.Child = new SearchResults(baseWindow, UserID, "Psycho", "Rap", "50 Cent", "2009", "6");
            baseWindow.OverrideBorder.Child = new SearchResults(baseWindow, UserID, SongText.Text, GenreDropDown.Text, ArtistText.Text, YearText.Text, RatingDropDown.Text);
        }

        
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
