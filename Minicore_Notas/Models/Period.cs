using System.ComponentModel.DataAnnotations;

namespace Minicore_Notas.Models
{
    public class Period
    {
        public int Id { get; set; }
        [Required]
        public DateOnly Start { get; set; }
        [Required]
        public DateOnly End { get; set; }
        [Required]
        [Range(1, 99)]
        public int Weigh { get; set; }
    }
}
