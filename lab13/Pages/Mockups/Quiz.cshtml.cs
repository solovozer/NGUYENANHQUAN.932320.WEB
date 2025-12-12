using lab13.Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace lab13.Pages.Mockups
{
    public class QuizModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Please input an answer")]
        [Range(-36, int.MaxValue, ErrorMessage = "Answer must be a number.")]
        public int? UserAns { get; set; }
        public required QuizQuestion quiz;
        private const string QuizSessionKey = "QuizList";
        private const string AnswerKey = "AnswerList";
        public void OnGet()
        {
            UserAns = null;
            Random r = new Random();
            quiz = new QuizQuestion(r);
            var quizJson = HttpContext.Session.GetString(QuizSessionKey);
            var quizList = string.IsNullOrEmpty(quizJson)
                ? new List<QuizQuestion>()
                : JsonSerializer.Deserialize<List<QuizQuestion>>(quizJson);

            if (quizList != null)
            {
                quizList.Add(quiz);
                HttpContext.Session.SetString(QuizSessionKey, JsonSerializer.Serialize(quizList));
            }
            TempData["QuizList"] = JsonSerializer.Serialize(quizList);
        }

        public IActionResult OnPost(string action)
        {
            var ansJson = HttpContext.Session.GetString(AnswerKey);
            var ansList = string.IsNullOrEmpty(ansJson) ? new List<int>() : JsonSerializer.Deserialize<List<int>>(ansJson);

            if (ansList != null && UserAns.HasValue)
            {
                ansList.Add(UserAns.Value);
                HttpContext.Session.SetString(AnswerKey, JsonSerializer.Serialize(ansList));
            }

            if (action == "next")
            {
                return RedirectToPage();
            }
            if (action == "finish")
            {
                TempData["AnsList"] = JsonSerializer.Serialize(ansList);
                return Redirect("/Mockups/QuizResult");
            }

            return Redirect("/Mockups");
        }
    }
}
