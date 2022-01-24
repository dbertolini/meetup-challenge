using MeetupSantander.API.Domain.Repository;
using System;
using System.Linq;

namespace MeetupSantander.API.Domain.Service.Impl
{
    public class BeerServiceImpl : IBeerService
    {
        private IWeatherService _weatherService { get; set; }
        private IMeetupService _meetupService { get; set; }
        public IBeerTemperatureRepository _beerTemperatureRepository { get; set; }

        public BeerServiceImpl(IWeatherService weatherService, IBeerTemperatureRepository beerTemperatureRepository, IMeetupService meetupService)
        {
            _weatherService = weatherService;
            _beerTemperatureRepository = beerTemperatureRepository;
            _meetupService = meetupService;
        }

        public Beer getBeerBoxQuantityByMeetup(int id)
        {
            Meetup meetup = _meetupService.getMeetupById(id);
            Nullable<decimal> temperature = _weatherService.getWeatherByMeetup(id).Temperature;
            if (temperature != null && meetup.Inscription != null)
            {
                // Here we have the beers per person and the beers per box
                BeerTemperature beerTemperature = _beerTemperatureRepository.getBeersPerPersonByTemperature(temperature);

                // Beer objet to return with the quantity of boxes
                Beer beer = new Beer();
                beer.Quantity = (int)Math.Ceiling((beerTemperature.BeersPerPerson * meetup.Inscription.Count()) / beerTemperature.BeersPerBox);

                return beer;
            }
            else
            {
                return null;
            }
        }
    }
}
