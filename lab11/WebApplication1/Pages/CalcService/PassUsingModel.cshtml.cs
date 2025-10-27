using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Dynamic;

namespace WebApplication1.Pages.CalcService
{
    public class CalculationModel
    {
        public int num1 { get; set; }
        public int num2 { get; set; }
        public int sum { get; set; }
        public int difference { get; set; }
        public int product { get; set; }
        public int quotient { get; set; }
    }
    public class PassUsingModelModel : PageModel
    {
        private Random random = new Random();
        public CalculationModel calculation {  get; set; }
        public void OnGet()
        {
            calculation = new CalculationModel
            {
                num1 = random.Next(1, 10),
                num2 = random.Next(1, 10)
            };
        }
    }
}
