using System.Collections.Generic;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookCalendarReader.ViewModels
{
    public class CalendarAppointmentsConverter
    {
        public CalendarAppointmentsConverter()
        {
            
        }
        /// <summary>
        /// Convert Outlook.AppointmentItem to Models.CalendarItem
        /// </summary>
        /// <param name="CalendarItems"></param>
        /// <returns>Returns the converted appointments as a list</returns>
        public List<Models.CalendarItem> ConvertAppointments(Outlook.Items CalendarItems)
        {
            List<Models.CalendarItem> AppointmentList = new List<Models.CalendarItem>();

            foreach (Outlook.AppointmentItem anItem in CalendarItems)
            {
                Models.CalendarItem appointment = new Models.CalendarItem(
                                            anItem.Start, anItem.End,
                                            anItem.Subject, anItem.Location,
                                            anItem.Body);

                AppointmentList.Add(appointment);
            }

            return AppointmentList;
        }
    }
}
