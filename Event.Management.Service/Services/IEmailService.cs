

using Event.Management.Service.Models;

namespace Event.Management.Service.Services
{
    public interface IEmailService
    {
        void SendEmail(Message message);
    }
}
