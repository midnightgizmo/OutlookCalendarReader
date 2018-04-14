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

namespace CalendarDisplayer.Views
{
    /// <summary>
    /// Interaction logic for CalendarListView.xaml
    /// </summary>
    public partial class CalendarListView : UserControl
    {
        public CalendarListView()
        {
            InitializeComponent();
        }

        private void Row_Click(object sender, RoutedEventArgs e)
        {
            tbDescription.Text = ((Models.CalendarItem)((Button)sender).Tag).Body;
        }

        private void Grid_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            tbDescription.Text = ((Models.CalendarItem)((Grid)sender).Tag).Body;
        }

        private void TextBlock_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            tbDescription.Text = ((Models.CalendarItem)((Grid)sender).Tag).Body;
        }
    }
}
