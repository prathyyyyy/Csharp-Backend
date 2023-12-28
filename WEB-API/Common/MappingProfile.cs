using AutoMapper;
using WorldAPI.DTO.Country;
using WorldAPI.DTO.State;
using WorldAPI.Models;

namespace WorldAPI.Common
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //source , destination
            CreateMap<Countries,CreateCountryDTO>().ReverseMap();
            CreateMap<Countries, CountryDTO>().ReverseMap();
            CreateMap<Countries, UpdateCountryDTO>().ReverseMap();
            CreateMap<State, CreateStatesDTO>().ReverseMap();
            CreateMap<State, StatesDTO>().ReverseMap();
            CreateMap<State, UpdateStatesDTO>().ReverseMap();
        }
    }
}
