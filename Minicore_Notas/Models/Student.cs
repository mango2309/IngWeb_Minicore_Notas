using Minicore_Notas.Data;
using System.ComponentModel.DataAnnotations;

namespace Minicore_Notas.Models
{
    public class Student
    {
        public Student()
        {
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public List<Grade> Grades { get; set; }  
        

    }
}
