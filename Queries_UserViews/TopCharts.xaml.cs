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
using System.Xml.Linq;
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


        public TopCharts(UserMainView main, int userID, string userName)
        {
            InitializeComponent();
            baseWindow = main;
            UserID = userID;

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //baseWindow.OverrideBorder.Child = new UserMainView(baseWindow, UserID, "");
        }
    }
}
