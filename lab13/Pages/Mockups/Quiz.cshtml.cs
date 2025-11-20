using lab13.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.ObjectPool;
using Newtonsoft.Json;

namespace lab13.Pages.Mockups
{
    public class QuizModel : PageModel
    {
       

        [BindProperty]
        public QuizState CurrState { get; private set; }

        [BindProperty]
        public int? Answer { get; set; } = null;
        public string? ErrorMessage { get; set; } = string.Empty;

        private const string TempDataKey = "QuizState";

        public QuizModel()
        {
            CurrState = new QuizState();   

        }

        public void OnGet()
        {
            Load();
            if (TempData.ContainsKey("showQuiz"))
            {
                CurrState.ShowQuiz = (bool) TempData.Peek("showQuiz");
            }
        }

        public IActionResult OnPost()
        {
            if (Request.Form["action"] == "Next") return OnPostNext();
            else return OnPostFinish();
        }

        public IActionResult OnPostNext()
        {
            Load();

            if (Answer is null)
            {
                ErrorMessage = "Please input a NUMBER!";
                Save();
                return Page();
            }

            CurrState.Questions.Add(CurrState.CurrentQuestion);
            CurrState.TotalAns++;
            if (Answer == CurrState.CurrentQuestion.RightAnswer) CurrState.RightAns++;

            if (CurrState.TotalAns <= 4)
            {
                CurrState.CurrentQuestion = new QuizQuestion();
                Save();
                return Page();
            }

            return OnPostFinish();
        }

        public IActionResult OnPostFinish()
        {
            Load();
            CurrState.ShowQuiz = false;
            return Page();
        }

        private void Load()
        {
            if (TempData.ContainsKey(TempDataKey))
            {
                var json = TempData.Peek(TempDataKey) as string;
                if (!string.IsNullOrEmpty(json))
                {
                    var state = JsonConvert.DeserializeObject<QuizState>(json);
                    CurrState.Questions= state.Questions;
                    CurrState.RightAns = state.RightAns;
                    CurrState.TotalAns = state.TotalAns;
                    CurrState.ShowQuiz = state.ShowQuiz;
                    CurrState.CurrentQuestion = state.CurrentQuestion;
                }
            }
        }

        private void Save()
        {
            var state = new QuizState
            {
                Questions  = CurrState.Questions,
                RightAns = CurrState.RightAns,
                TotalAns = CurrState.TotalAns,
                ShowQuiz = CurrState.ShowQuiz,
                CurrentQuestion = CurrState.CurrentQuestion,
            };
            TempData[TempDataKey] = JsonConvert.SerializeObject(state);
        }

        public class QuizState
        {
            public List<QuizQuestion> Questions { get; set; } = new();
            public QuizQuestion CurrentQuestion { get; set; } = new QuizQuestion();
            public int RightAns { get; set; } = 0;
            public int TotalAns { get; set; } = 0;
            public bool ShowQuiz { get; set; } = true;
        }
    }
}
