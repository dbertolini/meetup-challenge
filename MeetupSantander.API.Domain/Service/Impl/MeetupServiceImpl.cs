using MeetupSantander.API.Domain.Repository;
using System.Collections.Generic;

namespace MeetupSantander.API.Domain.Service.Impl
{
    public class MeetupServiceImpl : IMeetupService
    {
        private IMeetupRepository _meetupRepository { get; set; }

        public MeetupServiceImpl(IMeetupRepository meetupRepository)
        {
            _meetupRepository = meetupRepository;
        }

        public Meetup createMeetup(Meetup meetup)
        {
            // Performs creation of Meetup. 
            return _meetupRepository.createMeetup(meetup);
        }

        public IList<Meetup> getMeetupList()
        {
            // Get all the meetups previously saved into the database
            return _meetupRepository.getMeetupList();
        }

        public Meetup getMeetupById(int id)
        {
            // Get the meetup epecify by the Id as parameter
            return _meetupRepository.getMeetupById(id);
        }
    }
}
