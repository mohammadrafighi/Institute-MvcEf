using System.ComponentModel.DataAnnotations;

namespace Institute_Mvc_Ef.Domain.Models
{
    public class Student:BaseEntity
    {
       
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsAdmin {  get; set; }
        public List<Course>? Courses { get; set; }
        public Student()
        {
            IsAdmin = false;
        }

    }
}
