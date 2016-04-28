using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeScanner.Wab.ViewModels
{
    public class DailyReport
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
        [Display(Name = "เข้างาน")]
        public Nullable<System.DateTime> TimeIn { get; set; }
        [Display(Name = "ออกงาน")]
        public Nullable<System.DateTime> TimeOut { get; set; }       
        [Display(Name = "หมายเหตุ")]
        public string Remark { get; set; }
        [Display(Name = "สถานะ")]
        public bool IsAbsence { get; set; }


        public DateTime SearchDate { get; set; }

        public string Status { get
            {
                if (IsAbsence )
                {
                    return "ลา";
                }
                else
                {
                    if (TimeIn.HasValue == false && TimeOut.HasValue == false)
                    {
                        return SearchDate.Date >= DateTime.Today.Date ? "" : "ขาด";
                    }
                    else if (TimeIn.HasValue == true && TimeOut.HasValue == true)
                    {
                        return "ปกติ";
                    }
                    else return "ไม่แสกนบัตร";                    
                }
            }}


        public string FullName
        {
            get
            {
                return string.Format("{0}{1} {2}", TitleName, FirstName, LastName);
            }
        }
    }
}
