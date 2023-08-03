using YTSharp.Data.Models;

namespace YTSharp.Business.Abstract
{
    public interface IVideoManager
    {
        Task<SingleVideo> GetAllInfo(string videoId);
    }
}
