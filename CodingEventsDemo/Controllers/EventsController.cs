using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodingEventsDemo.Models;
using CodingEventsDemo.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {

        //static private Dictionary<string, string> Events = new Dictionary<string, string>();
        //static private List<Event> Events = new List<Event>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }

        [HttpGet]
        [Route("/events/add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Events/Add")]
        public IActionResult NewEvent(Event newEvent)
        {
            //Event newEvent = new Event(name, desc);
            EventData.Add(newEvent);

            Console.WriteLine(newEvent.Name);
            Console.WriteLine(newEvent.Description);


            return Redirect("/Events");
        }

        [HttpGet]
        [Route("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            ViewBag.title = $"Edit Event {EventData.GetById(eventId).Name} (id={eventId})";
            ViewBag.eventToEdit = EventData.GetById(eventId);
            return View();
        }

        /* not updating */
        [HttpPost]
        [Route("/Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string desc)
        {
            Event updatedEvent = EventData.GetById(eventId);
            updatedEvent.Name = name;
            updatedEvent.Description = desc;
            // GetAll() is expensive!!
            Console.WriteLine(updatedEvent.Description);
            Console.WriteLine("updated: ", updatedEvent);
            //ViewBag.events = EventData.GetAll();
            
            return Redirect("/Events");
        }

        //[HttpPost]
        //[Route("/Events/Edit/{eventId}")]
        //public IActionResult SubmitEditEventForm(Event updatedEvent)
        //{
        //    Event updatedEvent = EventData.GetById(eventId);
        //    updatedEvent.Name = name;
        //    updatedEvent.Description = description;
        //    return Redirect("/Events");
        //}

        [HttpGet]
        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int id in eventIds)
            {
                EventData.Remove(id);
            }
            return Redirect("/Events");
        }
    }
}
