﻿using System;
using System.Collections.Generic;
using CodingEventsDemo.Models;

namespace CodingEventsDemo.ViewModels
{
    public class EventDetailViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactEmail { get; set;}
        public string CategoryName { get; set; }
        public int EventId { get; set; }

        public string TagText { get; set; }

        public EventDetailViewModel(Event theEvent, List<EventTag> eventTags)
        {
            Name = theEvent.Name;
            EventId = theEvent.Id;
            Description = theEvent.Description;
            ContactEmail = theEvent.ContactEmail;
            CategoryName = theEvent.Category.Name;

            TagText = "";
            for (int i = 0; i < eventTags.Count; i++)
            {
                TagText += ("#" + eventTags[i].Tag.Name);

                if (i < eventTags.Count - 1)
                {
                    TagText += ", ";
                }
            }

        }

        public EventDetailViewModel()
        {
        }
    }
}
