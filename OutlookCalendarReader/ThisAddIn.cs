using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace OutlookCalendarReader
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            // the dates we want to search between to get appointments
            DateTime EndDate = DateTime.Now;// this will be the date when outlook opens up
            DateTime StartDate = EndDate.Subtract(new TimeSpan(30, 0, 0, 0)); ;
            
            

            // a wrapper class to hold the microsoft outlook class
            Models.Outlook myOutlook = new Models.Outlook(GetCalendar());

            // find all appointments between StartDate and EndDate
            Outlook.Items FilterdItems = myOutlook.GetAppointmentsBetween(StartDate,EndDate);

            // a class that converts the Microsoft Outlook appointments to Models.CalendarItem class
            ViewModels.CalendarAppointmentsConverter converter = new ViewModels.CalendarAppointmentsConverter();

            // convert all the appointments found in the date rage to a list of Models.CalendarItem
            List<Models.CalendarItem> AppointmentList = converter.ConvertAppointments(FilterdItems);


            #region Saveing and converting to json

            // find the location where we want to save the data too.
            // Saves it to a folder called CalendarEvents in the Users My Documents Folder
            string folderLocation = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Outlook Calendar backups");
            // create the file name. e.g. "CalendarEvents 2018-04-05 13.05 03.json"
            string fileName = "CalendarEvents " + DateTime.Now.ToString("yyyy-MM-dd HH.mm ss") + ".json";
            // convert the list of appointments to a json string
            string fileContent = Newtonsoft.Json.JsonConvert.SerializeObject(AppointmentList);

            // make sure the folder we are saving too exists
            if (!System.IO.Directory.Exists(folderLocation))
                System.IO.Directory.CreateDirectory(folderLocation); // folder does not exist so create it

            // create the file and save all the json data to it.
            System.IO.File.WriteAllText(System.IO.Path.Combine(folderLocation, fileName), fileContent);
            #endregion


        }

        

        private Outlook.MAPIFolder GetCalendar()
        {
            Outlook.MAPIFolder calendar = this.Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar);
            return calendar;
        }
        

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
