using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Models
{
    public enum EventType
    {
        Conference, // 0 -- backing value
        Meetup,     // 1 -- backing value
        Workshop,   // 2 -- backing value
        Social      // 3 -- backing value
    }

    /* EventType eType = EventType.Meetup;
     * Console.WriteLine((int)eType); --> prints "1"
     * Console.WriteLine(eType); --> prints "Meetup"
     * 
     * Console.WriteLine(eType == "Meetup") --> eType not string, so doesn't print
     * Console.WriteLine(eType == EventType.Meetup) --> prints "true"
     * 
     * int option = 3;
     * EventType optionType = (EventType)option;
     * Console.WriteLine(optionType); --> prints "Social"
     */

}
