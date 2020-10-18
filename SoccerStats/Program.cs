//** TODO: CHECK NEWSRESULT LIST FOR DUPLICATES WITH LINQ(?) AND RETURN A DISTINCT LIST...
//              1. Use a for-loop in the GetNews method to assign a "SentimentId" in each newsresult object using a hashcode of the headline multiplied by the index of the for loop?
//
//** TODO: ADD TRY/CATCH and IF STATEMENT after to allow for exception reporting... does Json.Net have exceptions? Put in trycatch too?

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;
using System.Net;

namespace SoccerStats
{
    class Program
    {
        static void Main(string[] args)
        {
            //Set current directory path
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);

            //Read game results from csv file
            var fileName = Path.Combine(directory.FullName, "SoccerGameResults.csv");
            var fileContents = ReadSoccerResults(fileName);

            //Deserialize players json
            fileName = Path.Combine(directory.FullName, "players.json");
            var players = DeserializePlayers(fileName);

            //Call BingNews Api for each player's recent news results; call TextAnalysis for sentiment
            foreach (var player in GetTopTenPlayers(players))
            {
                List<NewsResult> newsResults = GetNewsForPlayer(string.Format("{0} {1}", player.FirstName, player.SecondName));
                SentimentResponse sentimentResponse = GetSentimentResponse(newsResults);
                foreach (var response in sentimentResponse.Responses )
                {
                    foreach ( var newsResult in newsResults )
                    {
                        if ( newsResult.SentimentId == response.Id )
                        {
                            newsResult.SentimentScore = response.MainSentiment;
                            break;
                        }
                    }
                }
                //Display player info and news results one at a time
                Console.WriteLine(string.Format("Player: {0} {1}", player.FirstName, player.SecondName));
                foreach(var result in newsResults)
                {
                    Console.WriteLine(string.Format("Date: {0:f}, Headline: {1}, Summary: {2}, Sentiment Score: {3}\r\n", result.DatePublished, result.Headline, result.Summary, result.SentimentScore));
                    Console.ReadKey();
                }
            }
            //Serialize top ten results to json file
            fileName = Path.Combine(directory.FullName, "topten.json");
            SerializePlayersToFile(GetTopTenPlayers(players), fileName);
        }
        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }

        public static List<GameResult> ReadSoccerResults(string fileName)
        {
            var soccerResults = new List<GameResult>();
            using (var reader = new StreamReader(fileName))
            {
                string line = "";
                reader.ReadLine();
                while ( (line = reader.ReadLine()) != null )
                {
                    var gameResult = new GameResult();
                    string[] values = line.Split(',');
                    
                    DateTime gameDate;
                    if (DateTime.TryParse(values[0], out gameDate))
                    {
                        gameResult.GameDate = gameDate;
                    }
                    gameResult.TeamName = values[1];
                    HomeOrAway homeOrAway;
                    if (Enum.TryParse(values[2], out homeOrAway))
                    {
                        gameResult.HomeOrAway = homeOrAway;
                    }
                    int parseInt;
                    if (int.TryParse(values[3], out parseInt))
                    {
                        gameResult.Goals = parseInt;
                    }
                    if (int.TryParse(values[4], out parseInt))
                    {
                        gameResult.GoalAttempts = parseInt;
                    }
                    if (int.TryParse(values[5], out parseInt))
                    {
                        gameResult.ShotsOnGoal = parseInt;
                    }
                    if (int.TryParse(values[6], out parseInt))
                    {
                        gameResult.ShotsOffGoal = parseInt;
                    }
                    double possessionPercent;
                    if (double.TryParse(values[7], out possessionPercent))
                    {
                        gameResult.PossessionPercent = possessionPercent;
                    }
                    soccerResults.Add(gameResult);
                }
            }
            return soccerResults;
        }

        public static List<Player> DeserializePlayers(string fileName)
        {
            var players = new List<Player>();
            var serializer = new JsonSerializer();
            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
                players = serializer.Deserialize<List<Player>>(jsonReader);
            }
            return players;
        }

        //public static IEnumerable<Player> GetTopTenPlayers(List<Player> players)
        //{
        //    return players.OrderByDescending(p => p.PointsPerGame).Take(10);
        //}

        public static List<Player> GetTopTenPlayers(List<Player> players)
        {
            var topTenPlayers = new List<Player>();
            players.Sort(new PlayerComparer());
            int counter = 0;
            foreach (var player in players)
            {
                topTenPlayers.Add(player);
                counter++;
                if (counter == 10)
                {
                    break;
                }
            }
            return topTenPlayers;
        }

        public static void SerializePlayersToFile(List<Player> players, string fileName)
        {
            var serializer = new JsonSerializer();
            using (var writer = new StreamWriter(fileName))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, players);
            }
        }

        public static string GetGoogleHomePage()
        {
            var webClient = new WebClient();
            byte[] googleHome = webClient.DownloadData("https://www.google.com");
            using (var stream = new MemoryStream(googleHome))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public static List<NewsResult> GetNewsForPlayer(string playerName)
        {
            var results = new List<NewsResult>();
            var webClient = new WebClient();
            webClient.Headers.Add("Ocp-Apim-Subscription-Key", "30f02522da984667bde8175421b59569");
            byte[] searchResults = webClient.DownloadData(string.Format("https://api.cognitive.microsoft.com/bing/v7.0/news/search?q={0}&mkt=en-us", playerName));
            var serializer = new JsonSerializer();
            using (var stream = new MemoryStream(searchResults))
            using (var reader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(reader))
            {
                results = serializer.Deserialize<NewsSearch>(jsonReader).NewsResults;
            }
            int index = 0;
            foreach (var result in results)
            {
                result.SentimentId = result.Headline + index.ToString();
                index ++;
            }
            return results;
        }

        public static SentimentResponse GetSentimentResponse(List<NewsResult> newsResults)
        {
            var sentimentResponse = new SentimentResponse();
            var sentimentRequest = new SentimentRequest();
            sentimentRequest.Documents = new List<Document>();
            foreach (var result in newsResults)
            {
                sentimentRequest.Documents.Add(new Document { Id = result.SentimentId, Text = result.Summary });
            }
            var webClient = new WebClient();
            webClient.Headers.Add("Ocp-Apim-Subscription-Key", "364c7692b83247139c69060b3e40d396");
            webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            string requestJson = JsonConvert.SerializeObject(sentimentRequest);
            byte[] requestBytes = Encoding.UTF8.GetBytes(requestJson);
            string endpoint = "cyadehn-th-textanalytics.cognitiveservices.azure.com";
            byte[] response;
            try
            {
                response = webClient.UploadData(string.Format("https://{0}/text/analytics/v3.0/sentiment", endpoint), requestBytes);
                ITraceWriter traceWriter = new MemoryTraceWriter();
                string sentiments = Encoding.UTF8.GetString(response);
                sentimentResponse = JsonConvert.DeserializeObject<SentimentResponse>(sentiments, new JsonSerializerSettings { TraceWriter = traceWriter });
            }
            catch(WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return sentimentResponse;
        }
    }
}
