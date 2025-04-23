using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Minicore_Notas.Data;

namespace Minicore_Notas.Models.ViewModel
{
    public class GradeVM
    {
        public Dictionary<int, double[]> Promedios { get; set; }
        public Grade Grade { get; set; }
        public Student Student { get; set; }
        public Period Period { get; set; }
        [ValidateNever]
        public List<Grade> GradesList { get; set; }
        [ValidateNever]
        public List<Student> StudentsList { get; set; }
        [ValidateNever]
        public List<Period> PeriodsList { get; set; }

        public DateOnly Start { get; set; } = new DateOnly(2023, 9, 27);
        public DateOnly End { get; set; } = new DateOnly(2024, 1, 30);

        //Method for calculating the average of a student in a period
        


    }
}
