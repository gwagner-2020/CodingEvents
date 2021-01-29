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
        public string Location { get; set; }
        public int NumAttendees { get; set; }
        public bool Registration { get; set; }

        public int Id { get; }
        private static int nextId = 1;

        public Event()
        {
            this.Id = nextId;
            nextId++;
        }
        
        public Event(string name, string description, string contactEmail, string location, int numAttendees, bool registration): this()
        {
            this.Name = name;
            this.Description = description;
            this.ContactEmail = contactEmail;
            this.Location = location;
            this.NumAttendees = numAttendees;
            this.Registration = registration;
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
