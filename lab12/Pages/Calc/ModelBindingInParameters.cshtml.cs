using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab12.Pages.Calc
{
    public class ModelBindingWithParametersModel : PageModel
    {
        public int Num1 { get; set; }
        public int Num2 { get; set; }

        public bool hasResult = false;
        public int Result { get; set; }

        int Addition() { return Num1 + Num2; }
        int Subtraction() { return Num1 - Num2; }
        int Multiplication() { return Num1 * Num2; }
        int Division()
        {
            if (Num2 == 0)
            {
                ViewData["DivideByZero"] = true;
                return 0;
            }
            else
            {
                return Num1 / Num2;
            }
        }

        public void OnGet()
        {
            Num1 = int.Parse(Request.Form["Num1"]);
            Num2 = int.Parse(Request.Form["Num2"]);
            string op = Request.Form["op"];
            Result = op switch
            {
                "+" => Addition(),
                "-" => Subtraction(),
                "*" => Multiplication(),
                "/" => Division(),
                _ => Addition()
            };
            hasResult = true;
        }
    }
}
