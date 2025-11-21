using Institute_Mvc_Ef.Domain.Models;

namespace Institute_Mvc_Ef.Application.Interfaces
{
    public interface IStudentCourseService
    {
        List<StudentCourse> GetStudentCourses(int studentId);
        List<StudentCourse> GetAll();
    }
}
