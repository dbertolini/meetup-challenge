using AutoMapper;
using MeetupSantander.API.Contract.DTO;
using MeetupSantander.API.Domain;
using MeetupSantander.API.Domain.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MeetupSantander.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetupController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IMeetupService _meetupService { get; set; }

        public MeetupController(IMapper mapper, IMeetupService meetupService)
        {
            _mapper = mapper;
            _meetupService = meetupService;
        }

        [HttpGet]
        [Authorize]
        public IList<MeetupDTO> getMeetupList()
        {
            // Gets all the meetups from database
            return _mapper.Map<List<MeetupDTO>>(_meetupService.getMeetupList());
        }

        [HttpGet]
        [Authorize]
        [Route("{id:int}")]
        public MeetupDTO getMeetupById(int id)
        {
            // Gets a single meetup by id
            return _mapper.Map<MeetupDTO>(_meetupService.getMeetupById(id));
        }

        [HttpPost]
        [Authorize]
        public MeetupDTO createMeetup(MeetupDTO meetupDTO)
        {
            // Create a meetup
            Meetup meetup = _mapper.Map<Meetup>(meetupDTO);
            meetup = _meetupService.createMeetup(meetup);
            return _mapper.Map<MeetupDTO>(meetup);
        }
    }
}