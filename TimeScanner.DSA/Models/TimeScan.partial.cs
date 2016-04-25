using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeScanner.DSA.EF
{
    [MetadataType(typeof(MD))]
    partial class TimeScan
    {
        private class MD
        {
            public int Id { get; set; }
            public Nullable<System.DateTime> TimeIn { get; set; }
            public Nullable<System.DateTime> TimeOut { get; set; }
            public int EmployeeId { get; set; }

            public virtual Employee Employee { get; set; }
        }
        public string Status { get; set; }
    }
}
