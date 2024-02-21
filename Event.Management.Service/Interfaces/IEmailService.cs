using Event.Management.Service.Models;

namespace Event.Management.Service.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(Message message);
    }
}
