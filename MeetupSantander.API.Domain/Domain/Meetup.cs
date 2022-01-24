using System;
using System.Collections.Generic;

namespace MeetupSantander.API.Domain
{
    public class Meetup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Due { get; set; }
        public virtual ICollection<Inscription> Inscription { get; set; }
    }
}
