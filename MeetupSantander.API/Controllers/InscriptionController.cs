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
    public class InscriptionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IInscriptionService _inscriptionService { get; set; }

        public InscriptionController(IMapper mapper, IInscriptionService inscriptionService)
        {
            _mapper = mapper;
            _inscriptionService = inscriptionService;
        }

        [HttpPost]
        [Authorize]
        public InscriptionDTO createInscription(InscriptionDTO inscriptionDTO)
        {
            // Performs an inscription
            Inscription inscription = _mapper.Map<Inscription>(inscriptionDTO);
            inscription = _inscriptionService.createInscription(inscription);
            return _mapper.Map<InscriptionDTO>(inscription);
        }

        [HttpPut]
        [Authorize]
        public InscriptionDTO checkinInscription(InscriptionDTO inscriptionDTO)
        {
            // Performs a checkin to a meetup
            Inscription inscription = _mapper.Map<Inscription>(inscriptionDTO);
            inscription = _inscriptionService.checkinInscription(inscription);
            return _mapper.Map<InscriptionDTO>(inscription);
        }
    }
}