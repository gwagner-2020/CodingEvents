using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Models;
using CodingEvents.Data;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        //private static List<Event> events = new List<Event>();
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            //Events.Add("Strange Loop");
            //Events.Add("Grace Hopper");
            //Events.Add("Code with Pride");
            ViewBag.events = EventData.GetAll();

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Events/Add")]
        //public IActionResult NewEvent(string name, string desciption) 
        public IActionResult NewEvent(Event newEvent)
        {
            //EventData.Add(new Event(name, description));
            EventData.Add(newEvent);

            return Redirect("/Events");
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
