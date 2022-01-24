using AutoMapper;
using MeetupSantander.API.Contract.DTO;
using MeetupSantander.API.Domain;

namespace MeetupSantander.API.Mappers.Profiles
{
    public class InscriptionProfile : Profile
    {
        public InscriptionProfile()
        {
            CreateMap<InscriptionDTO, Inscription>().ReverseMap();
        }
    }
}
