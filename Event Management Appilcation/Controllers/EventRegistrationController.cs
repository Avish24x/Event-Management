using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Event_Management_Appilcation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventRegistrationController : ControllerBase
    {

        private readOnly IConfiguration Config;

        public EventRegistrationController(IConfiguration config)
        {
            _config = config;
        }

    }
}
