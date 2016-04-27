using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TimeScanner.DSA.EF;
using TimeScanner.Wab.Helpers;

namespace TimeScanner.Wab.Controllers
{
    public class CalendarsController : Controller
    {
        private TimeScannerDBContainer db = new TimeScannerDBContainer();

        // GET: Calendars
        public ActionResult Index(string id)
        {
            var now = id == null ? DateTime.Now : DateTime.Parse(id);
            var currentdayofmonth = GetDates(now.Year, now.Month);
            var previousmonth = currentdayofmonth.First().AddDays((int)currentdayofmonth.First().DayOfWeek * -1);
            var diff = (42 - currentdayofmonth.Count()) - ((currentdayofmonth.First() - previousmonth).Days);
            var nextmonth = currentdayofmonth.Last().AddDays(diff);
            var result = genDates(previousmonth, nextmonth);
            var monthName = now.ToString("MMMM", System.Globalization.CultureInfo.CreateSpecificCulture("th")) + (now.Year + 543).ToString();
            var calendars = new ViewModels.Calendars() { PreviuosMonth = now.AddMonths(-1), NextMonth = now.AddMonths(1), MonthName = monthName};
            foreach (var date in result)
            {
                var dateFormated = DateHelper.GetDate(date);
                var selectedDate = db.CalendarSet.FirstOrDefault(it => it.IssueDate == dateFormated);
                var isDayInMonth = date.Month == now.Month;
                if (selectedDate != null)
                {                  
                    calendars.Days.Add(new ViewModels.DayofMonth
                    {
                        Date = date,
                        IsDayInMonth = isDayInMonth,
                        IsWorkingDay = selectedDate.IsWorkingDay,
                        Note = selectedDate.Note,
                        IsActivity = true
                    });
                }
                else
                {
                    calendars.Days.Add(new ViewModels.DayofMonth
                    {
                        Date = date,
                        IsDayInMonth = isDayInMonth,
                    });
                }
                
            }

            return View(calendars);
        }

        // GET: Calendars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calendar calendar = db.CalendarSet.Find(id);
            if (calendar == null)
            {
                return HttpNotFound();
            }
            return View(calendar);
        }

        // GET: Calendars/Create
        public ActionResult Create()
        {
            return View(new TimeScanner.Wab.ViewModels.Calendar
            {
                IssueDate = DateTime.Now,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
            });
        }

        // POST: Calendars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TimeScanner.Wab.ViewModels.Calendar calendar)
        {
            
                db.CalendarSet.Add(new Calendar
                {
                     Activity = calendar.Activity,
                     IssueDate = DateHelper.GetDate(calendar.IssueDate),
                     IsWorkingDay = calendar.IsWorkingDay == "ทำงาน" ? true : false,
                     Note = calendar.Note,
                     StartTime = new DateTime(calendar.StartTime.Year, calendar.StartTime.Month, calendar.StartTime.Day, calendar.StartTime.Hour, calendar.StartTime.Minute, calendar.StartTime.Second),
                     EndTime = new DateTime(calendar.EndTime.Year, calendar.EndTime.Month, calendar.EndTime.Day, calendar.EndTime.Hour, calendar.EndTime.Minute, calendar.EndTime.Second),
                });
                db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Calendars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calendar calendar = db.CalendarSet.Find(id);
            if (calendar == null)
            {
                return HttpNotFound();
            }
            return View(calendar);
        }

        // POST: Calendars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IssueDate,Activity,StartTime,EndTime")] Calendar calendar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calendar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(calendar);
        }

        // GET: Calendars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calendar calendar = db.CalendarSet.Find(id);
            if (calendar == null)
            {
                return HttpNotFound();
            }
            return View(calendar);
        }

        // POST: Calendars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calendar calendar = db.CalendarSet.Find(id);
            db.CalendarSet.Remove(calendar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private List<DateTime> GetDates(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))  // Days: 1, 2 ... 31 etc.
                             .Select(day => new DateTime(year, month, day)) // Map each day to a date
                             .ToList(); // Load dates into a list
        }

        private List<DateTime> genDates(DateTime start, DateTime end)
        {
            return Enumerable.Range(0, 1 + end.Subtract(start).Days)
           .Select(offset => start.AddDays(offset))
           .ToList();
        }
    }
}
