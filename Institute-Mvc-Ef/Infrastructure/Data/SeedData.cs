using Institute_Mvc_Ef.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Institute_Mvc_Ef.Infrastructure.Data
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.Migrate();
            
                var teacher=new Teacher
                {
                    FirstName = "Reza",
                    LastName = "Imani"
                };
            context.Teachers.Add(teacher);
            
            context.SaveChanges();

            if (!context.Courses.Any())
            {

                context.Courses.Add(new Course
                {
                    Title = "Backend",
                    TeacherId = teacher.Id,
                    DurationHours = 40,
                    Capacity = 15
                });
                context.Courses.Add(new Course
                {
                    Title = "Frontend",
                    TeacherId = teacher.Id,
                    DurationHours = 40,
                    Capacity = 15
                });

            }
         
                context.Students.Add(new Student
                {
                    Username="admin",
                    Password="1111",
                    IsAdmin=true,
                    
                });
                context.Students.Add(new Student
                {
                    Username = "ali",
                    Password = "2222",
                    

                });
            

            context.SaveChanges();
        }

    }
}
