using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Minicore_Notas.Data;
using Minicore_Notas.Models;
using Minicore_Notas.Models.ViewModel;
using System.Diagnostics;

namespace Minicore_Notas.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private DateOnly Start { get; set; } = new DateOnly(2023, 9, 27);
        private DateOnly End { get; set; } = new DateOnly(2024, 1, 30);

        public HomeController(ApplicationDbContext context,ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            
            //Para crear Grades
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Name");
            /*retrieve*/
            GradeVM gradeVm= new()
            {
                Grade = new Grade(),
                Student = new Student(),
                Period = new Period(),
                StudentsList = _context.Students.ToList(),
                PeriodsList = _context.Periods.ToList(),
                GradesList = _context.Grades.ToList()

            };

            

            return View(gradeVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStudent([Bind("Id,Name")] Student student)
        {

            _context.Add(student);
            await _context.SaveChangesAsync();
            return Redirect("."); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGrade([Bind("Id,Name,GradeValue,Date,StudentId")] Grade grade)
        {
            try
            {
                _context.Add(grade);
                await _context.SaveChangesAsync();
                return Redirect(".");
            }
            catch(Exception e)
            {
                ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Name", grade.StudentId);
                return Redirect(".");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePeriod([Bind("Id,Start,End,Weigh")] Period period)
        {
            try
            {
                _context.Add(period);
                await _context.SaveChangesAsync();
                
            }
            catch (Exception e)
            {
            }
            return Redirect(".");
        }


        /*ACTION FOR RETRIEVING ALL THE GRADES IN A RANGE OF dates*/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DefineRange([Bind("Start", "End")] GradeVM gradeVM )
        {

            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Name");

            var grades = _context.Grades.Where(g => g.Date >= gradeVM.Start && g.Date <= gradeVM.End).ToList();
            var students = _context.Students.ToList();
            var periods = _context.Periods.ToList();
            var gradeVm = new GradeVM
            {
                Promedios = new Dictionary<int, double[]>(),
                Grade = new Grade(),
                GradesList = grades,
                StudentsList = students,
                PeriodsList = periods,
                Start = gradeVM.Start,
                End = gradeVM.End
            };
            foreach (var student in students)
            {
                var promedios = new double[5];
                for (int i = 1; i <= 3; i++)
                {
                    promedios[i - 1] = GetGradesByStudent(student.Id, gradeVM.Start, gradeVM.End, i);
                }
                promedios[3] = promedios[0] + promedios[1] + promedios[2];
                gradeVm.Promedios.Add(student.Id, promedios);

                promedios[4] = (6 - (promedios[0] + promedios[1]))/0.4;

            }   

            return View("Index", gradeVm);
        }
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // METHOD FOR GETTING ALL GRADES WITH STUDENT ID WHERE DATE IS BETWEEN START AND END AND DATE IS BETWEEN START AND END OF PERIOD 
        public double GetGradesByStudent(int studentId, DateOnly start, DateOnly end, int periodId)
        {
            var period = _context.Periods.Find(periodId);
            var lista =  _context.Grades.Where(g => g.StudentId == studentId && g.Date >= start && g.Date <= end && g.Date >= period.Start && g.Date <= period.End).ToList();
            if (lista.Count == 0)
            {
                return 0;
            }

            //return the average of the list multiplied by the weigh of the period
            return lista.Average(g => g.GradeValue) * period.Weigh/100;

            //return lista.Average(g => g.GradeValue);
        }
    }
}
