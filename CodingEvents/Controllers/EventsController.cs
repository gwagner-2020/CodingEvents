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
    }
}
