using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookCalendarReader.Models
{
    /// <summary>
    /// Holds all the data we want to save from an outlook calendar appointment
    /// </summary>
    public class CalendarItem
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }
        public string Body { get; set; }

        public CalendarItem(DateTime start, DateTime end, string subject, string location, string body)
        {
            Start = start;
            End = end;
            // I noticed during testing that some strings were coming back null from outlook.
            // To stop this from happening i return an empty string if null is found.
            Subject = subject == null ? "" : subject;
            Location = location == null ? "" : location;
            Body = body == null ? "" : body;
            
        }

    }
}
