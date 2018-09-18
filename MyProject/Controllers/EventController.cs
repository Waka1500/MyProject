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
            var events = _context.Events.Include(e => e.EventType).ToList();

            return View(events);
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
        public ActionResult Create(Event @event)
        {
            _context.Events.Add(@event);
            _context.SaveChanges();

            return RedirectToAction("Index", "Event");
        }
    }
}