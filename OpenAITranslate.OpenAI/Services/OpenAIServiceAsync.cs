using Microsoft.Extensions.Configuration;
using OpenAI_API.Models;
using OpenAI_API;
using OpenAITranslate.OpenAI.Helpers;
using OpenAITranslate.OpenAI.Interfaces;

namespace OpenAITranslate.OpenAI.Services
{
    public class OpenAIServiceAsync : IOpenAiServiceAsync
    {
        private readonly ConfigReader _configReader;
        private string openAIAPIKey;

        public OpenAIServiceAsync(ConfigReader configReader)
        {
            _configReader = configReader;
            openAIAPIKey = _configReader.GetConfigurationValue("OpenAPIKey");
        }

        public async Task<string> GetTranslation(string text, string toLanguage)
        {
            OpenAIAPI api = new OpenAIAPI(openAIAPIKey);

            var chat = api.Chat.CreateConversation();
            chat.Model = Model.ChatGPTTurbo;
            chat.RequestParameters.Temperature = 0;

            chat.AppendSystemMessage(@$"You are an expert in translation. You know a lot of languages perfectly well and after providing 
            a text to you, you'll first detect the language and then translate it to the specified langugage. I don't need any additional notes,
            just give me the translated text.");

            chat.AppendUserInput($"This is the text that should be translated to {toLanguage} language: {text}");

            var translation = await chat.GetResponseFromChatbotAsync();

            return translation;
        }
    }
}
