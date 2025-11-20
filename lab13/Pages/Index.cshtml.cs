using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab13.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnPost()
        {
            var action = Request.Form["showQuiz"];
            if (!string.IsNullOrEmpty(action)) TempData["showQuiz"] = action == "true";
            return RedirectToPage("Quiz");
        }
    }
}
