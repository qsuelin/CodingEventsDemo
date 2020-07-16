using System;
using System.Collections.Generic;
using CodingEventsDemo.Models;

namespace CodingEventsDemo.Data
{
    public class EventData
    {
        static Dictionary<int, Event> eventsDict = new Dictionary<int, Event>();

        public EventData()
        {
        }

        public static IEnumerable<Event> GetAll()
        {
            return eventsDict.Values;
        }

        public static void Add(Event newEvent)
        {
            eventsDict.Add(newEvent.Id, newEvent) ;
        }

        public static void Remove(int id)
        {
            eventsDict.Remove(id);

        }

        public static Event GetById(int id)
        {
            return eventsDict[id];
        }
    }
}
