using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clearence.Models;
using Clearence.Models.Entities;
using Clearence.Repository;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace IdentitySample.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext db = new ApplicationDbContext();
        private UserRepository _userRepository;

        public HomeController()
        {
            _userRepository = new UserRepository();
        }
        [HttpGet]
        public ActionResult Index( )
        {
            var ID = User.Identity.GetUserId();
            var dept = _userRepository.UserInfoById(ID).Department;
            var firstName= _userRepository.UserInfoById(ID).FirstName;
            var lastName = _userRepository.UserInfoById(ID).LastName;
            var Gender = _userRepository.UserInfoById(ID).Gender;
            var RegNo = _userRepository.UserInfoById(ID).RegistrationNumber;
            var course = _userRepository.UserInfoById(ID).Course;


            StudentViewModel studentViewModel = new StudentViewModel()
            {
                Department = dept,
                FirstName = firstName,
                LastName = lastName,
                Gender = (int)Gender,
                RegistrationNumber = RegNo,
                Course = course
            };
            if (User.Identity.Name == "registrar@example.com")
            {
                ViewBag.Location = "Registrar Dashboard";
            }
            if (User.Identity.Name == "dean@example.com")
            {
                ViewBag.Location = "Dean Dashboard";
            }

            if (User.Identity.Name == "finance@example.com")
            {
                ViewBag.Location = "Finance Dashboard";
            }
            if (User.Identity.Name == "admin@example.com")
            {
                ViewBag.Location = "Admin Dashboard";
            }

            var data = db.Students.Where(k => k.Iscomplete == true).ToList();
            var rRequestdata = db.Students.Where(k => k.IsRegistrar == false 
                                                      && k.DeanOfStudent ==true && k.IsFinance == true
                                                       ).ToList();
            var FinRequestdata = db.Students.Where(k => k.IsFinance == false
             ).ToList();
            var DeanRequestdata = db.Students.Where(k => k.DeanOfStudent == false
            ).ToList();
            ViewBag.Complete = data.Count();
            ViewBag.rRequestdata = rRequestdata.Count();
            ViewBag.Finance = FinRequestdata.Count();
            ViewBag.DeanRequestdata = DeanRequestdata.Count();
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(Student model)
        {
            var ID = User.Identity.GetUserId();
            var dept = _userRepository.UserInfoById(ID).Department;
            var firstName = _userRepository.UserInfoById(ID).FirstName;
            var lastName = _userRepository.UserInfoById(ID).LastName;
            var Gender = _userRepository.UserInfoById(ID).Gender;
            var RegNo = _userRepository.UserInfoById(ID).RegistrationNumber;
            var course = _userRepository.UserInfoById(ID).Course;


            var  student = new Student
            {
                Department = dept,
                FirstName = firstName,
                LastName = lastName,
                Gender = Gender,
                RegistrationNumber = RegNo,
                Course = course
            };
            var IsRegNumber_Available = db.Students.Any(x => x.RegistrationNumber == student.RegistrationNumber);
            if (IsRegNumber_Available == false)
            {
                db.Students.Add(student);
                db.SaveChanges();
                TempData["success"] = "Request Submited Successfully";
                return View(model);
            }

            if (IsRegNumber_Available == true)
            {
                TempData["error"] = "Sorry! Already sent";
            }
            return View(model);

        }

        //Check existing College Registration number
        public JsonResult IsRegNumber_Available(string RegNumber)
        {
            return Json(!db.Students.Any(g => g.RegistrationNumber == RegNumber), JsonRequestBehavior.AllowGet);
        }
    }
}
