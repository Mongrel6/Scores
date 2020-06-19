using System;
using System.Threading.Tasks;

namespace ScoresAndHeadlines
{
    public class Program
    {
        private static string bbcSportPremierLeagueUrl = "https://www.bbc.co.uk/sport/football/premier-league/scores-fixtures";
        private static string bbcSportSerieAUrl = "https://www.bbc.co.uk/sport/football/italian-serie-a/scores-fixtures";
        private static string bbcSportsLaLigaUrl = "https://www.bbc.co.uk/sport/football/spanish-la-liga/scores-fixtures";

        private static string curatedScoresPremFileName = "Premier League";
        private static string curatedScoresSerieA = "Serie A";
        private static string curatedScoresLaLiga = "Spanish La Liga";

        static async Task Main()
        {
            foreach (var result in WebScraper.Scraper(bbcSportPremierLeagueUrl, curatedScoresPremFileName))
            {
                Console.WriteLine(result);
            }

            foreach (var result in WebScraper.Scraper(bbcSportSerieAUrl, curatedScoresSerieA))
            {
                Console.WriteLine(result);
            }

            foreach (var result in WebScraper.Scraper(bbcSportsLaLigaUrl, curatedScoresLaLiga))
            {
                Console.WriteLine(result);
            }

            var customUrl = JsonReader.CustomUrlOutput("CustomUrl.json").Result;

            if (!String.IsNullOrEmpty(customUrl.Url))
            {
                foreach (var result in WebScraper.Scraper(customUrl.Url, customUrl.FileName))
                {
                    Console.WriteLine(result);
                }
            }
        }



    }
}
