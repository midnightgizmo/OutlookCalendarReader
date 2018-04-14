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
    /// Interaction logic for FilesListView.xaml
    /// </summary>
    public partial class FilesListView : UserControl
    {
        public delegate void FileSelectedDelegate(Models.CalendarFile selectedFile);
        public event FileSelectedDelegate FileSelected;

        public FilesListView()
        {
            InitializeComponent();
        }

        private void cmdFile_Click(object sender, RoutedEventArgs e)
        {
            Models.CalendarFile aFile = (Models.CalendarFile)((Button)sender).Tag;

            FileSelected?.Invoke(aFile);
        }
    }
}
