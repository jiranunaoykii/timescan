using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeScanner.DSA.EF
{
    [MetadataType(typeof(MD))]
    partial class Employee
    {
        private class MD
        {
            public int Id { get; set; }
            [Display(Name = "รหัสพนักงาน")]
            public string EmployeeCode { get; set; }
            [Display(Name = "รหัสประจำตัวประชาชน")]
            public string PID { get; set; }
            [Display(Name = "คำนำหน้า")]
            public string TitleName { get; set; }
            [Display(Name = "ชื่อ")]
            public string FirstName { get; set; }
            [Display(Name = "สกุล")]
            public string LastName { get; set; }
            [Display(Name = "ตำแหน่ง")]
            public string Position { get; set; }
            [Display(Name = "อีเมล์")]
            public string Email { get; set; }
            [Display(Name = "โทร")]
            public string Tel { get; set; }
           

        }

        public string FullName
        {
            get
            {
                return string.Format("{0}{1} {2}", TitleName, FirstName, LastName);
            }
        }

        public Absence Absence { get; set; }
        public TimeScan TimeScan { get; set; }
    }
}
