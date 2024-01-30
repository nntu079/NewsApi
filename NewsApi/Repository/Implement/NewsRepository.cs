using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewsApi.Data;
using NewsApi.Model.Request;
using NewsApi.Model.Response;
using NewsApi.Repository.Interface;

namespace NewsApi.Repository.Implement
{
    public class NewsRepository : INewsRepository
    {
        private NewsContext _context;
        private IMapper _mapper;

        public NewsRepository(NewsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<NewsReponse> addNewsAsync(NewsRequest news)
        {

            var authors = new List<Author>();

            foreach (var authorId in news.AuthorIds)
            {
                var author = await _context.Authors.FindAsync(Guid.Parse(authorId));
                authors.Add(author);
            }

            var source = await _context.Sources.FindAsync(Guid.Parse(news.sourceId));


            var newNews = new News
            {
                Id = new Guid(),
                Title = news.Title,
                Image = news.Image,
                PublishedAt = news.PublishedAt,
                Content = news.Content,
                Authors = authors,
                Source = source,
            };

            await _context.News.AddAsync(newNews);

            await _context.SaveChangesAsync();

            return new NewsReponse
            {
                Id = newNews.Id,
                Title = newNews.Title,
                Image = newNews.Image,
                PublishedAt = newNews.PublishedAt,
                Content = newNews.Content,
                Authors = _mapper.Map<List<AuthorResponse>>(newNews.Authors),
                Source = _mapper.Map<SourceResponse>(newNews.Source)
            };
        }

        public async Task<List<NewsReponse>> getNewsAsync(int pageIndex = 1, int pageSize = 2)
        {
            var newses = await _context.News.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            var result = new List<NewsReponse>();

            foreach (var item in newses)
            {

                var news1 = await _context.News.Include(n => n.Authors).Where(n => n.Id == item.Id).FirstAsync();
                var news2 = await _context.News.Include(n => n.Source).Where(n => n.Id == item.Id).FirstAsync();


                result.Add(new NewsReponse
                {
                    Id = item.Id,
                    Title = item.Title,
                    Image = item.Image,
                    PublishedAt = item.PublishedAt,
                    Content = item.Content,
                    Authors = _mapper.Map<List<AuthorResponse>>(news1.Authors),
                    Source = _mapper.Map<SourceResponse>(news2.Source)
                });
            }

            return result;
        }

        public async Task<NewsReponse> getNewsDetailAsync(string id)
        {
            var newses = await _context.News.FindAsync(Guid.Parse(id));

            var news1 = await _context.News.Include(n => n.Authors).Where(n => n.Id == newses.Id).FirstAsync();
            var news2 = await _context.News.Include(n => n.Source).Where(n => n.Id == newses.Id).FirstAsync();

            var result = new NewsReponse
            {
                Id = newses.Id,
                Title = newses.Title,
                Image = newses.Image,
                PublishedAt = newses.PublishedAt,
                Content = newses.Content,
                Authors = _mapper.Map<List<AuthorResponse>>(news1.Authors),
                Source = _mapper.Map<SourceResponse>(news2.Source)
            };

            return result;
        }
    }
}