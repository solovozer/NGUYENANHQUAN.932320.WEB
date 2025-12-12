using lab13.Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace lab13.Pages.Mockups
{
    public class QuizResultModel : PageModel
    {
        public List<QuizQuestion> QuizList { get; set; } = new List<QuizQuestion>();
        public int CountAll { get; set; } = 0;
        public int CountCorrect { get; set; } = 0;

        public List<int> UserAns { get; set; }
        public List<QuizQuestion> QuizQuestions { get; set; }

        private const string QuizSessionKey = "QuizList";
        private const string AnswerKey = "AnswerList";

        public void OnGet()
        {
            var quizJson = HttpContext.Session.GetString(QuizSessionKey);
            var QuizList = !string.IsNullOrEmpty(quizJson) ? JsonSerializer.Deserialize<List<QuizQuestion>>(quizJson): new List<QuizQuestion>();

            var ansJson = HttpContext.Session.GetString(AnswerKey);
            var AnsList = !string.IsNullOrEmpty(ansJson) ? JsonSerializer.Deserialize<List<int>>(ansJson) : new List<int>();
            UserAns = AnsList;
            QuizQuestions = QuizList.ToList();

            CountAll = QuizList.Count();
            CountCorrect = QuizList.Zip(AnsList).Count(x => x.First.RightAnswer == x.Second);

        }
    }
}
