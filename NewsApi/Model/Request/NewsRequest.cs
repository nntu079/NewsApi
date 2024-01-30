using System.ComponentModel.DataAnnotations;

namespace NewsApi.Model.Request
{
    public class NewsRequest
    {

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Image { get; set; } = string.Empty;

        [Required]
        public DateTime PublishedAt { get; set; } = DateTime.Now;

        [Required]
        public string Content { get; set; } = string.Empty;

        [Required]
        public ICollection<string> AuthorIds { get; set; } = new List<string>();

        [Required]
        public string sourceId { get; set; } = string.Empty;
    }
}