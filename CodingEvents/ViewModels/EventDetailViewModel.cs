using CodingEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.ViewModels
{
    
    // View model that will be the @model PageModel for a Details view
    public class EventDetailViewModel
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactEmail { get; set; }
        public string CategoryName { get; set; }
        public string TagText { get; set; }
        

        public EventDetailViewModel(Event evt, List<EventTag> eventTags) 
        {
            this.EventId = evt.Id;
            this.Name = evt.Name;
            this.Description = evt.Description;
            this.ContactEmail = evt.ContactEmail;
            this.CategoryName = evt.Category.Name;

            TagText = "";

            for (var i =0; i< eventTags.Count; i++)
            {
                TagText += "#" + eventTags[i].Tag.Name;

                if (i < eventTags.Count - 1)
                {
                    TagText += ", ";
                }

            }
        }


    }
}
