using Institute_Mvc_Ef.Application.DTO;
using Institute_Mvc_Ef.Application.Interfaces;
using Institute_Mvc_Ef.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Institute_Mvc_Ef.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ITeacherService _teacherService;

        public CourseController(ICourseService courseService, ITeacherService teacherService)
        {
            _courseService = courseService;
            _teacherService = teacherService;
        }

        
        public IActionResult Index(string titleFilter, int? teacherId)
        {
            var courses = _courseService.GetAll();

            if (!string.IsNullOrEmpty(titleFilter))
                courses = courses.Where(x => x.Title.Contains(titleFilter)).ToList();

            if (teacherId != null)
                courses = courses.Where(x => x.TeacherId == teacherId).ToList();

            ViewBag.Teachers = _teacherService.GetAll();

            return View(courses);
        }

        private bool IsAdmin()
        {
            return HttpContext.Session.GetString("IsAdmin") == "true";
        }

        public IActionResult Create()
        {
            if (!IsAdmin()) return Unauthorized();

            ViewBag.Teachers = _teacherService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (!IsAdmin()) return Unauthorized();

            _courseService.Add(course);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (!IsAdmin()) return Unauthorized();

            ViewBag.Teachers = _teacherService.GetAll();
            var course = _courseService.GetById(id);
            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            if (!IsAdmin()) return Unauthorized();

            _courseService.Update(course);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (!IsAdmin()) return Unauthorized();

            _courseService.Delete(_courseService.GetById(id));
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var course = _courseService.GetById(id);
            return View(course);
        }
        public IActionResult JoinCourse(int studentid,int courseid ) { 
        var result=_courseService.JoinCourse(studentid,courseid);
            if (result == false)
            {
                TempData["Error"] = "Not successfull";
            }
            else {
                TempData["Success"] = "Successfull";
            }
            return RedirectToAction("Index");

        }
       
    }
}
