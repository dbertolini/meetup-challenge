using System.Collections.Generic;

namespace MeetupSantander.API.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public virtual ICollection<Inscription> Inscription { get; set; }
    }
}
