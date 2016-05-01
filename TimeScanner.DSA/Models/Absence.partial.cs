using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeScanner.DSA.EF
{
    [MetadataType(typeof(MD))]
    partial class Absence
    {
        private class MD
        {
            public int Id { get; set; }
            [Display(Name = "วันที่ลา")]
            public System.DateTime AbsenceDate { get; set; }
            [Display(Name = "เอกสาร")]
            public string Document { get; set; }
            [Display(Name = "หมายเหตุ")]
            public string Remark { get; set; }
            
            public int EmployeeId { get; set; }

            public virtual Employee Employee { get; set; }
        }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
