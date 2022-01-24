using System.Collections.Generic;

namespace MeetupSantander.API.Domain.Repository
{
    public interface IMeetupRepository
    {
        Meetup createMeetup(Meetup meetup);
        IList<Meetup> getMeetupList();
        Meetup getMeetupById(int id);
    }
}
