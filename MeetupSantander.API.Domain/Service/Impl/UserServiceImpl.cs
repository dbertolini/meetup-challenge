using MeetupSantander.API.Domain.Exceptions;
using MeetupSantander.API.Domain.Repository;

namespace MeetupSantander.API.Domain.Service.Impl
{
    public class UserServiceImpl : IUserService
    {
        private IUserRepository _userRepository { get; set; }

        public UserServiceImpl(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User userLogin(string username, string password)
        {
            // Performs user's login. 

            User user = _userRepository.userLogin(username, password);

            // Throw DomainException if data is incorrect, when response is null
            if (user == null)
                throw new DomainException("Incorrect username or password");

            return user;
        }
    }
}
