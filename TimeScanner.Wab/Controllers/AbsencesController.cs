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
    public class AbsencesController : Controller
    {
        private TimeScannerDBContainer db = new TimeScannerDBContainer();

        // GET: Absences
        public ActionResult Index()
        {
            var date = DateTime.Today;
            var absenceSet = db.AbsenceSet.ToList().Where(x => x.AbsenceDate.Date == date);
            return View(absenceSet.ToList());
        }

        [HttpPost]
        public ActionResult Index(int day, int month, int year)
        {
            var date = DateHelper.GetDate(new DateTime(year, month, day));
            var absenceSet = db.AbsenceSet.ToList().Where(x => x.AbsenceDate.Date == date);
            return View(absenceSet.ToList());
        }

        // GET: Absences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Absence absence = db.AbsenceSet.Find(id);
            if (absence == null)
            {
                return HttpNotFound();
            }
            return View(absence);
        }

        // GET: Absences/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.EmployeeSet, "Id", "EmployeeCode");
            return View(new Absence()
            {
                Employees = db.EmployeeSet.ToList(),
            });
        }

        // POST: Absences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AbsenceDate,Document,Remark,EmployeeId")] Absence absence, int day, int month, int year, HttpPostedFileBase document)
        {
            if (ModelState.IsValid)
            {
                if (document != null)
                {
                    document.SaveAs(System.IO.Path.Combine(@"C:\inetpub\wwwroot\Documents", System.IO.Path.GetFileName(document.FileName)));
                    absence.Document = System.IO.Path.GetFileName(document.FileName);
                }
                absence.AbsenceDate = DateHelper.GetDate(new DateTime(year, month, day));

                db.AbsenceSet.Add(absence);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.EmployeeSet, "Id", "EmployeeCode", absence.EmployeeId);
            ViewBag.Name = db.EmployeeSet.Find(absence.EmployeeId).FullName;
            absence.Employees = db.EmployeeSet.ToList();
            return View(absence);
        }

        // GET: Absences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Absence absence = db.AbsenceSet.Find(id);
            if (absence == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.EmployeeSet, "Id", "EmployeeCode", absence.EmployeeId);
            ViewBag.Name = db.EmployeeSet.Find(absence.EmployeeId).FullName;
            absence.Employees = db.EmployeeSet.ToList();
            return View(absence);
        }

        // POST: Absences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AbsenceDate,Document,Remark,EmployeeId")] Absence absence, int day, int month, int year, HttpPostedFileBase document)
        {
            if (ModelState.IsValid)
            {
                var abs = db.AbsenceSet.Find(absence.Id);
                if (document != null)
                {
                    document.SaveAs(System.IO.Path.Combine(@"C:\inetpub\wwwroot\Documents", System.IO.Path.GetFileName(document.FileName)));
                    abs.Document = System.IO.Path.GetFileName(document.FileName);
                }
                else
                {
                    abs.Document = abs.Document;
                }
                abs.AbsenceDate = DateHelper.GetDate(new DateTime(year, month, day));
                abs.Employee = db.EmployeeSet.Find(absence.EmployeeId);
                abs.Remark = absence.Remark;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.EmployeeSet, "Id", "EmployeeCode", absence.EmployeeId);
            ViewBag.Name = db.EmployeeSet.Find(absence.EmployeeId).FullName;
            absence.Employees = db.EmployeeSet.ToList();
            return View(absence);
        }

        // GET: Absences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Absence absence = db.AbsenceSet.Find(id);
            if (absence == null)
            {
                return HttpNotFound();
            }
            return View(absence);
        }

        // POST: Absences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Absence absence = db.AbsenceSet.Find(id);
            db.AbsenceSet.Remove(absence);
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
    }
}
