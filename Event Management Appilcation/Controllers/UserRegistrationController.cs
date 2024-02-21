using Event.Management.Data.Models;
using Event_Managemenent.Data.Models;
using Event_Management_Appilcation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Event_Management_Appilcation.Controllers
{
    //[Authorize(Roles = "Super Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class UserRegistrationController : ControllerBase
    {
        private readonly ApplicationUser _context;

        public UserRegistrationController(ApplicationUser context)
        {
            _context = context;
        }

        [HttpGet("id")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.ToListAsync();

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }

        [HttpPost]
        public async Task<ActionResult> RegisterForEvent([FromBody] User addUser)
        {
            //addUser.UserId = Guid.NewGuid();
            await _context.Users.AddAsync(addUser);
            await _context.SaveChangesAsync();
            return Ok(addUser);
        }

        //PUT: api/Admin
        //To protect from overposting attacks
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
