using Institute_Mvc_Ef.Application.Interfaces;
using Institute_Mvc_Ef.Domain.Interfaces;
using Institute_Mvc_Ef.Domain.Models;

namespace Institute_Mvc_Ef.Application.Services
{
    public class CourseService:ICourseService
    {
        private readonly IRepository<Course> Courserepo;
        private readonly IStudentRepository Studentrepo;
        private readonly IRepository<StudentCourse> StudentCourserepo;
        private readonly IRepository<Teacher> Teacherrepo;
        public CourseService(IRepository<Course> Crepo,IStudentRepository Srepo,IRepository<StudentCourse> SCrepo,IRepository<Teacher> Trepo)
        {
            Courserepo = Crepo;
            Studentrepo = Srepo;
            StudentCourserepo = SCrepo;
            Teacherrepo = Trepo;
        }
        public bool JoinCourse(int studentid, int courseid)
        {
            
            var student=Studentrepo.GetById(studentid);
            var course=Courserepo.GetById(courseid);
            var exist = StudentCourserepo.GetAll().Any(x => x.StudentId == studentid && x.CourseId == courseid);
            if (course.Capacity > 0 && exist==false) { 
            StudentCourserepo.Add(new StudentCourse
            {
                StudentId=studentid,
                CourseId=courseid,
            });
            course.Capacity --;
                Courserepo.Update(course);
            return true;}
            return false;

        }
        public Course GetById(int id)=>Courserepo.GetById(id);
        public List<Course> GetAll()=>Courserepo.GetAll().ToList();
        public bool IsFinished(Course course)
        {
            return course.IsFinished;
        }
        public bool Update(Course course)
        {
            Courserepo.Update(course);
            return true;
        }
        public bool Delete(Course course)
        {
            Courserepo.Delete(course.Id);
            return true;
        }
        public void Add(Course course)
        {
            var teacher = Teacherrepo.GetById(course.TeacherId);
            if (teacher == null)
            {
                throw new Exception("Teacher not found");
            }
            Courserepo.Add(course);
        }
       
    }
}
