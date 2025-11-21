using Institute_Mvc_Ef.Application.Interfaces;
using Institute_Mvc_Ef.Domain.Interfaces;
using Institute_Mvc_Ef.Domain.Models;
using Institute_Mvc_Ef.Infrastructure.Repositories;

namespace Institute_Mvc_Ef.Application.Services
{
    public class StudentCourseService : IStudentCourseService
    {
        private readonly IRepository<StudentCourse> _studentCourseRepo;
        private readonly IRepository<StudentCourse> _courseRepo;

        public StudentCourseService(
            IRepository<StudentCourse> studentCourseRepo,
            IRepository<StudentCourse> courseRepo)
        {
            _studentCourseRepo = studentCourseRepo;
            _courseRepo = courseRepo;
        }
 

        public List<StudentCourse> GetStudentCourses(int studentId)
        {
            return _studentCourseRepo.GetAll()
                .Where(x => x.StudentId == studentId)
                .ToList();
        }

        public List<StudentCourse> GetAll()
        {
            return _studentCourseRepo.GetAll().ToList();
        }
    }
}
