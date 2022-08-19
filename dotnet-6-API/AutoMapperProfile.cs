using AutoMapper;
using dotnet_6_API.DTO;

namespace dotnet_6_API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDTO>();
            CreateMap<AddCharacterDTO, Character>();
        }
    }
}
