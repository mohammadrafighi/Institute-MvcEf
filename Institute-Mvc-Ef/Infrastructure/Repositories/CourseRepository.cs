using Institute_Mvc_Ef.Domain.Interfaces;
using Institute_Mvc_Ef.Domain.Models;
using Institute_Mvc_Ef.Infrastructure.Data;
using System.Collections.Immutable;

namespace Institute_Mvc_Ef.Infrastructure.Repositories
{
    public class CourseRepository:IRepository<Course>
    {
        private readonly AppDbContext Context;
        public CourseRepository(AppDbContext Contextt)
        {
                Context = Contextt;
        }
        public Course GetById(int id) => Context.Courses.FirstOrDefault(c => c.Id == id);
        public IEnumerable<Course> GetAll()=> Context.Courses.ToList();
        public void Add(Course course) { Context.Courses.Add(course);
            Context.SaveChanges();
        }
        public void Update(Course course)
        { 
            Context.Courses.Update(course);
            Context.SaveChanges();
        }
        public void Delete(int id)
        {
            var course = Context.Courses.FirstOrDefault(c => c.Id == id);
            course.IsDeleted = true;
            Context.SaveChanges();
        }
    }
}
