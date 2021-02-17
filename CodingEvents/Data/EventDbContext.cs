using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CodingEvents.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CodingEvents.Data
{
    public class EventDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Event> Events { get; set; }

        public DbSet<EventCategory> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<EventTag> EventTags { get; set; }

        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventTag>()
                .HasKey(et => new { et.EventId, et.TagId });

            //next line added for authentication
            base.OnModelCreating(modelBuilder);
        }
       
    }
}
