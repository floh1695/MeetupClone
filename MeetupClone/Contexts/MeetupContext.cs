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
    }
}