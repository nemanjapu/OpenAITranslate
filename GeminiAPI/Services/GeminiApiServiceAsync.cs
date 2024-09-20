using GeminiAPI.Helpers;
using GeminiAPI.Interfaces;
using Mscc.GenerativeAI;
using Mscc.GenerativeAI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeminiAPI.Services
{
    public class GeminiApiServiceAsync : IGeminiApiServiceAsync
    {
        private readonly IGenerativeModelService service;

        public GeminiApiServiceAsync(IGenerativeModelService service)
        {
            this.service = service;
        }

        public async Task<string> GetTranslation(string text, string toLanguage)
        {
            var prompt = $"Can you detect the language of the text after the colon and translate it to {toLanguage} language without any aditional comments and indetifying to which language was translated. We need just translated text. If the detexted language and language to translate to are the same, return the original text. Here is what you have to translate: {text}";

            var model = service.CreateInstance();

            var response = await model.GenerateContent(prompt);

            return response.Text.ToString();
        }
    }
}
