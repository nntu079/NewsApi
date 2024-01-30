using NewsApi.Data;
using NewsApi.Model.Request;
using NewsApi.Model.Response;

namespace NewsApi.Repository.Interface
{
    public interface INewsRepository
    {
        public Task<NewsReponse> addNewsAsync(NewsRequest news);
        public Task<List<NewsReponse>> getNewsAsync(int pageIndex = 1, int pageSize = 2);

        public Task<NewsReponse> getNewsDetailAsync(string id);
    }
}
