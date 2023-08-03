using Microsoft.AspNetCore.Mvc;
using YTSharp.Business.Abstract;
using YTSharp.Data.Models;

namespace YTSharp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchManager _searchManager;
        public SearchController(ISearchManager searchManager)
        {
            _searchManager = searchManager;
        }

        [HttpGet("{query}")]
        public async Task<List<SearchResult>> Get(string query)
        {
            return await _searchManager.GetResults(query);
        }

        [HttpGet("{query}/{count}")]
        public async Task<List<SearchResult>> Get(string query, int count)
        {
            return await _searchManager.GetResultsByCount(query, count);
        }
    }
}
