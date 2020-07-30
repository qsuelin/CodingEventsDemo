using System;
using System.Collections.Generic;
using System.Linq;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodingEventsDemo.Controllers
{
    public class ContactController: Controller
    {
        private EventDbContext context;

        public ContactController (EventDbContext dbContext)
        {
            context = dbContext;
        }

        //public ContactController()
        //{
        //}

        public IActionResult Index()
        {
            List<Contact> contacts = context.Contacts.ToList();

            return View(contacts);
        }


        [HttpGet]
        public IActionResult Add()
        {
            AddContactViewModel addContactViewModel = new AddContactViewModel();
            return View(addContactViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddContactViewModel addContactViewModel)
        {
            if (ModelState.IsValid)
            {
                Contact newContact = new Contact
                {
                    Name = addContactViewModel.FirstName + addContactViewModel.LastName,
                    Email = addContactViewModel.Email,
                    PhoneNumber = addContactViewModel.PhoneNumber,
                    City = addContactViewModel.City
                };
                context.Contacts.Add(newContact);
                context.SaveChanges();
                return Redirect("/Contact");
            }
            return View(addContactViewModel);
        }

        [HttpGet]
        public IActionResult View(int id)
        {
            Contact theContact = context.Contacts.Find(id);
            ContactDetailViewModel contactDetailView = new ContactDetailViewModel(theContact);
            return View(contactDetailView);
        }
    }
}
