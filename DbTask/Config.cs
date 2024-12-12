using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DbTask.Tests
{
    public static class Config
    {
        private static JObject keyValuePairs;

        static Config()
        {
            keyValuePairs = JObject.Parse(
                File.ReadAllText(@"Resources\config.json"));
        }

        public static string Get(string property)
            => keyValuePairs[property]?.ToString();
    }
}
