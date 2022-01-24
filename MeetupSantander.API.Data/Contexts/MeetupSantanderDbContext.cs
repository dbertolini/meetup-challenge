using MeetupSantander.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MeetupSantander.API.Data.Contexts
{
    public class MeetupSantanderDbContext : DbContext
    {
        public string _connectionString = string.Empty;

        public MeetupSantanderDbContext()
        {
            // Gets the connection string from the appsettings.json from the root API project
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            _connectionString = root.GetSection("ConnectionStrings").GetSection("ConnectionString").Value;
        }

        public string ConnectionString
        {
            get => _connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Sets the constraints of the database

            base.OnModelCreating(modelBuilder);

            //// User
            //modelBuilder.Entity<UserEntity>(entity =>
            //{
            //    entity.HasKey(u => u.Id);
            //    entity.Property(u => u.Username).IsRequired();
            //    entity.Property(u => u.Password).IsRequired();
            //    entity.Property(u => u.Role).IsRequired();
            //    entity.HasMany(i => i.Inscriptions);
            //});

            //// Meetup
            //modelBuilder.Entity<MeetupEntity>(entity =>
            //{
            //    entity.HasKey(m => m.Id);
            //    entity.Property(m => m.Name).IsRequired();
            //    entity.Property(m => m.Location).IsRequired();
            //    entity.Property(m => m.Due).IsRequired();
            //    entity.HasMany(m => m.Inscriptions)
            //        .WithOne(i=>i.Meetup)
            //        .HasForeignKey(i=>i.MeetupId);
            //});

            //// Inscription
            //modelBuilder.Entity<InscriptionEntity>(entity =>
            //{
            //    entity.HasKey(i => new { i.UserId, i.MeetupId });
            //    entity.Property(i => i.Due).IsRequired();
            //    entity.Property(i => i.Checkin).IsRequired();
            //    entity.HasOne(m => m.Meetup)
            //      .WithMany(mi => mi.Inscriptions)
            //      .HasForeignKey(mi => mi.MeetupId);
            //    entity.HasOne(u => u.User)
            //      .WithMany(ui => ui.Inscriptions)
            //      .HasForeignKey(ui => ui.UserId); ;
            //});

            //// BeerTemperature
            //modelBuilder.Entity<BeerTemperatureEntity>(entity =>
            //{
            //    entity.HasKey(bt => bt.Id);
            //    entity.Property(bt => bt.TemperatureMin).IsRequired();
            //    entity.Property(bt => bt.TemperatureMax).IsRequired();
            //    entity.Property(bt => bt.BeersPerPerson).IsRequired();
            //    entity.Property(bt => bt.BeersPerBox).IsRequired();
            //});

            modelBuilder.Entity<BeerTemperature>(entity =>
            {
                entity.Property(e => e.BeersPerPerson).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TemperatureMax).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TemperatureMin).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Inscription>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.MeetupId });

                entity.Property(e => e.Due).HasColumnType("datetime");

                entity.HasOne(d => d.Meetup)
                    .WithMany(p => p.Inscription)
                    .HasForeignKey(d => d.MeetupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inscription_Meetup");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Inscription)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inscription_User");
            });

            modelBuilder.Entity<Meetup>(entity =>
            {
                entity.Property(e => e.Due).HasColumnType("datetime");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });
        }

        public DbSet<User> User { get; set; }
        public DbSet<Meetup> Meetup { get; set; }
        public DbSet<Inscription> Inscription { get; set; }
        public DbSet<BeerTemperature> BeerTemperature { get; set; }
    }
}
