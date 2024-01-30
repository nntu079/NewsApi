using System.ComponentModel.DataAnnotations;

namespace NewsApi.Model.Response
{
    public class AuthorResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
