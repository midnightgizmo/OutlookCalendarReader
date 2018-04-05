using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace OutlookCalendarReader.Models
{
    /// <summary>
    /// A wrapper class to hold the Microsoft outlook.
    /// </summary>
    public class Outlook
    {
        public Microsoft.Office.Interop.Outlook.MAPIFolder MicrosoftOutlook { get; set; }

        public Outlook(Microsoft.Office.Interop.Outlook.MAPIFolder microsoftOutlook)
        {
            MicrosoftOutlook = microsoftOutlook;
        }

        // returns a list of appointments between startDate and EndDate
        public Microsoft.Office.Interop.Outlook.Items GetAppointmentsBetween(DateTime StartDate, DateTime EndDate)
        {
            string filter;

            filter = "[Start] >= '" + StartDate.ToString("dd/MM/yyyy") + "' and [End] <= '" + EndDate.ToString("dd/MM/yyyy") + "'";

            return MicrosoftOutlook.Items.Restrict(filter);
        }
        
    }
}
