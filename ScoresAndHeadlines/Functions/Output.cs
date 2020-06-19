using AngleSharp;
using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ScoresAndHeadlines
{
    public class Output
    {
        public static void Generate(IEnumerable<IElement> page, string outputFileName)
        {
            FileOutput.WriteLocalHtmlFile("<h1>" + outputFileName + "</h1>\n", outputFileName);

            foreach (var element in page)
            {
                FileOutput.WriteLocalHtmlFile(element.Prettify(), outputFileName);
            }
        }
    }
}
