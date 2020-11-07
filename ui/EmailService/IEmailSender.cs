using System.Threading.Tasks;

namespace ui.EmailService
{
    public interface IEmailSender
    {
         
         Task SendEmailAsync(string email,string subject,string message);
    }
}