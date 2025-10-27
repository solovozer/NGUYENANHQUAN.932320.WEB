using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab12.Pages.Calc
{
    public class ManualModel : PageModel
    {
        public int Result { get; set; }
        public bool hasResult = false;

        public int Num1 { get; set; }
        public int Num2 { get; set; }

        public void OnPost()
        {
            Num1 = int.Parse(Request.Form["num1"]);
            Num2= int.Parse(Request.Form["num2"]);
            string op = Request.Form["op"];

            if (op == "/" && Num2 == 0)
            {
                ViewData["DivideByZero"] = "Cannot divide by zero.";
                return;
            }

            Result = op switch
            {
                "+" => Num1 + Num2,
                "-" => Num1 - Num2,
                "*" => Num1 * Num2,
                "/" => Num1 / Num2,
                _ => 0
            };
            hasResult = true;
        }
    }
}
