using Institute_Mvc_Ef.Domain.Interfaces;
using Institute_Mvc_Ef.Domain.Models;
using Institute_Mvc_Ef.Infrastructure.Data;

namespace Institute_Mvc_Ef.Infrastructure.Repositories
{
    public class StudentCourseRepository:IRepository<StudentCourse>
    {
        private readonly AppDbContext Context;
        public StudentCourseRepository(AppDbContext Contextt)
        {
            Context = Contextt;
        }
        public StudentCourse GetById(int id) => Context.StudentCourses.FirstOrDefault(c => c.Id == id);
        public IEnumerable<StudentCourse> GetAll() => Context.StudentCourses.ToList();
        public void Add(StudentCourse studentcourse)
        {
            Context.StudentCourses.Add(studentcourse);
            Context.SaveChanges();
        }

        public void Update(StudentCourse studentcourse)
        {
            Context.StudentCourses.Update(studentcourse);
            Context.SaveChanges();
        }
        public void Delete(int id)
        {
            var student = Context.StudentCourses.FirstOrDefault(c => c.Id == id);
            student.IsDeleted = true;
            Context.SaveChanges();
        }
    }
}
