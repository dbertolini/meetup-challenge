using MeetupSantander.API.Data.Contexts;
using MeetupSantander.API.Data.Entities;
using MeetupSantander.API.Data.Exceptions;
using MeetupSantander.API.Data.Mappers;
using MeetupSantander.API.Domain.Repository;
using System;
using System.Linq;

namespace MeetupSantander.API.Data.Repository.Impl
{
    public class InscriptionEntityRepositoryImpl : IInscriptionRepository
    {
        public Domain.Inscription checkinInscription(Domain.Inscription inscription)
        {
            // Insert an inscription into the database
            try
            {
                using (MeetupSantanderDbContext context = new MeetupSantanderDbContext())
                {
                    Inscription inscriptionEntity = context.Inscription.Where(i => i.MeetupId == inscription.MeetupId
                                                                                    && i.UserId == inscription.UserId).FirstOrDefault();
                    inscriptionEntity.Checkin = true;
                    context.SaveChanges();

                    return AutoMapperConfiguration.Mapper.Map<Domain.Inscription>((object)inscriptionEntity);
                }
            }
            catch (Exception e)
            {
                throw new DataException("Error in inscription to meetup");
            }
        }

        public Domain.Inscription createInscription(Domain.Inscription inscription)
        {
            // Insert an inscription into the database
            try
            {
                using (MeetupSantanderDbContext context = new MeetupSantanderDbContext())
                {
                    Entities.Inscription inscriptionEntity = AutoMapperConfiguration.Mapper.Map<Entities.Inscription>(inscription);
                    context.Inscription.Add(inscriptionEntity);
                    context.SaveChanges();

                    return AutoMapperConfiguration.Mapper.Map<Domain.Inscription>(inscriptionEntity);
                }
            }
            catch (Exception e)
            {
                throw new DataException("Error in inscription to meetup");
            }
        }
    }
}
