using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewsApi.Data;
using NewsApi.Model.Request;
using NewsApi.Model.Response;
using NewsApi.Repository.Interface;

namespace NewsApi.Repository.Implement
{
    public class SourceRepository : ISourceRepository
    {
        private NewsContext _context;
        private IMapper _mapper;

        public SourceRepository(NewsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SourceResponse> addSourceAsync(SourceRequest source)
        {
            var newSource = new Source
            {
                Id = new Guid(),
                Name = source.Name,
            };

            _context.Sources.Add(newSource);
            await _context.SaveChangesAsync();

            return _mapper.Map<SourceResponse>(newSource);
        }

        public async Task<List<SourceResponse>> getSourcesAsync()
        {
            var result = await _context.Sources.ToListAsync();

            return _mapper.Map<List<SourceResponse>>(result);
        }
    }
}
