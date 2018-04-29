using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetupClone.Models
{
    public class Event
    {
        public int ID { get; set; }

        public int? CityID { get; set; }
        public City City { get; set; }

        public string Title { get; set; }
        public string Tagline { get; set; }
        public string LongDescription { get; set; }

        public string Address { get; set; }
        public string State { get; set; } // TODO: Elevate to table
        public string ZipCode { get; set; }

        public int? MinimumAge { get; set; }

        public decimal? Price { get; set; }

        public DateTime? Date { get; set; }
    }
}