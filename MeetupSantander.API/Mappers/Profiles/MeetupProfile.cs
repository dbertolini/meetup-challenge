using AutoMapper;
using MeetupSantander.API.Contract.DTO;
using MeetupSantander.API.Domain;

namespace MeetupSantander.API.Mappers.Profiles
{
    public class MeetupProfile : Profile
    {
        public MeetupProfile()
        {
            CreateMap<MeetupDTO, Meetup>().ReverseMap();
        }
    }
}
