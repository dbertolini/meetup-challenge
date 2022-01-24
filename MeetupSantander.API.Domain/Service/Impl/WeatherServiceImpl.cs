using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MeetupSantander.API.Domain.Service.Impl
{
    public class WeatherAPIResponseDetail
    {
        public DateTime validTime { get; set; }
        public int avgTempC { get; set; }
    }

    public class WeatherServiceImpl : IWeatherService
    {
        private IMeetupService _meetupService { get; set; }
        public string _weatherAPIUrl = string.Empty;
        public string _weatherAPIHost = string.Empty;
        public string _weatherAPIKey = string.Empty;

        public WeatherServiceImpl(IMeetupService meetupService)
        {
            _meetupService = meetupService;
        }

        public Weather getWeatherByMeetup(int id)
        {
            // Gets the weather by a meetup

            // Gets the Meetup object to have Date and Location
            Meetup meetup = _meetupService.getMeetupById(id);

            // Calls to the API to get the json with the temperature 
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            var root = configurationBuilder.Build();
            _weatherAPIUrl = root.GetSection("WeatherAPI").GetSection("WeatherAPIUrl").Value;
            _weatherAPIHost = root.GetSection("WeatherAPI").GetSection("WeatherAPIHost").Value;
            _weatherAPIKey = root.GetSection("WeatherAPI").GetSection("WeatherAPIKey").Value;

            var client = new RestClient(_weatherAPIUrl + "/" + meetup.Location);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", _weatherAPIHost);
            request.AddHeader("x-rapidapi-key", _weatherAPIKey);
            IRestResponse response = client.Execute(request);

            // Deserialize the content of the result where we have the temperature
            JObject jsonResult = JObject.Parse(response.Content.ToString());
            List<WeatherAPIResponseDetail> weatherAPIResponseDetail = (List<WeatherAPIResponseDetail>)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonResult["response"][0]["periods"].ToString(), typeof(List<WeatherAPIResponseDetail>));

            // Return the Weather object
            Weather weather = new Weather();
            weather.Due = meetup.Due;
            weather.Location = meetup.Location;

            WeatherAPIResponseDetail filteredWeatherAPIResponseDetail = new WeatherAPIResponseDetail();
            filteredWeatherAPIResponseDetail = weatherAPIResponseDetail.Where(r => r.validTime.Date == meetup.Due.Date).FirstOrDefault();
            if (filteredWeatherAPIResponseDetail != null)
                weather.Temperature = filteredWeatherAPIResponseDetail.avgTempC;

            return weather;
        }
    }
}
