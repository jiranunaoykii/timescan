using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeScanner.Wab.ViewModels
{
    public partial class Calendar
    {
        public int Id { get; set; }

        [DisplayName("วันที่")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime IssueDate { get; set; }

        [DisplayName("กิจกรรม")]
        public string Activity { get; set; }

        [DisplayName("หมายเหตุ")]
        public string Note { get; set; }

        [DisplayName("เวลาเริ่ม")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public System.DateTime StartTime { get; set; }

        [DisplayName("เวลาสิ้นสุด")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public System.DateTime EndTime { get; set; }

        [DisplayName("การทำงาน")]
        public string IsWorkingDay { get; set; }
    }
}
