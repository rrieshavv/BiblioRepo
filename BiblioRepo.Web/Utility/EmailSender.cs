using Microsoft.AspNetCore.Identity.UI.Services;

namespace BiblioRepo.Web.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //logic to send emails in future

            //throw new NotImplementedException();
            return Task.CompletedTask;
        }
    }
}
