namespace MeetupSantander.API.Domain.Service
{
    public interface IInscriptionService
    {
        Inscription createInscription(Inscription inscription);
        Inscription checkinInscription(Inscription inscription);
    }
}
