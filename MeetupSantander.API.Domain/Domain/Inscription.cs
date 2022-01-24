using System;

namespace MeetupSantander.API.Domain
{
    public class Inscription
    {
        public virtual User User { get; set; }
        public virtual Meetup Meetup { get; set; }
        public int UserId { get; set; }
        public int MeetupId { get; set; }
        public DateTime Due { get; set; }
        public bool Checkin { get; set; }
    }
}
