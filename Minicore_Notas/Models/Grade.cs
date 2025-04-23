using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Minicore_Notas.Models
{
    public class Grade
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0, 10)]
        public double GradeValue { get; set; }
        [Required]
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(System.DateTime.Now);
        [Required]
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}
