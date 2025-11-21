using Institute_Mvc_Ef.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Institute_Mvc_Ef.Application.DTO
{
    public class StudentDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
       
        public string Username { get; set; }
        
        public string Password { get; set; }
        public List<Course>? Courses { get; set; }
      
    }
}
