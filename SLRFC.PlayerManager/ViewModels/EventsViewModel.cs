namespace SLRFC.PlayerManager.ViewModels
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using SLRFC.Model;

    public class EventsViewModel
    {
        public Event Event { get; set; }
        
        public List<Event> Events { get; set; }

        public List<EventType> EventTypes { get; set; }
    }
}