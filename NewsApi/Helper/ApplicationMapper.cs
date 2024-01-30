using AutoMapper;
using NewsApi.Data;
using NewsApi.Model.Request;
using NewsApi.Model.Response;

namespace MyApiNetCore6.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Author, AuthorRequest>().ReverseMap();
            CreateMap<Author, AuthorResponse>().ReverseMap();

            CreateMap<Source, SourceRequest>().ReverseMap();
            CreateMap<Source, SourceResponse>().ReverseMap();
        }
    }
}