using Institute_Mvc_Ef.Domain.Interfaces;
using Institute_Mvc_Ef.Domain.Models;
using Institute_Mvc_Ef.Infrastructure.Data;
using System.Collections.Immutable;

namespace Institute_Mvc_Ef.Infrastructure.Repositories
{
    public class StudentRepository:IStudentRepository
    {
        private readonly AppDbContext Context;
        public StudentRepository(AppDbContext Contextt)
        {
            Context = Contextt;
        }
        public Student GetById(int id) => Context.Students.FirstOrDefault(c => c.Id == id);
        public IEnumerable<Student> GetAll() => Context.Students.ToList();
        public void Add(Student student) { Context.Students.Add(student);
            Context.SaveChanges();
        }

        public void Update(Student student) { Context.Students.Update(student);
            Context.SaveChanges();
        }
        public void Delete(int id)
        {
            var student = Context.Students.FirstOrDefault(c => c.Id == id);
            student.IsDeleted = true;
            Context.SaveChanges();
        }
        public Student? GetByUsername(string username)
        {
            return Context.Students.FirstOrDefault(s => s.Username == username);
        }
        
    }
}
