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
    /// Interaction logic for Provider_Creation.xaml
    /// </summary>
    public partial class Provider_Creation : UserControl
    {
        public Provider_Creation()
        {
            InitializeComponent();
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            ProvidersTableAdapter PT = new ProvidersTableAdapter();
            PT.Insert(ProviderText.Text, URLText.Text);
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            //baseWindow.OverrideBorder.Child = null;
        }
    }
}
