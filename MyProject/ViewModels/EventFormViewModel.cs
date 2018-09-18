using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyProject.Models;

namespace MyProject.ViewModels
{
    public class EventFormViewModel
    {
        public IEnumerable<EventType> EventTypes { get; set; }
        public Event Event { get; set; }
    }
}