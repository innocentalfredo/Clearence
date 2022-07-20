using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Clearence.Models.Entities;
using IdentitySample.Models;
using Rotativa;

namespace Clearence.Controllers.logic
{
    [Authorize]
    public class ClearenceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Clearence
        public ActionResult Index()
        {
            var clearences = db.Clearences.Include(c => c.Student);
            return View(clearences.ToList());
        }

        // GET: Clearence/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Entities.Clearence clearence = db.Clearences.Find(id);
            if (clearence == null)
            {
                return HttpNotFound();
            }
            return View(clearence);
        }

        // GET: Clearence/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            ViewBag.FullName = student.FirstName + " " + student.LastName;
            ViewBag.StudentId = new SelectList(db.Students, "Id", "RegistrationNumber",student.Id);
            return View();
        }

        // POST: Clearence/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentId,IsFinance,DeanOfStudent,IsRegistrar,Comment,ClearenceDate")] Models.Entities.Clearence clearence)
        {
            if (ModelState.IsValid)
            {
                Student student = db.Students.Find(clearence.StudentId);

           
                if (User.IsInRole("Registrar"))
                {
                    clearence.IsRegistrar = true;
                    student.IsRegistrar = true;
                }
                if (User.IsInRole("Finance"))
                {
                    clearence.IsFinance = true;
                    student.IsFinance = true;
                }
                if (User.IsInRole("Dean"))
                {
                    clearence.DeanOfStudent = true;
                    student.DeanOfStudent = true;
                }

                if (clearence.IsRegistrar)
                {
                    db.Entry(student).State = EntityState.Modified;
                    student.Iscomplete = true;
                }

                if (clearence.StudentId != null)
                {
                    db.Entry(clearence).State = EntityState.Modified;

                }
                //db.Students.Add(student);


                db.Clearences.Add(clearence);
                //db.Entry(clearence).State = EntityState.Modified;

                db.SaveChanges();
                TempData["success"] = "Successfully treated";
                return RedirectToAction("Index","Student");
            }

            ViewBag.StudentId = new SelectList(db.Students, "Id", "RegistrationNumber", clearence.StudentId);
            return View(clearence);
        }

        // GET: Clearence/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Entities.Clearence clearence = db.Clearences.Find(id);
            if (clearence == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "RegistrationNumber", clearence.StudentId);
            return View(clearence);
        }

        // POST: Clearence/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentId,IsFinance,DeanOfStudent,IsRegistrar,Comment,ClearenceDate")] Models.Entities.Clearence clearence)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clearence).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "RegistrationNumber", clearence.StudentId);
            return View(clearence);
        }

        // GET: Clearence/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Entities.Clearence clearence = db.Clearences.Find(id);
            if (clearence == null)
            {
                return HttpNotFound();
            }
            return View(clearence);
        }

        // POST: Clearence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.Entities.Clearence clearence = db.Clearences.Find(id);
            db.Clearences.Remove(clearence);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Print(int? id)
        {
           

            Student student = db.Students.SingleOrDefault(k=>k.Id == id);
            
            ViewBag.RegN0 = student.RegistrationNumber;
            ViewBag.FullName = student.FirstName + " " + student.LastName;
            return new PartialViewAsPdf();
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
