using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OpenAITranslate.OpenAI.Interfaces;

namespace OpenAITranslate.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IOpenAiServiceAsync openAiServiceAsync;

        public IndexModel(ILogger<IndexModel> logger, IOpenAiServiceAsync openAiServiceAsync)
        {
            _logger = logger;
            this.openAiServiceAsync = openAiServiceAsync;
        }

        [BindProperty]
        public string Text { get; set; }

        [BindProperty]
        public string ToLanguage { get; set; }

        [BindProperty]
        public string Translation { get; set; }

        public void OnGet()
        {

        }

        public async Task OnPostAsync()
        {
            Translation = await openAiServiceAsync.GetTranslation(Text, ToLanguage);
        }
    }
}
