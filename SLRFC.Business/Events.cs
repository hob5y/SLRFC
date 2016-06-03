using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLRFC.Business
{
    using AutoMapper;

    using SLRFC.Model;

    public class Events : IEvents
    {
        private readonly MyDbContext dbContext;

        public Events(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddSingleEvent(Event theEvent)
        {
            var ev = new Event
                         {
                             EventName = theEvent.EventName,
                             StartDateTime = theEvent.StartDateTime,
                             EndDateTime = theEvent.EndDateTime,
                             Notes = theEvent.Notes,
                             TypeOfEvent = theEvent.TypeOfEvent
                         };

            this.dbContext.Events.Add(ev);

            this.dbContext.SaveChanges();
        }

        public void AddMultipleEvents(IEnumerable<Event> theEvents)
        {
            var listOfEvents = theEvents.Select(theEvent => 
                new Event
                    {
                        EventName = theEvent.EventName, 
                        StartDateTime = theEvent.StartDateTime, 
                        EndDateTime = theEvent.EndDateTime, 
                        Notes = theEvent.Notes, 
                        TypeOfEvent = theEvent.TypeOfEvent
                    }).ToList();

            this.dbContext.Events.AddRange(listOfEvents);

            this.dbContext.SaveChanges();
        }
    }
}
