using Microsoft.AspNetCore.Mvc;
using NewsApi.Model.Request;
using NewsApi.Model.Response;
using NewsApi.Repository.Interface;

namespace NewsApi.Controllers
{
    [Route("api/sources")]
    [ApiController]
    public class SourcesController : ControllerBase
    {
        private readonly ISourceRepository _sourceRepository;

        public SourcesController(ISourceRepository sourceRepository)
        {
            _sourceRepository = sourceRepository;
        }

        [HttpGet("get-sources")]
        public async Task<ActionResult<IEnumerable<SourceResponse>>> GetSources()
        {
            return await _sourceRepository.getSourcesAsync();
        }

        [HttpPost("add-source")]
        public async Task<ActionResult<SourceResponse>> PostSource(SourceRequest source)
        {
            var sourceReponse = await _sourceRepository.addSourceAsync(source);

            return Ok(sourceReponse);
        }
    }
}
