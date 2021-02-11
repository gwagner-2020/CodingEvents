﻿using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.ViewModels
{
    public class AddEventTagViewModel
    {
        public int EventId { get; set; }
        public Event Event { get; set; }

        public List<SelectListItem> Tags { get; set; }

        public int TagId { get; set; }

        public AddEventTagViewModel(Event evt, List<Tag> possibleTags) 
        {
            Tags = new List<SelectListItem>();

            foreach (var tag in possibleTags)
            {
                Tags.Add(new SelectListItem
                {
                    Value = tag.Id.ToString(),
                    Text = tag.Name

                });
            }

            Event = evt;
        }

        public AddEventTagViewModel() { }
    }
}
