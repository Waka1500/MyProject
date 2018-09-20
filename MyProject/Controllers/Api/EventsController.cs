using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyProject.Models;
using MyProject.Dtos;
using AutoMapper;
using System.Data.Entity;

namespace MyProject.Controllers.Api
{
    public class EventsController : ApiController
    {
        private ApplicationDbContext _context;

        public EventsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/events/
        public IHttpActionResult GetEvents()
        {
            var eventDtos = _context.Events
                .Include(e => e.EventType)
                .ToList()
                .Select(Mapper.Map<Event, EventDto>);
            return Ok(eventDtos);
        }

        // GET /api/events/1
        public IHttpActionResult GetEvent(int id)
        {
            var @event = _context.Events.SingleOrDefault(e => e.Id == id);

            if (@event == null)
                return NotFound();

            return Ok(Mapper.Map<Event, EventDto>(@event));
        }

        // POST /api/events
        [HttpPost]
        public IHttpActionResult CreateEvent(EventDto eventDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var @event = Mapper.Map<EventDto, Event>(eventDto);
            _context.Events.Add(@event);
            _context.SaveChanges();

            eventDto.Id = @event.Id;

            return Created(new Uri(Request.RequestUri + "/" + @event.Id), eventDto);
        }

        // PUT /api/events/1
        [HttpPut]
        public IHttpActionResult UpdateEvent(int id, EventDto eventDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var eventInDb = _context.Events.SingleOrDefault(e => e.Id == id);

            if (eventInDb == null)
                return NotFound();

            Mapper.Map(eventDto, eventInDb);
            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/events/1
        [HttpDelete]
        public IHttpActionResult DeleteEvent(int id)
        {
            var eventInDb = _context.Events.SingleOrDefault(e => e.Id == id);

            if (eventInDb == null)
                return NotFound();

            _context.Events.Remove(eventInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
