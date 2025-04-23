using Microsoft.EntityFrameworkCore;
using Minicore_Notas.Models;

namespace Minicore_Notas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Period> Periods { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "Juan"
                },
                new Student
                {
                    Id = 2,
                    Name = "Pedro"
                },
                new Student
                {
                    Id = 3,
                    Name = "Maria"
                }
            );
            modelBuilder.Entity<Grade>().HasData(

                new Grade
                {
                    Id = 1,
                    Name = "Deber 1",
                    GradeValue = 8.5,
                    Date = new DateOnly(2023, 10, 1),
                    StudentId = 1
                },
                new Grade
                {
                    Id = 2,
                    Name = "Prueba 1",
                    GradeValue = 9.5,
                    Date = new DateOnly(2023, 10, 2),
                    StudentId = 1
                },
                new Grade
                {
                    Id = 3,
                    Name = "Control 1",
                    GradeValue = 10,
                    Date = new DateOnly(2023, 10, 3),
                    StudentId = 1
                }


                );

            modelBuilder.Entity<Period>().HasData(
                new Period
                {
                    Id = 1,
                    Start = new DateOnly(2023, 9, 27),
                    End = new DateOnly(2023, 11, 25),
                    Weigh = 25
                },
                new Period
                {
                    Id = 2,
                    Start = new DateOnly(2023, 11, 26),
                    End = new DateOnly(2024, 1, 8),
                    Weigh = 35
                },
                new Period
                {
                    Id = 3,
                    Start = new DateOnly(2024, 1, 9),
                    End = new DateOnly(2024, 9, 30),
                    Weigh = 40
                }
            );

        }

        /*Method for getting all grades with student id*/
        public List<Grade> GetGradesByStudent(int studentId)
        {
            return Grades.Where(g => g.StudentId == studentId).ToList();
        }
        

        /*method for getting all grades of a student with student id and a range of dates*/
        public List<Grade> GetGradesByRange(int studentId, DateOnly start, DateOnly end)
        {
            return Grades.Where(g => g.StudentId == studentId && g.Date >= start && g.Date <= end).ToList();
        }

        
        /*method for getting all the students in a list*/
        public List<Student> GetStudents()
        {
            return Students.ToList();
        }

        public double GetPeriodAverageByList(List<Grade> grades, int periodId)
        {
            var period = Periods.Find(periodId);
            var gradesPeriod = grades.Where(g => g.Date >= period.Start && g.Date <= period.End).ToList();
            var weigh = Periods.Find(periodId).Weigh / 100;
            return gradesPeriod.Average(g => g.GradeValue) * weigh;
            
        }


    }
}
