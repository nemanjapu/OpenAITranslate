using GeminiAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OpenAITranslate.OpenAI.Interfaces;

namespace OpenAITranslate.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IOpenAiServiceAsync openAiServiceAsync;
        private readonly IGeminiApiServiceAsync geminiApiServiceAsync;

        public IndexModel(ILogger<IndexModel> logger, IOpenAiServiceAsync openAiServiceAsync, IGeminiApiServiceAsync geminiApiServiceAsync)
        {
            _logger = logger;
            this.openAiServiceAsync = openAiServiceAsync;
            this.geminiApiServiceAsync = geminiApiServiceAsync;
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
            Translation = await geminiApiServiceAsync.GetTranslation(Text, ToLanguage);
        }
    }
}
