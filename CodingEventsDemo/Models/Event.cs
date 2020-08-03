using System;
using Microsoft.AspNetCore.Mvc;

namespace CodingEventsDemo.Models
{
    public class Event
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Event(string name, int id)
        {
            Name = name;
            Id = id;
        }

        //public string ContactEmail { get; set; }
        public Contact Contact { get; set; }
        public int ContactId { get; set; }

        //public EventType Type { get; set; }
        public EventCategory Category { get; set; }
        public int CategoryId { get; set; }

        public string UserId { get; set; }

        public int Id { get; set; }

        //public Event(string name, string description, string contactEmail)
        public Event(string name, string description)

        {
            Name = name;
            Description = description;
            //ContactEmail = contactEmail;

        }

        public Event()
        {
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Event @event &&
                   Id == @event.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
