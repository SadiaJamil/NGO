using Microsoft.AspNetCore.Identity.UI.Services;

namespace E_Project.Models.Data
{
    public class EmailSender :IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}
