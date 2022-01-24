namespace MeetupSantander.API.Domain.Repository
{
    public interface IUserRepository
    {
        User userLogin(string username, string password);
    }
}
