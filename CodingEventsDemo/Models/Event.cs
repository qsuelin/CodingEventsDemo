using System;
using Microsoft.AspNetCore.Mvc;

namespace CodingEventsDemo.Models
{
    public class Event
    {
        public string Name { get; set; }
        [FromForm(Name = "desc")]
        public string Description { get; set; }

        public int Id { get; }
        private static int nextId = 1;

        public Event()
        {
            Id = nextId;
            nextId++;
        }

        public Event(string name, string description): this()
        {
            Name = name;
            Description = description;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
