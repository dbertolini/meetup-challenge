using AutoMapper;
using MeetupSantander.API.Contract.DTO;
using MeetupSantander.API.Domain;

namespace MeetupSantander.API.Mappers.Profiles
{
    public class BeerProfile : Profile
    {
        public BeerProfile()
        {
            CreateMap<BeerDTO, Beer>().ReverseMap();
        }
    }
}
