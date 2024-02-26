using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Event_Managemenent.Data.Models;
using Event.Management.Data.Models;
using System.Text.Json; // Make sure to adjust the namespace as per your application's structure

namespace Event_Management_Appilcation.Controllers
{

    [ApiController]
    [Route("api/eventRegistration")]
    //[Authorize(Roles = "Super Admin, Group Leader, Team Leader, User")]
    public class EventController : ControllerBase
    {
        private readonly ApplicationUser _context;

        public EventController(ApplicationUser context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("viewEvent")]
        public async Task<ActionResult<SDEvent>> GetEvent(int id)
        {

            var @event = await _context.SDEvents.FindAsync(id);

            if (@event == null)
            {
                return NotFound();
            }

            return @event;
        }

        [HttpGet]
        [Route("viewAllEvent")]
        public ActionResult<IEnumerable<SDEvent>> GetEvent()
        {

            var @event =  _context.SDEvents.ToList();

            if (@event == null)
            {
                return NotFound();
            }

            return @event;
        }

        private bool EventExists(int id)
        {
            return _context.SDEvents.Any(e => e.SDEventID == id);
        }

        [HttpPost]
        [Route("addEvent")]
        public async Task<ActionResult> CreateEvent([FromBody] SDEvent @event)
        {
            await _context.SDEvents.AddAsync(@event);
            await _context.SaveChangesAsync();
            return Ok(@event + "Registered for the event successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> UnregisterFromEvent(int id)
        {

            var Event_Management_Appilcation = await _context.SDEvents.FindAsync(id);
            if(Event_Management_Appilcation == null)
                {
                return NotFound(); 
                }

            _context.SDEvents.Remove(Event_Management_Appilcation);
            await _context.SaveChangesAsync();

            return Ok("Unregistered from the event successfully.");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEvent(int id, SDEvent @event)
        {
            if (id != @event.SDEventID)
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
