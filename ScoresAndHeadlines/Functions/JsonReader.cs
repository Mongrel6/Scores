using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Threading.Tasks;

namespace ScoresAndHeadlines
{
    public class JsonReader
    {
        private static async Task<JsonTextReader> Read(string fileName)
        {
            JsonTextReader reader = new JsonTextReader(new StringReader(await File.ReadAllTextAsync(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + fileName).ConfigureAwait(false)))
            {
                SupportMultipleContent = true
            };

            return reader;
        }

        public static async Task<CustomUrl> CustomUrlOutput(string fileName)
        {
            var reader = await Read(fileName).ConfigureAwait(false);
            CustomUrl customUrl = new CustomUrl();

            while (reader.Read())
            {
                JsonSerializer serializer = new JsonSerializer();
                customUrl = serializer.Deserialize<CustomUrl>(reader);
            }

            return customUrl;
        }

        public static async Task<string> FullListOutput(string fileName)
        {
            var reader = await Read(fileName).ConfigureAwait(false);
            string output = "";

            while (reader.Read())
            {
                JsonSerializer serializer = new JsonSerializer();
                output = serializer.Deserialize<FullListOutput>(reader).OutputDirectory;
            }

            return output;
        }
    }
}
