using Institute_Mvc_Ef.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Institute_Mvc_Ef.Application.DTO
{
    public class CourseDTO
    {
        public string Title { get; set; }

        public int? DurationHours { get; set; }
        public int Capacity { get; set; }
        public int TeacherId { get; set; }
        public bool IsFinished { get; set; }
    }
}
