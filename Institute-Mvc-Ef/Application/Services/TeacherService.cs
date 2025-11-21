using Institute_Mvc_Ef.Application.Interfaces;
using Institute_Mvc_Ef.Domain.Interfaces;
using Institute_Mvc_Ef.Domain.Models;

namespace Institute_Mvc_Ef.Application.Services
{
    public class TeacherService:ITeacherService
    {
        private readonly IRepository<Teacher> repo;
        public TeacherService(IRepository<Teacher> Trepo)
        {
                repo=Trepo;
        }
        public Teacher GetById(int id)=>repo.GetById(id);
        public List<Teacher> GetAll()=>repo.GetAll().ToList();
        public void Add(Teacher teacher)=>repo.Add(teacher);
        public bool Update(Teacher teacher)
        {
            repo.Update(teacher);
            return true;
        }
        public bool Delete(int id)
        {
            repo.Delete(id);
            return true;
        }
    }
}
