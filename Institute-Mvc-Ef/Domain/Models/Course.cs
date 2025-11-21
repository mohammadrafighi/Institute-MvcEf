using System.ComponentModel.DataAnnotations;

namespace Institute_Mvc_Ef.Domain.Models
{
    public class Course:BaseEntity
    {
        [Required]
        public string Title { get; set; }
       
        public int? DurationHours {  get; set; }
        [Required]
        public int Capacity {  get; set; }
        public Teacher? Teacher { get; set; }
        public int TeacherId { get; set; }
        public bool IsFinished {  get; set; }
        public List<Student>? Students {  get; set; }
        public Course()
        {
            IsFinished = false;
        }

    }
}
