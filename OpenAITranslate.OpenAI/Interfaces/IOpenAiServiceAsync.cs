namespace OpenAITranslate.OpenAI.Interfaces
{
    public interface IOpenAiServiceAsync
    {
        Task<string> GetTranslation(string text, string toLanguage);
    }
}