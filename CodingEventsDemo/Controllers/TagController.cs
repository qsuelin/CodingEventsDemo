using System;
using System.Collections.Generic;
using System.Linq;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodingEventsDemo.Controllers
{
    public class TagController: Controller
    {
        private EventDbContext context;

        public TagController(EventDbContext dbContext)
        {
            context = dbContext;
        }
        //public TagController()
        //{
        //}


        [HttpGet]
        public IActionResult Index()
        {
            List<Tag> tags = context.Tags.ToList();
            return View(tags);
        }

        public IActionResult Add()
        {
            AddTagViewModel addTagViewModel = new AddTagViewModel();
            return View(addTagViewModel);
        }

        //public IActionResult Add()
        //{
        //    Tag tag = new Tag();
        //    return View(tag);
        //}

        [HttpPost]
        public IActionResult Add(AddTagViewModel addTagViewModel)
        {
            if (ModelState.IsValid)
            {
                Tag newTag = new Tag
                {
                    Name = addTagViewModel.Name
                };
                context.Tags.Add(newTag);
                context.SaveChanges();
                return Redirect("/Tag");

            }
            return View("Add", addTagViewModel);
        }


        public IActionResult AddEvent(int id)
        {
            Event theEvent = context.Events.Find(id);
            List<Tag> possibleTags = context.Tags.ToList();

            AddEventTagViewModel viewModel = new AddEventTagViewModel(theEvent, possibleTags);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddEvent(AddEventTagViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                int eventId = viewModel.EventId;
                int tagId = viewModel.TagId;

                EventTag eventTag = new EventTag
                {
                    EventId = eventId,
                    TagId = tagId
                };
                context.EventTags.Add(eventTag);
                context.SaveChanges();

                return Redirect("/Events/Detail/" + eventId);

            }
            return View(viewModel);
        }
    }
}
