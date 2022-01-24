using AutoMapper;

namespace MeetupSantander.API.Data.Mappers.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Entities.User, Domain.User>().ReverseMap();
        }
    }
}
