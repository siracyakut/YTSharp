using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using YTSharp.Business.Abstract;
using YTSharp.Data.Models;

namespace YTSharp.Business.Concrete
{
    public class SearchManager : ISearchManager
    {
        public async Task<List<SearchResult>> GetResults(string query)
        {
            if (string.IsNullOrWhiteSpace(query) ||
                query.Length > 50)
            {
                return null!;
            }

            WebClient wc = new WebClient();
            byte[] raw = await wc.DownloadDataTaskAsync($"https://www.youtube.com/results?search_query={query}");
            string url = Encoding.UTF8.GetString(raw);

            List<SearchResult> list = new List<SearchResult>();

            foreach (Match match in Regex.Matches(url, "{\"videoRenderer\":{\"videoId\":\"(?<id>.*?)\"(.*?)\"title\":{\"runs\":\\[{\"text\":\"(?<title>.*?)\"}\\](.*?)\"lengthText\"(.*?)\"simpleText\":\"(?<length>.*?)\"}", RegexOptions.IgnoreCase))
            {
                SearchResult result = new SearchResult()
                {
                    Id = match.Groups["id"].Value,
                    Title = match.Groups["title"].Value,
                    Length = getSeconds(match.Groups["length"].Value),
                    Thumbnail = $"https://i.ytimg.com/vi/{match.Groups["id"].Value}/hqdefault.jpg"
                };
                list.Add(result);
            }

            return list;
        }

        public async Task<List<SearchResult>> GetResultsByCount(string query, int count)
        {
            if (string.IsNullOrWhiteSpace(query) ||
                query.Length > 50 ||
                count <= 0)
            {
                return null!;
            }

            WebClient wc = new WebClient();
            byte[] raw = await wc.DownloadDataTaskAsync($"https://www.youtube.com/results?search_query={query}");
            string url = Encoding.UTF8.GetString(raw);

            List<SearchResult> list = new List<SearchResult>();
            int cnt = 0;

            foreach (Match match in Regex.Matches(url, "{\"videoRenderer\":{\"videoId\":\"(?<id>.*?)\"(.*?)\"title\":{\"runs\":\\[{\"text\":\"(?<title>.*?)\"}\\](.*?)\"lengthText\"(.*?)\"simpleText\":\"(?<length>.*?)\"}", RegexOptions.IgnoreCase))
            {
                if (match.Success)
                {
                    SearchResult result = new SearchResult()
                    {
                        Id = match.Groups["id"].Value,
                        Title = match.Groups["title"].Value,
                        Length = getSeconds(match.Groups["length"].Value),
                        Thumbnail = $"https://i.ytimg.com/vi/{match.Groups["id"].Value}/hqdefault.jpg"
                    };
                    list.Add(result);
                    cnt++;
                    if (cnt == count) break;
                }
            }

            return list;
        }

        private int getSeconds(string length)
        {
            var array = length.Split(':');
            int seconds = 0;
            if (array.Length == 2)
            {
                seconds += int.Parse(array[1]);
                seconds += int.Parse(array[0]) * 60;
            }
            else if (array.Length == 3)
            {
                seconds += int.Parse(array[2]);
                seconds += int.Parse(array[1]) * 60;
                seconds += int.Parse(array[0]) * 3600;
            }
            return seconds;
        }
    }
}
