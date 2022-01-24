using System.Collections.Generic;

namespace MeetupSantander.API.Data.Entities
{
    public class User
    {
        public User()
        {
            Inscription = new HashSet<Inscription>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Inscription> Inscription { get; set; }
    }
}
