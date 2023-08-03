using YTSharp.Data.Models;

namespace YTSharp.Business.Abstract
{
    public interface ISearchManager
    {
        Task<List<SearchResult>> GetResults(string query);
        Task<List<SearchResult>> GetResultsByCount(string query, int count);
    }
}
