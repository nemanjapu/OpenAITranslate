using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeminiAPI.Helpers
{
    public class ConfigReader
    {
        public IConfigurationRoot Configuration { get; set; }

        public ConfigReader()
        {
            var builder = new ConfigurationBuilder()
                               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        /// <summary>
        /// For nested properties use colon to get it. E.G. parent:child
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetConfigurationValue(string key)
        {
            return Configuration[key];
        }
    }
}
