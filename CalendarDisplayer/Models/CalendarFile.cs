using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarDisplayer.Models
{
    public class CalendarFile
    {

        public string FileName { get; set; } // just the file name (no path)
        public string FileLocation { get; set; } // the location of the file and its path

        public CalendarFile()
        {
            _FileContent = string.Empty;
        }

        public CalendarFile(string fileNameAndLocation)
        {
            this.FileName = System.IO.Path.GetFileName(fileNameAndLocation);
            this.FileLocation = fileNameAndLocation;
        }

        public static List<CalendarFile> FindAllFilesOnDisk()
        {
            List<CalendarFile> ListOfFiles = new List<CalendarFile>();
            string folderLocation = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Outlook Calendar backups");

            // if we can't find the folder the files should be in, return a blank list
            if (!System.IO.Directory.Exists(folderLocation))
                return ListOfFiles;

            string[] fileNames = System.IO.Directory.GetFiles(folderLocation, "*.json");
            foreach(string aFile in fileNames)
                ListOfFiles.Add(new CalendarFile(aFile));

            return ListOfFiles;
            
        }

        private string _FileContent;

        public string FileContent
        {
            get
            {
                if (_FileContent == null)
                    LoadFileFromDisk(FileLocation);
                return _FileContent;
            }
            set
            {
                _FileContent = value;
            }
        }

        private void LoadFileFromDisk(string fileLocation)
        {
            if(System.IO.File.Exists(fileLocation))
                _FileContent = System.IO.File.ReadAllText(fileLocation);
        }
    }
}
