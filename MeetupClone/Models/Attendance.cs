using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeetupClone.Models
{
    public class Attendance
    {
        [Key, Column(Order = 0)]
        public int AttendeeID { get; set; }
        public Attendee Attendee { get; set; }

        [Key, Column(Order = 1)]
        public int EventID { get; set; }
        public Event Event { get; set; }
    }
}