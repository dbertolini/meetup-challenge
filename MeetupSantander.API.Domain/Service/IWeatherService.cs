namespace MeetupSantander.API.Domain.Service
{
    public interface IWeatherService
    {
        Weather getWeatherByMeetup(int id);
    }
}
