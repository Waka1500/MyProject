using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Models;
using System.Data.Entity;
using MyProject.ViewModels;

namespace MyProject.Controllers
{
    public class EventController : Controller
    {
        private ApplicationDbContext _context;

        public EventController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Event
        public ActionResult Index()
        {
            //var events = _context.Events.Include(e => e.EventType).ToList();

            //return View(events);
            return View();
        }

        public ActionResult New()
        {
            var eventTypes = _context.EventTypes.ToList();
            var viewModel = new EventFormViewModel
            {
                EventTypes = eventTypes
            };

            return View("EventForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Event @event)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new EventFormViewModel(@event)
                {
                    EventTypes = _context.EventTypes.ToList()
                };

                return View("EventForm", viewModel);
            }

            if (@event.Id == 0)
                _context.Events.Add(@event);
            else
            {
                var eventInDb = _context.Events.Single(e => e.Id == @event.Id);

                eventInDb.Name = @event.Name;
                eventInDb.Description = @event.Description;
                eventInDb.StartTime = @event.StartTime;
                eventInDb.EndTime = @event.EndTime;
                eventInDb.EventTypeId = @event.EventTypeId;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Event");
        }

        public ActionResult Details(int id)
        {
            var currentEvent = _context.Events.Include(e => e.EventType).SingleOrDefault(Event => Event.Id == id);

            if (currentEvent == null)
                return HttpNotFound();

            return View(currentEvent);
        }

        public ActionResult Edit(int id)
        {
            var currentEvent = _context.Events.SingleOrDefault(e => e.Id == id);

            if (currentEvent == null)
                return HttpNotFound();

            var viewModel = new EventFormViewModel(currentEvent)
            {
                EventTypes = _context.EventTypes.ToList()
            };

            return View("EventForm", viewModel);
        }
    }
}