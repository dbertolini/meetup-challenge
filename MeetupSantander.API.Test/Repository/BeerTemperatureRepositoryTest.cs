using MeetupSantander.API.Domain;
using MeetupSantander.API.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeetupSantander.API.Test.Repository
{
    public class BeerTemperatureRepositoryTest : IBeerTemperatureRepository
    {
        private readonly List<BeerTemperature> _beerTemperatureList;

        public BeerTemperatureRepositoryTest()
        {
            _beerTemperatureList = new List<BeerTemperature>()
            {
                new BeerTemperature() {
                    Id = 1,
                    TemperatureMin = 20,
                    TemperatureMax = 24,
                    BeersPerPerson = 1,
                    BeersPerBox = 6
                },
                new BeerTemperature() {
                    Id = 2,
                    TemperatureMin = -50,
                    TemperatureMax = 19.99m,
                    BeersPerPerson = 0.75m,
                    BeersPerBox = 6
                },
                new BeerTemperature() {
                    Id = 3,
                    TemperatureMin = 24.01m,
                    TemperatureMax = 50,
                    BeersPerPerson = 2,
                    BeersPerBox = 6
                }

            };
        }

        public BeerTemperature getBeersPerPersonByTemperature(decimal? temperature)
        {
            return _beerTemperatureList.Where(bt => bt.TemperatureMin <= temperature && bt.TemperatureMax >= temperature).FirstOrDefault();
        }
    }
}
