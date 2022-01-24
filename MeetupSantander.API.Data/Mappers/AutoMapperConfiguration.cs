using AutoMapper;
using MeetupSantander.API.Data.Mappers.Profiles;
using System;

namespace MeetupSantander.API.Data.Mappers
{
    public class AutoMapperConfiguration
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<MeetupProfile>();
                cfg.AddProfile<InscriptionProfile>();
                cfg.AddProfile<BeerTemperatureProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }
}
