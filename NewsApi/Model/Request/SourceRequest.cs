using System.ComponentModel.DataAnnotations;

namespace NewsApi.Model.Request
{
    public class SourceRequest
    {
       
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

    }
}
