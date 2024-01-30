using System.ComponentModel.DataAnnotations;

namespace NewsApi.Model.Request
{
    public class AuthorRequest
    {
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
    }
}