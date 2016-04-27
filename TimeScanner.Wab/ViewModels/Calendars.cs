using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeScanner.Wab.ViewModels
{
    public class Calendars
    {
        public Calendars()
        {
            Days = new List<DayofMonth>();
        }

        public string MonthName { get; set; }
        public DateTime PreviuosMonth { get; set; }
        public DateTime NextMonth { get; set; }
        public IList<DayofMonth> Days { get; set; }
    }
    public class DayofMonth
    {
        public bool IsActivity { get; set; }
        public bool IsWorkingDay { get; set; }
        public bool IsDayInMonth { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
    }
}
