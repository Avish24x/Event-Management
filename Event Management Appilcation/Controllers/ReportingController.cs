using Microsoft.AspNetCore.Mvc;
using Event_Management_Appilcation.Models;
using System.Collections.Generic;
using System.Linq;

namespace Event_Management_Appilcation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportingController : ControllerBase
    {
        private readonly ApplicationUser _context;

        public ReportingController(ApplicationUser context)
        {
            _context = context;
        }

        // GET: api/Reporting/Events
        [HttpGet("Events")]
        public ActionResult<IEnumerable<Event_Management_Appilcation.Models.Event>> GetEvents()
        {
            var events = _context.Events.ToList();
            return events;
        }

        // GET: api/Reporting/EventsByGroup/{groupId}
        [HttpGet("EventsByGroup/{groupId}")]
        public ActionResult<IEnumerable<Event_Management_Appilcation.Models.Event>> GetEventsByGroup(int groupId)
        {
            var events = _context.Events.Where(e => e.GroupID == groupId).ToList();
            return events;
        }

        // GET: api/Reporting/EventsByType/{type}
        [HttpGet("EventsByType/{type}")]
        public ActionResult<IEnumerable<Event_Management_Appilcation.Models.Event>> GetEventsByType(string type)
        {
            var events = _context.Events.Where(e => e.Type == type).ToList();
            return events;
        }

        // GET: api/Reporting/EventsByDateRange/{startDate}/{endDate}
        [HttpGet("EventsByDateRange/{startDate}/{endDate}")]
        public ActionResult<IEnumerable<Event_Management_Appilcation.Models.Event>> GetEventsByDateRange(string startDate, string endDate)
        {
            // Convert string dates to DateTime objects (you may need to adjust the date format)
            var startDateTime = System.DateTime.Parse(startDate);
            var endDateTime = System.DateTime.Parse(endDate);

            // Retrieve events within the specified date range
            var events = _context.Events.Where(e => e.Starting_Time >= startDateTime && e.Ending_Time <= endDateTime).ToList();
            return events;
        }

        // GET: api/Reporting/EventsByLocation/{location}
        [HttpGet("EventsByLocation/{location}")]
        public ActionResult<IEnumerable<Event_Management_Appilcation.Models.Event>> GetEventsByLocation(string location)
        {
            var events = _context.Events.Where(e => e.Location == location).ToList();
            return events;
        }

        // Add more methods as needed for other reporting criteria
    }
}
