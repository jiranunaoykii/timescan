using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeScanner.DSA.EF;

namespace TimeScanner.Wab.Controllers
{
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
            var employeeSet = db.EmployeeSet;
            foreach (var item in employeeSet)
            {
                var ts = db.TimeScanSet.Where(x => x.EmployeeId == item.Id).ToList().Where(x => ((x.TimeIn.HasValue && x.TimeIn.Value.Date == date) || (x.TimeOut.HasValue && x.TimeOut.Value.Date == date)));
                item.TimeScan = ts.Any() ? ts.FirstOrDefault() : new TimeScan();

                var abs = db.AbsenceSet.Where(x => x.EmployeeId == item.Id).ToList().Where(x => x.AbsenceDate.Date == date);
                item.Absence = abs.Any() ? abs.FirstOrDefault() : new Absence();
            }
            return View(employeeSet.ToList());
        }

        [HttpPost]
        public ActionResult Daily(int day, int month, int year)
        {
            var date = new DateTime(year - 543, month, day);
            var employeeSet = db.EmployeeSet;
            foreach (var item in employeeSet)
            {
                var ts = db.TimeScanSet.Where(x => x.EmployeeId == item.Id).ToList().Where(x => ((x.TimeIn.HasValue && x.TimeIn.Value.Date == date) || (x.TimeOut.HasValue && x.TimeOut.Value.Date == date)));
                item.TimeScan = ts.Any() ? ts.FirstOrDefault() : new TimeScan();

                var abs = db.AbsenceSet.Where(x => x.EmployeeId == item.Id).ToList().Where(x => x.AbsenceDate.Date == date);
                item.Absence = abs.Any() ? abs.FirstOrDefault() : new Absence();
            }
            return View(employeeSet.ToList());
        }

        public ActionResult Monthly(int? id)
        {
            if (!id.HasValue)
            {
                var emp = db.EmployeeSet.FirstOrDefault();
                if (emp != null)
                {
                    id = emp.Id;
                }
                else
                {
                    return RedirectToAction("index");
                }
            }

            var employee = db.EmployeeSet.Find(id.Value);
            var date = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            var ts = db.TimeScanSet.Where(x => x.EmployeeId == employee.Id).ToList().Where(x => ((x.TimeIn.HasValue && x.TimeIn.Value.Date >= date && x.TimeIn.Value.Date < date.AddMonths(1))
                || (x.TimeOut.HasValue && x.TimeOut.Value.Date >= date && x.TimeOut.Value.Date < date.AddMonths(1)))).ToList(); ;
            var ts2 = Enumerable.Range(1, DateTime.Today.Day).Select(x =>
            {
                var item = ts.FirstOrDefault(xx => (xx.TimeIn.HasValue && xx.TimeIn.Value.Day == x) || (xx.TimeOut.HasValue && xx.TimeOut.Value.Day == x));
                if (item == null)
                {
                    return new TimeScan();
                }
                return item;
            }).ToList();

            var abs = db.AbsenceSet.Where(x => x.EmployeeId == employee.Id).ToList().Where(x => x.AbsenceDate.Date >= date && x.AbsenceDate.Date < date.AddMonths(1));
            var abs2 = Enumerable.Range(1, DateTime.Today.Day).Select(x => abs.FirstOrDefault(xx => xx.AbsenceDate.Day == x));

            employee.Absemces = abs2.ToList();
            int i = 0;
            foreach (var item in ts2)
            {
                item.Status += item.TimeIn.HasValue ? "" : "[ไม่มีเวลาเข้างาน]";
                item.Status += item.TimeOut.HasValue ? "" : "[ไม่มีเวลาออกงาน]";
                item.Status += abs2.ElementAt(i) == null ? "" : "[ลางาน]";
                item.Status += abs2.ElementAt(i) == null && item.TimeIn.HasValue ? "" : "[ขาด]";
                i++;
            }
            employee.TimeScans = ts2.ToList();
            return View(employee);
        }
    }
}