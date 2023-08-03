using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using YTSharp.Business.Abstract;
using YTSharp.Data.Models;

namespace YTSharp.Business.Concrete
{
    public class VideoManager : IVideoManager
    {
        public async Task<SingleVideo> GetAllInfo(string videoId)
        {
            WebClient wc = new WebClient();
            byte[] raw = await wc.DownloadDataTaskAsync($"https://www.youtube.com/watch?v={videoId}");
            string url = Encoding.UTF8.GetString(raw);

            if (url.Contains("LOGIN_REQUIRED") ||
                url.Contains("\"status\":\"ERROR\"") ||
                videoId.Length != 11 ||
                string.IsNullOrWhiteSpace(videoId))
            {
                return null!;
            }

            Match match = Regex.Match(url, "\"videoDetails\":{\"videoId\":\"(?<id>.*?)\",\"title\":\"(?<title>.*?)\",\"lengthSeconds\":\"(?<length>[0-9]+)\",(.*?)\"channelId\":\"(?<channelId>.*?)\",\"isOwnerViewing\":(.*?),\"shortDescription\":\"(?<description>.*?)\"", RegexOptions.IgnoreCase);
            Match match2 = Regex.Match(url, "\"viewCount\":\"(?<view>[0-9]+)\",\"author\":\"(?<author>.*?)\"", RegexOptions.IgnoreCase);
            Match match3 = Regex.Match(url, "\"likeCount\":\"(?<like>[0-9]+)\"", RegexOptions.IgnoreCase);
            SingleVideo video = new SingleVideo();

            if (match.Success)
            {
                video.Id = match.Groups["id"].Value;
                video.Title = match.Groups["title"].Value;
                video.Length = int.Parse(match.Groups["length"].Value);
                video.ChannelId = match.Groups["channelId"].Value;
                video.Description = match.Groups["description"].Value;
                video.Thumbnail = $"https://i.ytimg.com/vi/{video.Id}/hqdefault.jpg";
            }
            
            if (match2.Success)
            {
                video.ChannelName = match2.Groups["author"].Value;
                video.ViewCount = long.Parse(match2.Groups["view"].Value);
            }

            if (match3.Success)
            {
                video.LikeCount = long.Parse(match3.Groups["like"].Value);
            }

            return video;
        }
    }
}
