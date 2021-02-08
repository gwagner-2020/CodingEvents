using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Models;
using CodingEvents.Data;
using CodingEvents.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        //private static List<Event> events = new List<Event>();
        private EventDbContext context;
        public EventsController(EventDbContext context)
        {
            this.context = context;
        }


        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            //List<Event> events = new List<Event>(EventData.GetAll());
            List<Event> events = context.Events
                .Include(e => e.Category)
                .ToList();

            return View(events);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<EventCategory> categories = context.Categories.ToList();
            // Create a blank AddEventViewModel to associate with the form in Add.cshtml
            AddEventViewModel addEventViewModel = new AddEventViewModel(categories);
            return View(addEventViewModel);
        }

        [HttpPost]
        //[Route("/Events/Add")]
        //public IActionResult NewEvent(string name, string desciption) 
        public IActionResult Add(AddEventViewModel viewModel)
        {
            //Imagine doing lots of data validation on the viewModel first
            if (ModelState.IsValid)
            {
                //Grab EventCategory object reference from DB associated with user's CategoryId choice
                EventCategory category = context.Categories.Find(viewModel.CategoryId);
                Event newEvent = new Event
                {
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                    ContactEmail = viewModel.ContactEmail,
                    //Type = viewModel.Type
                    //CategoryId = viewModel.CategoryId,
                    Category = category
                };

                //EventData.Add(new Event(name, description));
                //EventData.Add(newEvent);
                context.Events.Add(newEvent);
                context.SaveChanges();

                return Redirect("/Events");
            }

            // viewModel is NOT valid!
            return View(viewModel);
            
        }

        [HttpGet]
        public IActionResult Delete()
        {
            //ViewBag.events = EventData.GetAll();
            ViewBag.events = context.Events.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach(int eventId in eventIds)
            {
                //EventData.Remove(eventId);
                Event evt = context.Events.Find(eventId);
                context.Events.Remove(evt);
            }

            context.SaveChanges();
            return Redirect("/Events");
        }
    }
}
