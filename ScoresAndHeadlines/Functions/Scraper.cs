using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace ScoresAndHeadlines
{
    public class WebScraper
    {
        public static IEnumerable<string> Scraper(string requestUrl, string outputFileName)
        {
            CancellationTokenSource cancellationToken = new CancellationTokenSource();
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage request = httpClient.GetAsync(requestUrl).Result;
            cancellationToken.Token.ThrowIfCancellationRequested();

            Stream response = request.Content.ReadAsStreamAsync().Result;
            cancellationToken.Token.ThrowIfCancellationRequested();

            HtmlParser parser = new HtmlParser();
            IHtmlDocument document = parser.ParseDocument(response);

            if (cancellationToken.Token.IsCancellationRequested)
            {
                yield return "Request Cancelled";
            }

            yield return ParseHtmlDocument.Parse(document, outputFileName);

        }
    }
}
