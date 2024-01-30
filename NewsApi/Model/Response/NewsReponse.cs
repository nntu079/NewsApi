using NewsApi.Data;
using System.ComponentModel.DataAnnotations;

namespace NewsApi.Model.Response
{
    public class NewsReponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public DateTime PublishedAt { get; set; } = DateTime.Now;
        public string Content { get; set; } = string.Empty;
        public ICollection<AuthorResponse> Authors { get; set; } = new List<AuthorResponse>();
        public SourceResponse Source { get; set; } = new SourceResponse();
    }
}
