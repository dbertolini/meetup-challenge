using AutoMapper;
using MeetupSantander.API.Contract.DTO;
using MeetupSantander.API.Domain;

namespace MeetupSantander.API.Mappers.Profiles
{
    public class WeatherProfile : Profile
    {
        public WeatherProfile()
        {
            CreateMap<WeatherDTO, Weather>().ReverseMap();
        }
    }
}
