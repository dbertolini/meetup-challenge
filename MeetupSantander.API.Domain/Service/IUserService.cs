namespace MeetupSantander.API.Domain.Service
{
    public interface IUserService
    {
        User userLogin(string username, string password);
    }
}
