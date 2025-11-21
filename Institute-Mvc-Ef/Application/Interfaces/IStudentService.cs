using Institute_Mvc_Ef.Domain.Models;

namespace Institute_Mvc_Ef.Application.Interfaces
{
    public interface IStudentService
    {
        bool Register(string usernam, string password);
        Student Login(string username, string password);
        Student GetById(int id);
        List<Student> GetAll();
        bool Update(Student student);
        bool Delete(int id);
        Student? GetByUsername(string username);
        bool IsAdmin(int id);
    }
}
