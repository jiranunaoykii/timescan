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
            [Display(Name = "เข้างาน")]
            public Nullable<System.DateTime> TimeIn { get; set; }
            [Display(Name = "ออกงาน")]
            public Nullable<System.DateTime> TimeOut { get; set; }
            [Display(Name = "รหัสพนักงาน")]
            public int EmployeeId { get; set; }

            public virtual Employee Employee { get; set; }
        }
        [Display(Name = "สถานะ")]
        public string Status { get; set; }
    }
}
