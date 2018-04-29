using MeetupClone.Contexts;
using MeetupClone.Models;
using MeetupClone.Models.In;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MeetupClone.Controllers
{
    public class EventsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult SearchForCities([FromUri]CitySearch citySearch)
        {
            var results = new List<Event>();
            using (var db = new MeetupContext())
            {
                var query = db.Events
                    .Include(event_ => event_.City);
                if (!string.IsNullOrWhiteSpace(citySearch.City))
                {
                    query = query
                        .Where(event_ => event_.City.Name.Contains(citySearch.City));
                }
                if (!string.IsNullOrWhiteSpace(citySearch.Title))
                {
                    query = query
                        .Where(event_ => event_.Title.Contains(citySearch.Title));
                }

                results.AddRange(query);
            }
            return Ok(results);
        }
    }
}
