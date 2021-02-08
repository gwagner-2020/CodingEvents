using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Models
{
    public class Event
    {
        public string Name { get; set; }
        
        [FromForm(Name="desc")]
        public string Description { get; set; }
        public string ContactEmail { get; set; }
        //public EventType Type { get; set; }

        //CategoryId is a foreign id and following line provides reference to EventCategory object
        public int CategoryId { get; set; }
        public EventCategory Category { get; set; }


        public int Id { get; set; }
        private static int nextId = 1;

        // code removed to prepare for migration
        public Event()
        {
            //this.Id = nextId;
            //nextId++;
        }
        
        public Event(string name, string description, string contactEmail)//: this()
        {
            this.Name = name;
            this.Description = description;
            this.ContactEmail = contactEmail;
            //this.Id = nextId;
            //nextId++;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Event @event && 
                Id == @event.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
