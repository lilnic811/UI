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
using UI.musicDataSetTableAdapters;

namespace UI.Tables
{
    /// <summary>
    /// Interaction logic for Genre.xaml
    /// </summary>
    public partial class Genre : UserControl
    {
        MainWindow baseWindow;

        public Genre(MainWindow main)
        {
            baseWindow = main;
            InitializeComponent();
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            GenreTableAdapter GT = new GenreTableAdapter();
            GT.Insert(GenreText.Text);
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            //baseWindow.OverrideBorder.Child = null;
        }
    }
}
