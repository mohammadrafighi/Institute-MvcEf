using Institute_Mvc_Ef.Application.Interfaces;
using Institute_Mvc_Ef.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Institute_Mvc_Ef.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IStudentService studentService;
        public UserController(IStudentService Sservice)
        {
            studentService = Sservice;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Student student) 
        {
            if (!ModelState.IsValid) 
            {
                return View(student);
            }
            bool result=studentService.Register(student.Username, student.Password);
            if (result == false)
            {
                ModelState.AddModelError("", "Not correct");
            }
            return RedirectToAction("Login", "User");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            var user=studentService.Login(student.Username,student.Password);
            if (user == null)
            {
                ModelState.AddModelError("", "Not correct");
                return View();
            }
            HttpContext.Session.SetInt32("UserId",user.Id);
            HttpContext.Session.SetString("Username",user.Username);
            HttpContext.Session.SetString("IsAdmin", user.IsAdmin ? "true" : "false");
            HttpContext.Session.SetString("FirstName", user.FirstName ?? "");
            HttpContext.Session.SetString("LastName", user.LastName ?? "");

            if (user.IsAdmin)
            {
                return RedirectToAction("AdminProfile", "User");
            }
            return RedirectToAction("Profile", "User");
        }
       
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "User");
        }
        public IActionResult Profile() 
        {
            var id=HttpContext.Session.GetInt32("UserId");
            if (id == null)
            {
                return RedirectToAction("Login");
            }
            var user=studentService.GetById(id.Value);
            return View(user);
        }
        public IActionResult AdminProfile()
        {
            var userid=HttpContext.Session.GetInt32("UserId");
            var isadmin = HttpContext.Session.GetString("IsAdmin");
            if (userid == null || isadmin != "true") {
                return RedirectToAction("Login");
            }
            var admin=studentService.GetById(userid.Value);
            return View(admin);
        }

    }
}
