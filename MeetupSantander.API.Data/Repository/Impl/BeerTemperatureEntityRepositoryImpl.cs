using MeetupSantander.API.Data.Contexts;
using MeetupSantander.API.Data.Entities;
using MeetupSantander.API.Data.Exceptions;
using MeetupSantander.API.Data.Mappers;
using MeetupSantander.API.Domain.Repository;
using System;
using System.Linq;

namespace MeetupSantander.API.Data.Repository.Impl
{
    public class BeerTemperatureEntityRepositoryImpl : IBeerTemperatureRepository
    {
        public Domain.BeerTemperature getBeersPerPersonByTemperature(Nullable<decimal> temperature)
        {
            // Get the quantity of beers per person and per boxes by the temperature
            try
            {
                using (MeetupSantanderDbContext context = new MeetupSantanderDbContext())
                {
                    BeerTemperature beerTemperatureEntity = context.BeerTemperature.Where(bt => bt.TemperatureMin <= temperature && bt.TemperatureMax >= temperature).FirstOrDefault();

                    return AutoMapperConfiguration.Mapper.Map<Domain.BeerTemperature>((object)beerTemperatureEntity);
                }
            }
            catch (Exception e)
            {
                throw new DataException("Error getting the beer quantity by temperature");
            }
        }
    }
}