using MeetupSantander.API.Data.Contexts;
using MeetupSantander.API.Data.Entities;
using MeetupSantander.API.Data.Exceptions;
using MeetupSantander.API.Data.Mappers;
using MeetupSantander.API.Domain.Repository;
using System;
using System.Linq;

namespace MeetupSantander.API.Data.Repository.Impl
{
    public class UserEntityRepositoryImpl : IUserRepository
    {
        public Domain.User userLogin(string username, string password)
        {
            // Performs login. Returns User object if exists

            try
            {
                using (MeetupSantanderDbContext context = new MeetupSantanderDbContext())
                {
                    User userEntity = context.User
                        .FirstOrDefault(UserEntity => UserEntity.Username == username && UserEntity.Password == password);

                    if (userEntity == null) return null;

                    return AutoMapperConfiguration.Mapper.Map<Domain.User>((object)userEntity);
                }
            }
            catch (Exception e)
            {
                throw new DataException("Error obtaining user");
            }
        }
    }
}
