using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Models;
using CodingEvents.Data;
using CodingEvents.ViewModels;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        //private static List<Event> events = new List<Event>();
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            List<Event> events = new List<Event>(EventData.GetAll());

            return View(events);
        }

        [HttpGet]
        public IActionResult Add()
        {
            // Create a blank AddEventViewModel to associate with the form in Add.cshtml
            AddEventViewModel addEventViewModel = new AddEventViewModel();
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
                Event newEvent = new Event
                {
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                    ContactEmail = viewModel.ContactEmail,
                    Type = viewModel.Type
                };

                //EventData.Add(new Event(name, description));
                EventData.Add(newEvent);

                return Redirect("/Events");
            }

            // viewModel is NOT valid!
            return View(viewModel);
            
        }

        // Eg. GET /Events/Edit/2
        // GET: /Events/Edit/{eventId}
        [HttpGet]
        [Route("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            //Create an editEventViewModel with properties assigned from Event associated with eventId
            Event eventToEdit = EventData.GetById(eventId);

            //Use eventToEdit to populate values of editEventViewModel
            EditEventViewModel editEventViewModel = new EditEventViewModel(eventToEdit);
            return View(editEventViewModel);
        }

        //POST: /Events/Edit
        [HttpPost]
        public IActionResult Edit(EditEventViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //Get the Event object from the Event Data
                //Where does the eventId come from?

                Event eventToEdit = EventData.GetById(viewModel.Id);

                // Modify properties in eventToEdit, using new values in viewModel

                eventToEdit.Name = viewModel.Name;
                eventToEdit.Description = viewModel.Description;
                eventToEdit.ContactEmail = viewModel.ContactEmail;

                return Redirect("/Events");
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach(int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }

            return Redirect("/Events");
        }
    }
}
