using MeetupSantander.API.Domain;
using MeetupSantander.API.Domain.Repository;
using MeetupSantander.API.Domain.Service;
using MeetupSantander.API.Domain.Service.Impl;
using MeetupSantander.API.Test.Repository;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MeetupSantander.API.Test
{
    public class BeerControllerTest
    {
        IBeerService _beerService;
        IWeatherService _weatherService;
        IMeetupService _meetupService;
        IBeerTemperatureRepository _beerTemperatureRepository;
        IMeetupRepository _meetupRepository;

        public BeerControllerTest()
        {
            _beerTemperatureRepository = new BeerTemperatureRepositoryTest();
            _meetupRepository = new MeetupRepositoryTest();
            _meetupService = new MeetupServiceImpl(_meetupRepository);
            _weatherService = new WeatherServiceImpl(_meetupService);
            _beerService = new BeerServiceImpl(_weatherService, _beerTemperatureRepository, _meetupService);
        }

        [Fact]
        public void getBeerBoxQuantityByMeetup()
        {
            // Act
            var okResult = _beerService.getBeerBoxQuantityByMeetup(1);

            // Assert
            var items = Assert.IsType<Beer>(okResult);
            Assert.Equal(1, items.Quantity);
        }
    }
}
