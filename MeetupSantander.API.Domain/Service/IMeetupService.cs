using System.Collections.Generic;

namespace MeetupSantander.API.Domain.Service
{
    public interface IMeetupService
    {
        Meetup createMeetup(Meetup meetup);
        IList<Meetup> getMeetupList();
        Meetup getMeetupById(int id);
    }
}
