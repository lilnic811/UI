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
using UI.Queries_UserViews;

namespace UI
{
    /// <summary>
    /// Interaction logic for SearchMusic.xaml
    /// </summary>
    public partial class SearchMusic : UserControl
    {
        UserMainView baseWindow;
        int UserID;

        public SearchMusic(UserMainView main, int userID)
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

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            baseWindow.OverrideBorder.Child = null;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TopChartsButton_Click(object sender, RoutedEventArgs e)
        {
            baseWindow.OverrideBorder.Child = new TopCharts(baseWindow, UserID);
        }
    }
}
