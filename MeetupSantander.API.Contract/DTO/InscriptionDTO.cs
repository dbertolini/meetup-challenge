using System;

namespace MeetupSantander.API.Contract.DTO
{
    public class InscriptionDTO
    {
        public virtual UserDTO User { get; set; }
        public virtual MeetupDTO Meetup { get; set; }
        public int UserId { get; set; }
        public int MeetupId { get; set; }
        public DateTime Due { get; set; }
        public bool Checkin { get; set; }
    }
}
