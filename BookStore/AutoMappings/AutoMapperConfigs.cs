using AutoMapper;
using BookStore.Models.Data;
using BookStore.Models.Request;

namespace BookStore.AutoMappings
{
    public class AutoMapperConfigs : Profile
    {
        public AutoMapperConfigs()
        {
            CreateMap<AddAuthorRequest, Author>();
        }
    }
}
