using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CodingEventsDemo.Controllers
{
    public class ContactController: Controller
    {
        private EventDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ContactController (EventDbContext dbContext, IWebHostEnvironment hostEnvironment)
        {
            context = dbContext;
            webHostEnvironment = hostEnvironment;
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
        [ValidateAntiForgeryToken]
        public IActionResult Add(AddContactViewModel addContactViewModel)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(addContactViewModel);

                Contact newContact = new Contact
                {
                    Name = addContactViewModel.FirstName + addContactViewModel.LastName,
                    Email = addContactViewModel.Email,
                    PhoneNumber = addContactViewModel.PhoneNumber,
                    City = addContactViewModel.City,
                    ProfilePicture = uniqueFileName
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

        private string UploadedFile(AddContactViewModel addContactViewModel)
        {
            string uniqueFileName = null;
            if (addContactViewModel.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + addContactViewModel.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    addContactViewModel.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
