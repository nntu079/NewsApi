using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsApi.Data
{
    [Table("News")]
    public class News
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Image {  get; set; } = string.Empty;

        [Required]
        public DateTime PublishedAt { get; set; } = DateTime.Now;

        [Required]
        public string Content { get; set; } = string.Empty;

        [Required]
        public ICollection<Author> Authors { get; set; } = new List<Author>();
        public Source Source { get; set; } = new Source();
    }
}
