namespace MeetupSantander.API.Domain.Repository
{
    public interface IInscriptionRepository
    {
        Inscription createInscription(Inscription inscription);
        Inscription checkinInscription(Inscription inscription);
    }
}
