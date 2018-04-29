namespace MeetupClone.Migrations
{
    using MeetupClone.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MeetupClone.Contexts.MeetupContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MeetupClone.Contexts.MeetupContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // https://www.moving.com/tips/the-top-10-largest-us-cities-by-population/

            var cities = new[]
            {
                "New York",
                "Los Angeles",
                "Chicago",
                "Houston",
                "Philadelphia",
                "Phoenix",
                "San Antonio",
                "San Diego",
                "Dallas",
                "San Jose",
            }.Select(cityName => new City { Name = cityName });

            context.Cities
                .AddOrUpdate(cities.ToArray());

            var attendees = Enumerable
                .Range((Int32)'a', 26)
                .Select(c => (Char)c)
                .ToList()
                .Select(alpha => new Attendee { Email = $"{alpha}@f.c" });
            context.Attendees
                .AddOrUpdate(attendees.ToArray());

            var events = new[]
            {
                new Event
                {
                    City = cities.First(city => city.Name == "San Diego"),

                    Title = "Comic Con",
                    Tagline = "Comics and stuff my dude bro",
                    LongDescription = "A lot of comics and stuff my dude bro",

                    Address = "San Diego Convention Center",
                    State = "CA",
                    ZipCode = "92101",

                    MinimumAge = 0,
                    Price = 200,
                    Date = null,
                }
            }.ToList();
            context.Events
                .AddOrUpdate(events.ToArray());

            var attendance = new[]
            {
                new Attendance
                {
                    Attendee = attendees.First(attendee => attendee.Email == "a@f.c"),
                    Event = events.First(event_ => event_.Title == "Comic Con")
                }
            }.ToList();
            context.Attendance
                .AddOrUpdate(attendance.ToArray());

            // Note: Is this needed here? 
            //       I feel like EntityFramework would handle this since it created this context.
            context.SaveChanges();
        }
    }
}
