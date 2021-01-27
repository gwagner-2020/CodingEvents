using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Models;

namespace CodingEvents.Data
{
    public class EventData
    {
        // store events
        private static Dictionary<int, Event> events = new Dictionary<int, Event>();

        // add events
        public static void Add(Event newEvent)
        {
            events.Add(newEvent.Id, newEvent);
        }

        // retreive the events
        public static IEnumerable<Event> GetAll()
        {
            return events.Values;
        }

        // retreive a single event
        public static Event GetById(int id)
        {
            return events[id];
        }

        // remove an event
        public static void Remove(int id)
        {
            events.Remove(id);
        }
    }
}
