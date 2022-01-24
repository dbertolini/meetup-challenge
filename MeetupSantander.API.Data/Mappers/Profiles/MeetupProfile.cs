using AutoMapper;

namespace MeetupSantander.API.Data.Mappers.Profiles
{
    public class MeetupProfile : Profile
    {
        public MeetupProfile()
        {
            CreateMap<Entities.Meetup, Domain.Meetup>().ReverseMap();
        }
    }
}
