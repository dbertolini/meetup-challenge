using AutoMapper;
using MeetupSantander.API.Contract.DTO;
using MeetupSantander.API.Domain;
using MeetupSantander.API.Domain.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeetupSantander.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IWeatherService _weatherService { get; set; }

        public WeatherController(IMapper mapper, IWeatherService weatherService)
        {
            _mapper = mapper;
            _weatherService = weatherService;
        }

        [HttpGet]
        [Authorize]
        [Route("{id:int}")]
        public WeatherDTO getWeatherByMeetup(int id)
        {
            return _mapper.Map<WeatherDTO>(_weatherService.getWeatherByMeetup(id));
        }
    }
}