using Microsoft.AspNetCore.Mvc;
using Event_Management_Appilcation.Models;
using System.Collections.Generic;
using System.Linq;
using Event_Managemenent.Data.Models;
using Event.Management.Data.Models;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

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
        public ActionResult<IEnumerable<SDEvent>> GetEvents()
        {
            var events = _context.SDEvents.ToList();
            return events;
        }

        // GET: api/Reporting/EventsByGroup/{groupId}
        [HttpGet("EventsByGroup/{groupId}")]
        public ActionResult<IEnumerable<SDEvent>> GetEventsByGroup(int groupId)
        {
            var events = _context.SDEvents.Where(e => e.GroupID == groupId).ToList();
            return events;
        }

        // GET: api/Reporting/EventsByType/{type}
        [HttpGet("EventsByType/{type}")]
        public ActionResult<IEnumerable<SDEvent>> GetEventsByType(string type)
        {
            var events = _context.SDEvents.Where(e => e.Type == type).ToList();
            return events;
        }

        // GET: api/Reporting/EventsByDateRange/{startDate}/{endDate}
        [HttpGet("EventsByDateRange/{startDate}/{endDate}")]
        public ActionResult<IEnumerable<SDEvent>> GetEventsByDateRange(string startDate, string endDate)
        {
            var startDateTime = System.DateTime.Parse(startDate);
            var endDateTime = System.DateTime.Parse(endDate);
            var events = _context.SDEvents.Where(e => e.Starting_Time >= startDateTime && e.Ending_Time <= endDateTime).ToList();
            return events;
        }

        // GET: api/Reporting/EventsByLocation/{location}
        [HttpGet("EventsByLocation/{location}")]
        public ActionResult<IEnumerable<SDEvent>> GetEventsByLocation(string location)
        {
            var events = _context.SDEvents.Where(e => e.Location == location).ToList();
            return events;
        }

        // Generate and export report
        [HttpGet("ExportReport")]
        public IActionResult ExportReport(int year, int month)
        {
            // Calculate start and end dates for the specified month
            var startDate = new DateTime(year, month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1); // Get the last day of the month

            // Retrieve events data for the specified month
            var events = _context.SDEvents
                .Where(ev => ev.Starting_Time >= startDate && ev.Ending_Time <= endDate)
                .ToList();

            // Generate CSV content
            var csvContent = new StringBuilder();
            csvContent.AppendLine("EventID,Description,Starting_Time,Ending_Time,Location,Type,GroupID"); // Add headers

            foreach (var ev in events)
            {
                csvContent.AppendLine($"{ev.SDEventID},{ev.Description},{ev.Starting_Time},{ev.Ending_Time},{ev.Location},{ev.Type},{ev.GroupID}");
            }

            // Prepare response
            var bytes = Encoding.UTF8.GetBytes(csvContent.ToString());
            var result = new FileContentResult(bytes, "text/csv")
            {
                FileDownloadName = $"report_{year}_{month}.csv"
            };

            return result;
        }
    }   
}
