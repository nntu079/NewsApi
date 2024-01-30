using Microsoft.EntityFrameworkCore;

namespace NewsApi.Data
{
    public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> opt) : base(opt)
        {

        }

        #region DbSet
        public DbSet<News>? News { get; set; }
        public DbSet<Author>? Authors { get; set; }
        public DbSet<Source>? Sources { get; set; }
        #endregion
    }
}
