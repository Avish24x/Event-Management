using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Event_Management_Appilcation.Models; // Make sure to adjust the namespace as per your application's structure

namespace Event_Management_Appilcation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Super Admin, Group Leader, Team Leader, User")]
    public class EventRegistrationController : ControllerBase
    {
        private readonly ApplicationUser _context;

        public EventRegistrationController(ApplicationUser context)
        {
            _context = context;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Event_Management_Appilcation.Models.Event>>> GetEvents()
        //{
        //    return await _context.Events.ToListAsync();
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<Event_Management_Appilcation.Models.Event>> GetEvent(int id)
        {
            var @event = await _context.Events.FindAsync(id);

            if (@event == null)
            {
                return NotFound();
            }

            return @event;
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.EventID == id);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEvent([FromBody] Event_Management_Appilcation.Models.Event @event)
        {
            await _context.Events.AddAsync(@event);
            await _context.SaveChangesAsync();
            return Ok(@event + " fRegistered for the event successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> UnregisterFromEvent(int id)
        {

            var Event_Management_Appilcation = await _context.Events.FindAsync(id);
            if(Event_Management_Appilcation == null)
                {
                return NotFound(); 
                }

            _context.Events.Remove(Event_Management_Appilcation);
            await _context.SaveChangesAsync();

            return Ok("Unregistered from the event successfully.");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEvent(int id, Event_Management_Appilcation.Models.Event @event)
        {
            if (id != @event.EventID)
            {
                return BadRequest();
            }

            _context.Entry(@event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
    }
}
