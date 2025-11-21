using Institute_Mvc_Ef.Domain.Models;

namespace Institute_Mvc_Ef.Application.Interfaces
{
    public interface ICourseService
    {
        bool JoinCourse(int studentid, int courseid);
        Course GetById(int id);
        List<Course> GetAll();
        bool IsFinished(Course course);
        bool Update(Course course);
        bool Delete(Course course);
       
        void Add(Course course);
    }
}
