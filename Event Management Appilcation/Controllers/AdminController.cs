//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//using Microsoft.AspNetCore.Authorization;
//using Event_Management_Appilcation.Models;

//[Authorize(Roles = "Super Admin")] // Authorize attribute for the entire controller
//[ApiController]
//[Route("api/[controller]")]
//public class AdminController : ControllerBase
//{
//    private readonly ApplicationDbContext _context;

//    public AdminController(ApplicationDbContext context)
//    {
//        _context = context;
//    }

//    // GET: api/Admin
//    [HttpGet]
//    public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
//    {
//        return await _context.Admins.ToListAsync();
//    }

//    private bool AdminExists(string id)
//    {
//        return _context.Admins.Any(e => e.AdminID == id);
//    }
//    [HttpGet("ViewEvents")]
//    // "ViewEventsAndGenerateReports"
//    public async Task<ActionResult<IEnumerable<Event_Management_Appilcation.Models.Event>>> ViewEventsAndGenerateReports()
//    {
//        // Perform logic to retrieve and combine events from multiple teams
//        // ...

//        var combinedEvents = await _context.Events.ToListAsync();

//        // Generate combined reports logic
//        // ...

//        return Ok(combinedEvents);
//    }

//    // GET: api/Admin/{id}
//    [HttpGet("{id}")]
//    public async Task<ActionResult<Admin>> GetAdmin(int id)
//    {
//        var admin = await _context.Admins.FindAsync(id);

//        if (admin == null)
//        {
//            return NotFound();
//        }

//        return admin;
//    }

//    // POST: api/Admin
//    [HttpPost]
//    public async Task<ActionResult<Admin>> CreateAdmin(Admin admin)
//    {
//        _context.Admins.Add(admin);
//        await _context.SaveChangesAsync();

//        return CreatedAtAction(nameof(GetAdmin), new { id = admin.AdminID }, admin);
//    }

//    // PUT: api/Admin/{id}
//    [HttpPut("{id}")]
//    public async Task<IActionResult> UpdateAdmin(string id, Admin admin)
//    {
//        if (id != admin.AdminID)
//        {
//            return BadRequest();
//        }

//        _context.Entry(admin).State = EntityState.Modified;

//        try
//        {
//            await _context.SaveChangesAsync();
//        }
//        catch (DbUpdateConcurrencyException)
//        {
//            if (!AdminExists(id))
//            {
//                return NotFound();
//            }
//            else
//            {
//                throw;
//            }
//        }

//        return NoContent();
//    }

//    // DELETE: api/Admin/{id}
//    [HttpDelete("{id}")]
//    public async Task<IActionResult> DeleteAdmin(int id)
//    {
//        var admin = await _context.Admins.FindAsync(id);
//        if (admin == null)
//        {
//            return NotFound();
//        }

//        _context.Admins.Remove(admin);
//        await _context.SaveChangesAsync();

//        return NoContent();
//    }

//    // Example: Assign Group Leader to the Team
//    [HttpPost("AssignGroupLeader")]
//    public async Task<IActionResult> AssignGroupLeader(int adminId, int groupLeaderId)
//    {
//        // Check if both admin and group leader exist
//        var admin = await _context.Admins.FindAsync(adminId);
//        var groupLeader = await _context.GroupLeaders.FindAsync(groupLeaderId);

//        if (admin == null || groupLeader == null)
//        {
//            return NotFound();
//        }

//        // Perform the assignment logic (e.g., create an AdminGroupLeader entry)
//        // ...

//        await _context.SaveChangesAsync();

//        return Ok();
//    }
   


  
//}
