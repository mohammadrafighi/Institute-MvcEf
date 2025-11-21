using System.ComponentModel.DataAnnotations;

namespace Institute_Mvc_Ef.Domain.Models
{
    public class Teacher:BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public List<Course>? Courses {  get; set; }


    }
}
