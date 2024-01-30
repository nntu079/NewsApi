using NewsApi.Model.Request;
using NewsApi.Model.Response;

namespace NewsApi.Repository.Interface
{
    public interface IAuthorRepository
    {
        public Task<AuthorResponse> addAuthorAsync(AuthorRequest author);
        public Task<List<AuthorResponse>> getAuthorsAsync();
    }
}
