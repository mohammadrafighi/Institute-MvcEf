using Institute_Mvc_Ef.Domain.Models;

namespace Institute_Mvc_Ef.Domain.Interfaces
{
    public interface IStudentRepository:IRepository<Student>
    {
        Student? GetByUsername(string username);
    }
}
