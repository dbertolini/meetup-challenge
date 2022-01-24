using AutoMapper;

namespace MeetupSantander.API.Data.Mappers.Profiles
{
    public class InscriptionProfile : Profile
    {
        public InscriptionProfile()
        {
            CreateMap<Entities.Inscription, Domain.Inscription>().ReverseMap();
        }
    }
}
