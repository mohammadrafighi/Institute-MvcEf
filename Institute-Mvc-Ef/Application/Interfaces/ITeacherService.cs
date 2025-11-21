using Institute_Mvc_Ef.Domain.Models;

namespace Institute_Mvc_Ef.Application.Interfaces
{
    public interface ITeacherService
    {
      
        Teacher GetById(int id);
        List<Teacher> GetAll();

        bool Update(Teacher teacher);
        bool Delete(int id);
        void Add(Teacher teacher);



    }
}
