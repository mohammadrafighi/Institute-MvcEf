using Institute_Mvc_Ef.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Institute_Mvc_Ef.Web.Controllers
{
    public class StudentCourseController : Controller
    {
        private readonly IStudentCourseService _enrollService;
        private readonly ICourseService _courseService;

        public StudentCourseController(IStudentCourseService service, ICourseService courseService)
        {
            _enrollService = service;
            _courseService = courseService;
        }

        private int GetUserId()
        {
            return Convert.ToInt32(HttpContext.Session.GetString("UserId"));
        }

        public IActionResult Index()
        {
            var userId = GetUserId();
            var myCourses = _enrollService.GetStudentCourses(userId);
            return View(myCourses);
        }

        public IActionResult Enroll(int courseId)
        {
            var userId = GetUserId();

            var result = _courseService.JoinCourse(userId, courseId);

            if (!result)
                TempData["Error"] = "Registration failed: Capacity full or already registered.";

            return RedirectToAction("Details", "Course", new { id = courseId });
        }

     
    }
}
