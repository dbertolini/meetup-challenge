using MeetupSantander.API.Data.Contexts;
using MeetupSantander.API.Data.Entities;
using MeetupSantander.API.Data.Exceptions;
using MeetupSantander.API.Data.Mappers;
using MeetupSantander.API.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeetupSantander.API.Data.Repository.Impl
{
    public class MeetupEntityRepositoryImpl : IMeetupRepository
    {
        public Domain.Meetup createMeetup(Domain.Meetup meetup)
        {
            // Inserts a Meetup into the database

            try
            {
                using (MeetupSantanderDbContext context = new MeetupSantanderDbContext())
                {
                    Entities.Meetup meetupEntity = AutoMapperConfiguration.Mapper.Map<Entities.Meetup>(meetup);
                    context.Meetup.Add(meetupEntity);
                    context.SaveChanges();

                    return AutoMapperConfiguration.Mapper.Map<Domain.Meetup>(meetupEntity);
                }
            }
            catch (Exception e)
            {
                throw new DataException("Error creating meetup");
            }
        }

        public Domain.Meetup getMeetupById(int id)
        {
            // Gets the meetup from database especified by the Id as parameter

            try
            {
                using (MeetupSantanderDbContext context = new MeetupSantanderDbContext())
                {
                    Meetup meetupEntity = context.Meetup.Where(m => m.Id == id).Include(m => m.Inscription).FirstOrDefault();

                    return AutoMapperConfiguration.Mapper.Map<Domain.Meetup>(meetupEntity);
                }
            }
            catch (Exception e)
            {
                throw new DataException("Error getting meetup");
            }
        }

        public IList<Domain.Meetup> getMeetupList()
        {
            // Gets all the meetups from database

            try
            {
                using (MeetupSantanderDbContext context = new MeetupSantanderDbContext())
                {
                    List<Entities.Meetup> meetupEntity = context.Meetup.Include(m => m.Inscription).ToList();

                    return AutoMapperConfiguration.Mapper.Map<List<Domain.Meetup>>(meetupEntity);
                }
            }
            catch (Exception e)
            {
                throw new DataException("Error getting meetups");
            }
        }
    }
}
