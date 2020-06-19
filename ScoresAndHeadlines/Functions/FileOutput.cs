using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ScoresAndHeadlines
{
    public class FileOutput
    {
        private static async Task<string> SetOutputDirectory()
        {
            var dir = await JsonReader.OutputDirectory("OutputDirectory.json");
            if (String.IsNullOrEmpty(dir))
            {
                return @$"C:{Path.DirectorySeparatorChar}Temp";
            }
            else
            {
                return @$"C:{Path.DirectorySeparatorChar}{dir}";
            }
        }

        public static void WriteLocalHtmlFile(string content, string fileName)
        {
            Directory.CreateDirectory(SetOutputDirectory().Result);

            File.AppendAllText(SetOutputDirectory().Result + @$"{Path.DirectorySeparatorChar}{fileName}.html", content);
            string dateStamp = DateTime.Now.Date.ToShortDateString().Replace("/", "");

            File.AppendAllText(SetOutputDirectory().Result + @$"{Path.DirectorySeparatorChar}FullList{dateStamp}.html", content);
        }

        public static void FilePreCheck(string fileName)
        {
            string dirFile = SetOutputDirectory().Result + @$"{Path.DirectorySeparatorChar}{fileName}.html";

            if (File.Exists(dirFile))
            {
                File.Delete(dirFile);
            }
        }
    }
}
