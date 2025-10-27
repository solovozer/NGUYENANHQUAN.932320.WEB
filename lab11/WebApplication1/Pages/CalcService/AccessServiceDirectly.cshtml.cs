using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.CalcService
{
    public class AccessServiceDirectlyModel : PageModel
    {
        private Random random = new Random();
        public int num1 { get; set; } = 0;
        public int num2 { get; set; } = 0;

        public int sum { get; set; } = 0;
        public int difference { get; set; } = 0;
        public int product { get; set; } = 0;
        public int quotient { get; set; } = 0;

        public void Generate()
        {
            num1 = random.Next(1, 10);
            num2 = random.Next(1, 10);
        }

        public void OnGet()
        {
            Generate();
            sum = num1 + num2;
            difference = num1 - num2;
            product = num1 * num2;
            quotient = num1 / num2;
        }
    }
}
