using AutoMapper;
using MeetupSantander.API.Contract.DTO;
using MeetupSantander.API.Domain.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MeetupSantander.API.Domain;

namespace MeetupSantander.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IBeerService _beerService { get; set; }

        public BeerController(IMapper mapper, IBeerService beerService)
        {
            _mapper = mapper;
            _beerService = beerService;
        }

        [HttpGet]
        [Authorize]
        [Route("{id:int}")]
        public BeerDTO getBeerBoxQuantityByMeetupId(int id)
        {
            // Gets the quantity of beer boxes to buy
            return _mapper.Map<BeerDTO>(_beerService.getBeerBoxQuantityByMeetup(id));
        }
    }
}