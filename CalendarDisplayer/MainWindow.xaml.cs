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

namespace CalendarDisplayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Models.CalendarFile> _ListOfFiles;
        private Models.CalendarItem _SelectedCalendarItem;

        private Views.FilesListView viewFileList;
        public MainWindow()
        {
            InitializeComponent();

            viewFileList = new Views.FilesListView();
            viewFileList.FileSelected += delegate (Models.CalendarFile aFile)
            {
                Views.CalendarListView calendarList = new Views.CalendarListView();
                calendarList.DataContext = Models.CalendarItem.DeserializeJsonString(aFile.FileContent);

                CalendarResultsContainer.Children.Clear();
                CalendarResultsContainer.Children.Add(calendarList);

            };
            

            _ListOfFiles = Models.CalendarFile.FindAllFilesOnDisk();
            viewFileList.DataContext = _ListOfFiles;

            _SelectedCalendarItem = null;
        }



        private void cmdShowFiles_Click(object sender, RoutedEventArgs e)
        {
            CalendarResultsContainer.Children.Clear();
            CalendarResultsContainer.Children.Add(viewFileList);
        }

        private void cmdShowAsList_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmdShowAsCalendar_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
