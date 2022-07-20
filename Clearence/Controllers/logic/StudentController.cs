using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Clearence.Models.Entities;
using Clearence.Repository;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Clearence.Controllers.logic
{
    public class StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UserRepository _userRepository;

        public StudentController()
        {
            _userRepository = new UserRepository();
        }
        // GET: Student
        public ActionResult Index()
        {
            var ID = User.Identity.GetUserId();
            var RegN0 = _userRepository.UserInfoById(ID).RegistrationNumber;
            if (User.IsInRole("Admin"))
            {
                 return View(db.Students.ToList());
            }
            
            if (User.IsInRole("Student"))
            {
                return View(db.Students.Where(k => k.RegistrationNumber == RegN0).ToList());
            }

            if (User.IsInRole("Finance"))
            {
                return View(db.Students.Where(k => k.IsFinance == false).ToList());
            }
            if (User.IsInRole("Dean"))
            {
                return View(db.Students.Where(k => k.DeanOfStudent == false).ToList());
            }
            if (User.IsInRole("Registrar"))
            {
                return View(db.Students.Where(k => k.IsRegistrar == false).ToList());
            }
           
            return View(db.Students.ToList());

        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
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
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            ViewBag.Course = new SelectList(db.Courses, "Name", "Name");
            ViewBag.Department = new SelectList(db.Departments, "Name", "Name");

            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegistrationNumber,FirstName,LastName,Gender,Course,Department,Year,Iscomplete,IsFinance,DeanOfStudent,IsRegistrar")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.Course = new SelectList(db.Courses, "Name", "Name");
            ViewBag.Department = new SelectList(db.Departments, "Name", "Name");
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegistrationNumber,FirstName,LastName,Gender,Course,Department,Year,Iscomplete,IsFinance,DeanOfStudent,IsRegistrar")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
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
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
