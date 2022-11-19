using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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
    /// Interaction logic for Musicians_Creation.xaml
    /// </summary>
    public partial class Musicians_Creation : UserControl
    {
        AdminHomePage baseWindow;

        public Musicians_Creation(AdminHomePage main)
        {
            baseWindow = main;
            InitializeComponent();
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            MusiciansTableAdapter MT = new MusiciansTableAdapter();
            MT.Insert(ArtistText.Text);
        }
        
        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            baseWindow.OverrideBorder.Child = null;
        }
    }
}
