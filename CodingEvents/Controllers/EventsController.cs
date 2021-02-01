using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        private static Dictionary<string, string> events = new Dictionary<string, string>();
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            //Events.Add("Strange Loop");
            //Events.Add("Grace Hopper");
            //Events.Add("Code with Pride");
            ViewBag.events = events;

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Events/Add")]
        public IActionResult NewEvent(string name, string description)
        {
            events.Add(name, description);

            return Redirect("/Events");
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
    }
}
