using MeetupSantander.API.Domain;
using MeetupSantander.API.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeetupSantander.API.Test.Repository
{
    public class MeetupRepositoryTest : IMeetupRepository
    {
        private readonly List<Meetup> _meetupList;

        public MeetupRepositoryTest()
        {
            _meetupList = new List<Meetup>()
            {
                new Meetup() { 
                    Id = 1,
                    Name = "Meetup 1",
                    Location ="buenosaires,ar",
                    Inscription = new List<Inscription>() {
                        new Inscription() { 
                            UserId = 1,
                            MeetupId = 1,
                            Due = DateTime.Now,
                            Checkin = false
                        },
                        new Inscription() {
                            UserId = 2,
                            MeetupId = 1,
                            Due = DateTime.Now,
                            Checkin = true
                        }
                    },
                    Due = DateTime.Now 
                },
                new Meetup() {
                    Id = 2,
                    Name = "Meetup 2",
                    Location ="london,uk",
                    Due = DateTime.Now
                },
                new Meetup() {
                    Id = 3,
                    Name = "Meetup 3",
                    Location ="buenosaires,ar",
                    Due = DateTime.Now
                },
                new Meetup() {
                    Id = 4,
                    Name = "Meetup 4",
                    Location="buenosaires,ar",
                    Due = DateTime.Now
                }

            };
        }

        public Meetup createMeetup(Meetup meetup)
        {
            return meetup;
        }

        public Meetup getMeetupById(int id)
        {
            return _meetupList.Where(m => m.Id == id).FirstOrDefault();
        }

        public IList<Meetup> getMeetupList()
        {
            return _meetupList;
        }
    }
}
