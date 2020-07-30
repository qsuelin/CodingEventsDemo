using System;
using CodingEventsDemo.Models;

namespace CodingEventsDemo.ViewModels
{
    public class ContactDetailViewModel
    {
        public string Name { get; set; }
        public ContactDetailViewModel(Contact contact)
        {
            Name = contact.Name;

        }
    }
}
