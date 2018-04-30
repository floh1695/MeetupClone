using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetupClone.Models.Out
{
    public class EventSearchResult
    {
        public int ID { get; set; }

        public string Title { get; set; }
        public string Tagline { get; set; }
        public string LongDescription { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public int? MinimumAge { get; set; }
        public decimal? Price { get; set; }
        public DateTime? Date { get; set; }

        public List<Attendee> Attendees { get; set; }

        public EventSearchResult(Event event_) {
            ID = event_.ID;

            Title = event_.Title;
            Tagline = event_.Tagline;
            LongDescription = event_.LongDescription;

            Address = event_.Address;
            City = event_.City.Name;
            State = event_.State;
            ZipCode = event_.ZipCode;

            MinimumAge = event_.MinimumAge;
            Price = event_.Price;
            Date = event_.Date;
        }

    }
}