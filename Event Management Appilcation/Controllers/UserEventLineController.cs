using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Event.Management.Data;
using Event.Management.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event_Managemenent.Data.Models;

namespace Event_Management_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserEventLineController : ControllerBase
    {
        private readonly ApplicationUser _context;

        public UserEventLineController(ApplicationUser context)
        {
            _context = context;
        }

        // eendpoint to retrieve all user events that is registered
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserEvent>>> GetUserEvents()
        {
            return await _context.UserEvents.ToListAsync();
        }

        
        // Endpoint to retrieve a specific user event by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<UserEvent>> GetUserEvent(int id)
        {
            var userEvent = await _context.UserEvents.FindAsync(id);

            if (userEvent == null)
            {
                return NotFound();
            }

            return userEvent;
        }

        // POST: api/UserEventLine
        //  pour endpoint to create a new user event
        [HttpPost]
        public async Task<ActionResult<UserEvent>> PostUserEvent(UserEvent userEvent)
        {
            _context.UserEvents.Add(userEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserEvent), new { id = userEvent.UserEventID }, userEvent);
        }

        // PUT: api/UserEventLine/5
        // Endpoint to update an existing user event
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserEvent(int id, UserEvent userEvent)
        {
            if (id != userEvent.UserEventID)
            {
                return BadRequest();
            }

            _context.Entry(userEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserEventExists(id))
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

        
        // Endpoint to delete a user event by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserEvent(int id)
        {
            var userEvent = await _context.UserEvents.FindAsync(id);
            if (userEvent == null)
            {
                return NotFound();
            }

            _context.UserEvents.Remove(userEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Helper method to check if a user event exists
        private bool UserEventExists(int id)
        {
            return _context.UserEvents.Any(e => e.UserEventID == id);
        }
    }
}
