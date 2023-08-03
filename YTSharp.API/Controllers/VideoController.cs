using Microsoft.AspNetCore.Mvc;
using YTSharp.Business.Abstract;
using YTSharp.Data.Models;

namespace YTSharp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IVideoManager _videoManager;
        public VideoController(IVideoManager videoManager)
        {
            _videoManager = videoManager;
        }

        [HttpGet("{videoId}")]
        public async Task<SingleVideo> Get(string videoId)
        {
            return await _videoManager.GetAllInfo(videoId);
        }
    }
}
