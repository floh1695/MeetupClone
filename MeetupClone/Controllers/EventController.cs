using MeetupClone.Contexts;
using MeetupClone.Models;
using MeetupClone.Models.Out;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MeetupClone.Controllers
{
    public class EventController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetFullEventByID(int ID)
        {
            Attendance result;
            using (var db = new MeetupContext())
            {
                //result = db.Events.FirstOrDefault(event_ => event_.ID == ID);
                result = db.Attendance
                    .Include(a => a.Attendee)
                    .Include(a => a.Event)
                    .Include(a => a.Event.City)
                    .FirstOrDefault(a => a.Event.ID == ID);
            }
            return Ok(new EventSearchResult(result));
        }
    }
}
