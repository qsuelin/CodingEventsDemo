﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CodingEventsDemo.ViewModels
{
    public class AddContactViewModel
    {
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }

        public string City { get; set; }

        [Display(Name ="Profile Picture")]
        public IFormFile ProfileImage { get; set; }

        public AddContactViewModel()
        {
        }
    }
}
