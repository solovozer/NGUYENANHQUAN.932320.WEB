using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Emit;

namespace lab13.Pages.Mockups
{
    public class QuizQuestion
    {
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public int UserAnswer {  get; set; }
        public int RightAnswer { get; set; }
        public int OpCode { get; set; } = 0;

        public QuizQuestion()
        {
            Random r = new Random();
            OpCode = r.Next(1, 4);
            Num1 = r.Next(0, 10);
            if (OpCode == 4)
            {
                Num2 = r.Next(1, 10);
            }
            else
            {
                Num2 = r.Next(0, 10);
            }
            RightAnswer = OpCode switch
            {
                1 => Num1 + Num2,
                2 => Num1 - Num2,
                3 => Num1 * Num2,
                4 => Num1 / Num2,
                _ => 0,
            };
        }

    }

    public class QuizService()
    {
        public List<QuizQuestion> Logs { get; set; } = new List<QuizQuestion>();
    }
    public class QuizModel : PageModel
    {
        [BindProperty] public int Answer { get; set; }
        QuizQuestion CurrentQuestion {  get; set; }

        public void OnGet()
        {
            CurrentQuestion = new QuizQuestion();
        }

        public IActionResult OnPost()
        {


            CurrentQuestion.UserAnswer = Answer;
            return Redirect("");
        }
    }
}
