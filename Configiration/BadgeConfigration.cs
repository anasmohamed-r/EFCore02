using EFCore02.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore02.Configiration
{
    internal class BadgeConfigration : IEntityTypeConfiguration<Badge>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Badge> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.BadgeNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(b => b.Attendee)
              .WithOne(a => a.Badge)
              .HasForeignKey<Badge>(b => b.AttendeeId)
              .IsRequired()
              .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
