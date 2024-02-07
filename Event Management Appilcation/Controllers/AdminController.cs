using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Event_Management_Appilcation.Models;

[Authorize(Roles = "Super Admin")]
[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly ApplicationUser _context;

    public AdminController(ApplicationUser context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
    {
        return await _context.Admins.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Admin>> GetAdmin(int id)
    {
        var admin = await _context.Admins.FindAsync(id);

        if (admin == null)
        {
            return NotFound();
        }

        return admin;
    }

    private bool AdminExists(int id)
    {
        return _context.Admins.Any(e => e.AdminID == id);
    }

    [HttpPost]
    public async Task<ActionResult<Admin>> CreateAdmin(Admin admin)
    {
        _context.Admins.Add(admin);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAdmin), new { id = admin.AdminID }, admin);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAdmin(int id, Admin admin)
    {
        if (id != admin.AdminID)
        {
            return BadRequest();
        }

        _context.Entry(admin).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AdminExists(id))
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAdmin(int id)
    {
        var admin = await _context.Admins.FindAsync(id);
        if (admin == null)
        {
            return NotFound();
        }

        _context.Admins.Remove(admin);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost("AssignGroupLeader")]
    public async Task<IActionResult> AssignGroupLeader(int adminId, int groupLeaderId)
    {
        // Check if both admin and group leader exist
        var admin = await _context.Admins.FindAsync(adminId);
        var groupLeader = await _context.GroupLeaders.FindAsync(groupLeaderId);

        if (admin == null || groupLeader == null)
        {
            return NotFound();
        }

        // Perform the assignment logic (e.g., create an AdminGroupLeader entry)
        // ...

        await _context.SaveChangesAsync();

        return Ok();
    }
}
