using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeScanner.Wab.Helpers
{
    public static class DateHelper
    {
        public static DateTime GetDate(DateTime date)
        {
            var dateString = date.Month + "/" + date.Day + "/" + date.Year;
            System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("en-US");
            return DateTime.Parse(dateString, cultureinfo);
        }
    }
}
