
using Microsoft.AspNetCore.Mvc;
using NewsApi.Data;
using NewsApi.Model.Request;
using NewsApi.Model.Response;
using NewsApi.Repository.Interface;

namespace NewsApi.Controllers
{
    [Route("api/news")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepository _newsRepository;

        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        [HttpGet("get-newses/{page}")]
        public async Task<ActionResult<IEnumerable<NewsReponse>>> GetNewses(int page)
        {
            return await _newsRepository.getNewsAsync(page);
        }

        [HttpGet("get-news/{id}")]
        public async Task<ActionResult<NewsReponse>> GetNewsDetail(string id)
        {
            return await _newsRepository.getNewsDetailAsync(id);
        }

        [HttpPost("add-news")]
        public async Task<ActionResult<NewsReponse>> PostNews(NewsRequest request)
        {
            var newsResponse = await _newsRepository.addNewsAsync(request);

            return Ok(newsResponse);
        }
    }
}
