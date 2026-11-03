using EFCore02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore02.Configiration
{
    internal class OrganizerProfileConfigration : IEntityTypeConfiguration<OrganizerProfile>
    {
        public void Configure(EntityTypeBuilder<OrganizerProfile> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Biography).HasMaxLength(100);

            builder.Property(p => p.WebsiteUrl).HasMaxLength(100);

            builder.Property(p => p.LogoUrl).HasMaxLength(100);

            builder.HasOne(p => p.Organizer)
                    .WithOne(o => o.Profile)
                .HasForeignKey<OrganizerProfile>(p => p.OrganizerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
