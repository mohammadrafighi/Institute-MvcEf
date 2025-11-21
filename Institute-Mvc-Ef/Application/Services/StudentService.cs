using Institute_Mvc_Ef.Application.Interfaces;
using Institute_Mvc_Ef.Domain.Interfaces;
using Institute_Mvc_Ef.Domain.Models;

namespace Institute_Mvc_Ef.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository repo;
        public StudentService(IStudentRepository Srepo)
        {
            repo = Srepo;
        }
        public bool Register(string username, string password)
        {
            var user = repo.GetByUsername(username);
            if (user != null)
            {
                return false;
            }
            repo.Add(new Student
            {
                Username = username,
                Password = password
            });
            return true;
        }
        public Student Login(string username, string password)
        {
            var user= repo.GetByUsername(username);
            if (password != user.Password)
            {
                return null;
            }
            return user;

        }
        public Student GetById(int id)=>repo.GetById(id);
        public List<Student> GetAll()=>repo.GetAll().ToList();
        public bool Update(Student student)
        {
            repo.Update(student);
            return true;
        }
        public bool Delete(int id)
        {
            repo.Delete(id); return true;
        }
        public Student? GetByUsername(string username)=>repo.GetByUsername(username);
        public bool IsAdmin(int id) => repo.GetById(id).IsAdmin;
    }
}
