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

        public CalculationModel(int n1, int n2)         {
            num1 = n1;
            num2 = n2;
            sum = num1 + num2;
            difference = num1 - num2;
            product = num1 * num2;
            quotient = num2 != 0 ? num1 / num2 : 0;
        }
    }
    public class PassUsingModelModel : PageModel
    {
        private Random random = new Random();
        public CalculationModel calculation {  get; set; }
        public void OnGet()
        {
            calculation = new CalculationModel(random.Next(1, 10), random.Next(1, 10));
        }
    }
}
