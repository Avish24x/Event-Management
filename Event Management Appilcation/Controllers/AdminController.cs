using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Event_Management_Appilcation.Controllers
{
    [Authorize(Roles = "Super Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        
        [HttpGet("User/list")]

            public IEnumerable<string> Get()
        {
            return new List<string> { "Ahmed", "Ali", "Ashan"};
        }
    }
}
