﻿using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.ViewModels
{
    public class AddEventViewModel
    {
        [Required (ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Please enter a description of your event.")]
        [StringLength(500, ErrorMessage = "Description is too long.")]
        public string Description { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        //public EventType Type { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; }

        //<option value="0">Conference<option>
        //public List<SelectListItem> EventTypes { get; set; } = new List<SelectListItem>
        //{
        //    new SelectListItem(EventType.Conference.ToString(), ((int)EventType.Conference).ToString()),
        //    new SelectListItem(EventType.Meetup.ToString(), ((int)EventType.Meetup).ToString()),
        //    new SelectListItem(EventType.Workshop.ToString(), ((int)EventType.Workshop).ToString()),
        //    new SelectListItem(EventType.Social.ToString(), ((int)EventType.Social).ToString()),
        //};

        //This constructor is automatically part of this class
        public AddEventViewModel() { }

        public AddEventViewModel(List<EventCategory> categories)
        {
            this.Categories = new List<SelectListItem>();

            foreach (EventCategory category in categories)
            {
                this.Categories.Add(new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.Name
                });
            }
        }
    }
}
