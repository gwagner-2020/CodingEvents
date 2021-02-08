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
    public class EventCategoryController : Controller
    {
        private EventDbContext context;
        public EventCategoryController(EventDbContext context)
        {
            this.context = context;
        }
        
        // GET: /EventCategory
        [HttpGet]
        public IActionResult Index()
        {
            List<EventCategory> eventCategories = context.Categories.ToList();

            return View(eventCategories);
        }

       [HttpGet]
       //[Route("/EventCategory/Create")]
        public IActionResult Create()
        {
            AddEventCategoryViewModel addEventCategoryViewModel = new AddEventCategoryViewModel();
            return View(addEventCategoryViewModel);
        }

        [HttpPost]
        [Route("/EventCategory/Create")]
        public IActionResult ProcessCreateEventCategoryForm(AddEventCategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                EventCategory newEventCategory = new EventCategory
                {
                    Name = viewModel.Name
                };
                context.Categories.Add(newEventCategory);
                context.SaveChanges();

                return Redirect("/EventCategory");
            }

            return View(viewModel);
        }


    }
}
