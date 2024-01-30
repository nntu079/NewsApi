using NewsApi.Model.Request;
using NewsApi.Model.Response;

namespace NewsApi.Repository.Interface
{
    public interface ISourceRepository
    {
        public Task<SourceResponse> addSourceAsync(SourceRequest source);
        public Task<List<SourceResponse>> getSourcesAsync();
    }
}
