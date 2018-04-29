using MeetupClone.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MeetupClone.Contexts
{
    public class MeetupContext
        : DbContext
    {
        public MeetupContext()
            : base("name=Meetup")
        { }

        public DbSet<City> Cities { get; set; }
        public DbSet<Attendee> Attendees { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Attendance> Attendance { get; set; }
    }
}