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
    [Authorize(Roles = "Super Admin, Group Leader, Team Leader, User")]
    public class EventRegistrationController : ControllerBase
    {
        private readonly ApplicationUser _context;

        public EventRegistrationController(ApplicationUser context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Event_Management_Appilcation.Models.Event>>> GetEvents()
        {
            return await _context.Events.ToListAsync();

        }

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

        [HttpPost]
        public async Task<ActionResult<Event_Management_Appilcation.Models.Event>> RegisterForEvent(int eventId)
        {
            // Logic to register the user for the event
            // For example, create a UserEvent entry in the database
            // This action will depend on your specific application logic
            // You can modify it based on your requirements

            // For now, let's assume we just return a success message
            return Ok("Registered for the event successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> UnregisterFromEvent(int id)
        {
            // Logic to unregister the user from the event
            // For example, delete the UserEvent entry from the database
            // This action will depend on your specific application logic

            // For now, let's assume we just return a success message
            return Ok("Unregistered from the event successfully.");
        }
    }
}
