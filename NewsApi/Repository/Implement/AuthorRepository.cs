using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NewsApi.Data;
using NewsApi.Model.Request;
using NewsApi.Model.Response;
using NewsApi.Repository.Interface;

namespace NewsApi.Repository.Implement
{
    public class AuthorRepository : IAuthorRepository
    {
        private NewsContext _context;
        private IMapper _mapper;

        public AuthorRepository(NewsContext context, IMapper mapper) { 
            _context = context;
            _mapper = mapper;
        }

        public async Task<AuthorResponse> addAuthorAsync(AuthorRequest author)
        {

            var newAuthor = new Author
            {
                Id = new Guid(),
                Name = author.Name,
            };

            _context.Authors.Add(newAuthor);
            await _context.SaveChangesAsync();

            return _mapper.Map<AuthorResponse>(newAuthor); 
        }

        public async Task<List<AuthorResponse>> getAuthorsAsync()
        {
            var result= await _context.Authors.ToListAsync();

            return _mapper.Map<List<AuthorResponse>>(result);
        }
    }
}