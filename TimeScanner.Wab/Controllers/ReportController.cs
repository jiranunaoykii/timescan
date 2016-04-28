using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeScanner.DSA.EF;
using TimeScanner.Wab.Helpers;
using TimeScanner.Wab.ViewModels;

namespace TimeScanner.Wab.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private TimeScannerDBContainer db = new TimeScannerDBContainer();

        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Daily()
        {
            var date = DateTime.Today;
            var employeeSet = db.EmployeeSet.ToList();
            var absenceSet = db.AbsenceSet.ToList();
            var timeScanSet = db.TimeScanSet.ToList();
            var dailyReport = new List<DailyReport>();
            var selectedAbsence = new Absence();
            var selectedTimeScan = new TimeScan();
            foreach (var emp in employeeSet)
            {
                selectedAbsence = absenceSet.Where(it => it.EmployeeId == emp.Id && it.AbsenceDate.Day == date.Day && it.AbsenceDate.Month == date.Month && it.AbsenceDate.Year == date.Year).FirstOrDefault();
                if (selectedAbsence != null)
                {
                    dailyReport.Add(new DailyReport
                    {
                        EmployeeCode = emp.EmployeeCode,
                        TitleName = emp.TitleName,
                        FirstName = emp.FirstName,
                        LastName = emp.LastName,
                        PID = emp.PID,
                        IsAbsence = true,
                        Remark = selectedAbsence.Remark,
                        SearchDate = date
                    });
                }
                else
                {
                    selectedTimeScan = timeScanSet.Where(it => it.EmployeeId == emp.Id && (it.TimeIn.HasValue && it.TimeIn.Value.Day == date.Day && it.TimeIn.Value.Month == date.Month && it.TimeIn.Value.Year == date.Year)
                    || (it.TimeOut.HasValue && it.TimeOut.Value.Day == date.Day && it.TimeOut.Value.Month == date.Month && it.TimeOut.Value.Year == date.Year)).FirstOrDefault();
                    if (selectedTimeScan != null)
                    {
                        dailyReport.Add(new DailyReport
                        {
                            EmployeeCode = emp.EmployeeCode,
                            TitleName = emp.TitleName,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            PID = emp.PID,
                            TimeIn = selectedTimeScan.TimeIn,
                            TimeOut = selectedTimeScan.TimeOut,
                            IsAbsence = false,
                            SearchDate = date
                        });
                    }
                    else
                    {
                        dailyReport.Add(new DailyReport
                        {
                            EmployeeCode = emp.EmployeeCode,
                            TitleName = emp.TitleName,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            PID = emp.PID,
                            SearchDate = date
                        });
                    }
                }
            }
            return View(dailyReport.OrderBy(it => it.TimeIn));
        }

        [HttpPost]
        public ActionResult Daily(DateTime day)
        {
            if (day == null) RedirectToAction("Daily");
            var date = DateHelper.GetDate(day);
            var employeeSet = db.EmployeeSet.ToList();
            var absenceSet = db.AbsenceSet.ToList();
            var timeScanSet = db.TimeScanSet.ToList();
            var dailyReport = new List<DailyReport>();
            var selectedAbsence = new Absence();
            var selectedTimeScan = new TimeScan();
            foreach (var emp in employeeSet)
            {
                selectedAbsence = absenceSet.Where(it => it.EmployeeId == emp.Id && it.AbsenceDate.Day == date.Day && it.AbsenceDate.Month == date.Month && it.AbsenceDate.Year == date.Year).FirstOrDefault();
                if (selectedAbsence != null)
                {
                    dailyReport.Add(new DailyReport
                    {
                        EmployeeCode = emp.EmployeeCode,
                        TitleName = emp.TitleName,
                        FirstName = emp.FirstName,
                        LastName = emp.LastName,
                        PID = emp.PID,
                        IsAbsence = true,
                        Remark = selectedAbsence.Remark,
                        SearchDate = day
                    });
                }
                else
                {
                    selectedTimeScan = timeScanSet.Where(it => it.EmployeeId == emp.Id && ((it.TimeIn.HasValue && it.TimeIn.Value.Day == date.Day && it.TimeIn.Value.Month == date.Month && it.TimeIn.Value.Year == date.Year)
                    || (it.TimeOut.HasValue && it.TimeOut.Value.Day == date.Day && it.TimeOut.Value.Month == date.Month && it.TimeOut.Value.Year == date.Year))).FirstOrDefault();
                    if (selectedTimeScan != null)
                    {
                        dailyReport.Add(new DailyReport
                        {
                            EmployeeCode = emp.EmployeeCode,
                            TitleName = emp.TitleName,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            PID = emp.PID,
                            TimeIn = selectedTimeScan.TimeIn,
                            TimeOut = selectedTimeScan.TimeOut,
                            IsAbsence = false,
                            SearchDate = day
                        });
                    }
                    else
                    {
                        dailyReport.Add(new DailyReport
                        {
                            EmployeeCode = emp.EmployeeCode,
                            TitleName = emp.TitleName,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            PID = emp.PID,
                            SearchDate = day
                        });
                    }
                }
            }
            return View(dailyReport.OrderBy(it => it.TimeIn));
        }


        public ActionResult Monthly(string id, int? month, int? year)
        {
            if(id == null || month == null || year == null) return View(new List<DailyReport>());
            if(year > 2500) year -= 543;
            var dayOfMonth = GetDates(year.Value, month.Value);
            var emp = db.EmployeeSet.FirstOrDefault(it => it.EmployeeCode == id);
            if(emp == null) return View(new List<DailyReport>());
            var absenceSet = db.AbsenceSet.ToList();
            var timeScanSet = db.TimeScanSet.ToList();
            var dailyReport = new List<DailyReport>();
            var selectedAbsence = new Absence();
            var selectedTimeScan = new TimeScan();
            foreach (var day in dayOfMonth.Where(it => it.DayOfWeek != DayOfWeek.Sunday && it.DayOfWeek != DayOfWeek.Saturday))
            {
                selectedAbsence = absenceSet.Where(it => it.EmployeeId == emp.Id && it.AbsenceDate.Day == day.Day && it.AbsenceDate.Month == day.Month && it.AbsenceDate.Year == day.Year).FirstOrDefault();
                if (selectedAbsence != null)
                {
                    dailyReport.Add(new DailyReport
                    {
                        EmployeeCode = emp.EmployeeCode,
                        TitleName = emp.TitleName,
                        FirstName = emp.FirstName,
                        LastName = emp.LastName,
                        PID = emp.PID,
                        IsAbsence = true,
                        Remark = selectedAbsence.Remark,
                        SearchDate = day
                    });
                }
                else
                {
                    selectedTimeScan = timeScanSet.Where(it => it.EmployeeId == emp.Id && (it.TimeIn.HasValue && it.TimeIn.Value.Day == day.Day && it.TimeIn.HasValue && it.TimeIn.Value.Month == day.Month && it.TimeIn.Value.Year == day.Year)
                    || (it.TimeOut.HasValue &&  it.TimeOut.Value.Day == day.Day &&  it.TimeOut.Value.Month == day.Month && it.TimeOut.Value.Year == day.Year)).FirstOrDefault();
                    if (selectedTimeScan != null)
                    {
                        dailyReport.Add(new DailyReport
                        {
                            EmployeeCode = emp.EmployeeCode,
                            TitleName = emp.TitleName,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            PID = emp.PID,
                            TimeIn = selectedTimeScan.TimeIn,
                            TimeOut = selectedTimeScan.TimeOut,
                            IsAbsence = false,
                            SearchDate = day
                        });
                    }
                    else
                    {
                        dailyReport.Add(new DailyReport
                        {
                            EmployeeCode = emp.EmployeeCode,
                            TitleName = emp.TitleName,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            PID = emp.PID,
                            SearchDate = day
                        });
                    }
                }
            }
            
            return View(dailyReport.OrderBy(it => it.TimeIn));
        }

        private List<DateTime> GetDates(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))  // Days: 1, 2 ... 31 etc.
                             .Select(day => new DateTime(year, month, day)) // Map each day to a date
                             .ToList(); // Load dates into a list
        }
    }
}