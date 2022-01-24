using System;
using System.Collections.Generic;

namespace MeetupSantander.API.Contract.DTO
{
    public class MeetupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Due { get; set; }
        public virtual ICollection<InscriptionDTO> Inscription { get; set; }
    }
}
