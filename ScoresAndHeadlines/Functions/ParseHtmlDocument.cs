using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScoresAndHeadlines
{
    public class ParseHtmlDocument
    {
        public static string Parse(IHtmlDocument document, string outputFileName)
        {
            FileOutput.FilePreCheck(outputFileName);
            IEnumerable<IElement> fixture;
            fixture = document.All.Where(x => x.ClassName == "qa-match-block");

            if (fixture.Any())
            {
                Output.Generate(fixture, outputFileName);
            }

            return $"{outputFileName} ...Done";
        }
    }
}
