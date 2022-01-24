using MeetupSantander.API.Domain.Repository;

namespace MeetupSantander.API.Domain.Service.Impl
{
    public class InscriptionServiceImpl : IInscriptionService
    {
        private IInscriptionRepository _inscriptionRepository { get; set; }

        public InscriptionServiceImpl(IInscriptionRepository inscriptionRepository)
        {
            _inscriptionRepository = inscriptionRepository;
        }

        public Inscription createInscription(Inscription inscription)
        {
            // Performs inscription for a meetup
            return _inscriptionRepository.createInscription(inscription);
        }

        public Inscription checkinInscription(Inscription inscription)
        {
            // Performs checkin for a meetup
            return _inscriptionRepository.checkinInscription(inscription);
        }
    }
}
