using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeminiAPI.Interfaces
{
    public interface IGeminiApiServiceAsync
    {
        Task<string> GetTranslation(string text, string toLanguage);
    }
}
