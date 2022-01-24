using AutoMapper;

namespace MeetupSantander.API.Data.Mappers.Profiles
{
    public class BeerTemperatureProfile : Profile
    {
        public BeerTemperatureProfile()
        {
            CreateMap<Entities.BeerTemperature, Domain.BeerTemperature>().ReverseMap();
        }
    }
}
