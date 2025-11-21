using Institute_Mvc_Ef.Domain.Interfaces;
using Institute_Mvc_Ef.Domain.Models;
using Institute_Mvc_Ef.Infrastructure.Data;

namespace Institute_Mvc_Ef.Infrastructure.Repositories
{
    public class TeacherRepository:IRepository<Teacher>
    {
        private readonly AppDbContext Context;
        public TeacherRepository(AppDbContext Contextt)
        {
            Context = Contextt;
        }
        public Teacher GetById(int id) => Context.Teachers.FirstOrDefault(c => c.Id == id);
        public IEnumerable<Teacher> GetAll() => Context.Teachers.ToList();
        public void Add(Teacher teacher) { Context.Teachers.Add(teacher);
            Context.SaveChanges();
        }
        public void Update(Teacher teacher) { Context.Teachers.Update(teacher);
            Context.SaveChanges();
        }
        public void Delete(int id)
        {
            var teacher=Context.Teachers.FirstOrDefault(c=>c.Id == id);
            teacher.IsDeleted= true;
            Context.SaveChanges();
        }
    }
}
