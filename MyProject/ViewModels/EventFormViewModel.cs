using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyProject.Models;
using System.ComponentModel.DataAnnotations;

namespace MyProject.ViewModels
{
    public class EventFormViewModel
    {
        public IEnumerable<EventType> EventTypes { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime? StartTime { get; set; }

        [Required]
        public DateTime? EndTime { get; set; }

        [Required]
        [Display(Name = "Event Type")]
        public byte? EventTypeId { get; set; }


        public EventFormViewModel()
        {
            Id = 0;
        }

        public EventFormViewModel(Event @event)
        {
            Id = @event.Id;
            Name = @event.Name;
            Description = @event.Description;
            StartTime = @event.StartTime;
            EndTime = @event.EndTime;
            EventTypeId = @event.EventTypeId;
        }
    }
}