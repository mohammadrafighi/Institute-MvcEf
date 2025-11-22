using Institute_Mvc_Ef.Application.DTO;
using Institute_Mvc_Ef.Application.Interfaces;
using Institute_Mvc_Ef.Application.Services;
using Institute_Mvc_Ef.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Institute_Mvc_Ef.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        private bool IsAdmin()
        {
            return HttpContext.Session.GetString("IsAdmin") == "true";
        }

        public IActionResult Index()
        {
            if (!IsAdmin()) return Unauthorized();

            return View(_teacherService.GetAll());
        }

        public IActionResult Create()
        {
            if (!IsAdmin()) return Unauthorized();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            if (!IsAdmin()) return Unauthorized();

            _teacherService.Add(teacher);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (!IsAdmin()) return Unauthorized();

            return View(_teacherService.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Teacher teacher)
        {
            if (!IsAdmin()) return Unauthorized();

            _teacherService.Update(teacher);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (!IsAdmin()) return Unauthorized();

            _teacherService.Delete(id);
            return RedirectToAction("Index");
        }
       
    }
}
