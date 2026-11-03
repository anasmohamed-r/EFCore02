using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFCore02.Context
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\SQL2025;database=EventHup;trusted_connection=true;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Models.Event>(e => {

                e.HasKey(x => x.Id);
                e.Property(x => x.Title).IsRequired().HasMaxLength(200);
                e.Property(x => x.Description).IsRequired().HasMaxLength(2000);
                e.Property(x => x.StartDate).IsRequired();
                e.Property(x => x.EndDate);
                e.Property(x => x.MaxAttendees).IsRequired();

                e.HasOne(ev => ev.Organizer)
                 .WithMany(o => o.Events)
                 .HasForeignKey(ev => ev.OrganizerId)
                 .OnDelete(DeleteBehavior.NoAction);
            });
        }
        public DbSet<Models.Organizer> Organizers { get; set; }
        public DbSet<Models.Event> Events { get; set; }

        public DbSet<Models.Attendee> Attendees { get; set; }

        public DbSet<Models.OrganizerProfile> OrganizerProfiles { get; set; }
    }
}
