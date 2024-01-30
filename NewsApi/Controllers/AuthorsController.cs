
using Microsoft.AspNetCore.Mvc;
using NewsApi.Data;
using NewsApi.Model.Request;
using NewsApi.Model.Response;
using NewsApi.Repository.Interface;

namespace NewsApi.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet("get-authors")]
        public async Task<ActionResult<IEnumerable<AuthorResponse>>> GetAuthors()
        {
            return await _authorRepository.getAuthorsAsync();
        }

        [HttpPost("add-author")]
        public async Task<ActionResult<AuthorResponse>> PostAuthor(AuthorRequest author)
        {
            var authorResponse = await _authorRepository.addAuthorAsync(author);

            return Ok(authorResponse);
        }
    }
}
