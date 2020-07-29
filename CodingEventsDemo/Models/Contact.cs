﻿using System;
namespace CodingEventsDemo.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }

        public Contact(string name, string email, string phoneNumber, string city)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            City = city;
        }
        public Contact()
        {
        }
    }
}
