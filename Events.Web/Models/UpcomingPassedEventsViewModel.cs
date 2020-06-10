using System.Collections.Generic;

namespace Events.Web.Models
{


    public class UpcomingPassedEventsViewModel
    {//lists of events
        public IEnumerable<EventViewModel> UpcomingEvents { get; set; }

        public IEnumerable<EventViewModel> PassedEvents { get; set; }
    }
}