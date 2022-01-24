using System;

namespace MeetupSantander.API.Domain.Repository
{
    public interface IBeerTemperatureRepository
    {
        BeerTemperature getBeersPerPersonByTemperature(Nullable<decimal> temperature);
    }
}
