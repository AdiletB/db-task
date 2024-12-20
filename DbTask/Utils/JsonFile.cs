using Newtonsoft.Json.Linq;

namespace DbTask.Tests.Utils
{
    public class JsonFile
    {
        private JObject keyValuePairs;

        private readonly string baseDir = @"Resources\";

        public JsonFile(string fileName)
        {
            keyValuePairs = JObject.Parse(
                File.ReadAllText(Path.Combine(baseDir, fileName)));
        }

        public T Get<T>(string key)
            => keyValuePairs[key].ToObject<T>();
    }
}
