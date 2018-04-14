using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarDisplayer.Models
{
    class CalendarItem : INotifyPropertyChanged
    {
        // setting PropertyChanged to an empty delegate means we don't have to keep
        // checking later on if it is null

        public event PropertyChangedEventHandler PropertyChanged = delegate { };


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

        public static List<CalendarItem> DeserializeJsonString(string jsonString)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<CalendarItem>>(jsonString);
        }

        
        private DateTime _Start;
        public DateTime Start
        {
            get
            {
                return _Start;
            }
            set
            {
                _Start = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(Start)));
            }
        }

        private DateTime _End;
        public DateTime End
        {
            get
            {
                return _End;
            }
            set
            {
                _End = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(End)));
            }
        }

        private string _Subject;
        public string Subject
        {
            get
            {
                return _Subject;
            }
            set
            {
                _Subject = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(Subject)));
            }
        }

        private string _Location;
        public string Location
        {
            get
            {
                return _Location;
            }
            set
            {
                _Location = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(Location)));

            }
        }

        private string _Body;
        public string Body
        {
            get
            {
                return _Body;
            }
            set
            {
                _Body = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(Body)));
            }
        }


    }
}
