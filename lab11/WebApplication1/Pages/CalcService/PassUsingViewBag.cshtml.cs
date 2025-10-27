using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.CalcService
{
    public class PassUsingViewBagModel : PageModel
    {
        private readonly Random random = new Random();
        public void OnGet()
        {
            int num1 = random.Next(1, 10);
            int num2 = random.Next(1, 10);
            ViewData["Num2"] = num2;
            ViewData["Sum"] = num1 + num2;
            ViewData["Difference"] = num1 - num2;
            ViewData["Product"] = num1 * num2;
            ViewData["Quotient"] = num1 / num2;
        }
    }
}
