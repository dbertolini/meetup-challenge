using System;

namespace MeetupSantander.API.Data.Entities
{
    public class Inscription
    {
        public int UserId { get; set; }
        public int MeetupId { get; set; }
        public DateTime Due { get; set; }
        public bool Checkin { get; set; }

        public virtual Meetup Meetup { get; set; }
        public virtual User User { get; set; }
    }
}
