using System.Collections.Generic;

namespace MeetupSantander.API.Contract.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public virtual ICollection<InscriptionDTO> Inscription { get; set; }
    }
}
