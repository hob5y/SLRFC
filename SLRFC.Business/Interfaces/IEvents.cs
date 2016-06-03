namespace SLRFC.Business
{
    using System.Collections.Generic;

    using SLRFC.Model;

    public interface IEvents
    {
        void AddSingleEvent(Event theEvent);

        void AddMultipleEvents(IEnumerable<Event> theEvents);
    }
}