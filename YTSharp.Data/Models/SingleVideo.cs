namespace YTSharp.Data.Models
{
    public class SingleVideo
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public int Length { get; set; }
        public string? ChannelId { get; set; }
        public string? ChannelName { get; set; }
        public string? Description { get; set; }
        public long ViewCount { get; set; }
        public long LikeCount { get; set; }
        public string? Thumbnail { get; set; }
    }
}
