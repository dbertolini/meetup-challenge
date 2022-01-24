using System;
using System.Collections.Generic;

namespace MeetupSantander.API.Data.Entities
{
    public class Meetup
    {
        public Meetup()
        {
            Inscription = new HashSet<Inscription>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Due { get; set; }

        public virtual ICollection<Inscription> Inscription { get; set; }
    }
}
