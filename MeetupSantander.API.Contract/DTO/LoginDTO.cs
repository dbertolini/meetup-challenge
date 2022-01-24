using System.Collections.Generic;

namespace MeetupSantander.API.Contract.DTO
{
    public class LoginDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
