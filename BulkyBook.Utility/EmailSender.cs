using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bookish.Utility
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailOptions emailOptions;

        public EmailSender(IOptions<EmailOptions> options)
        {
            emailOptions = options.Value;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // return Execute(emailOptions.SendGridKey, subject, htmlMessage, email);
            var emailToSend = new MimeMessage();
            emailToSend.From.Add(MailboxAddress.Parse("kvdldhruv@gmail.com"));
            emailToSend.To.Add(MailboxAddress.Parse(email));
            emailToSend.Subject = subject;
            emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text= htmlMessage };

            //Send email.
            using(var emailClient = new SmtpClient())
            {
                emailClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                emailClient.Authenticate("kvdldhruv@gmail.com", "gwxnjanhahyiqssz");
                emailClient.Send(emailToSend);
                emailClient.Disconnect(true);
            }

            return Task.CompletedTask;
        }
        //private Task Execute(string sendGridKEy, string subject,string message, string email)
        //{
        //    var client = new SendGridClient(sendGridKEy);
        //    var from = new EmailAddress("admin@bookish.com", "Bookish");
        //    var to = new EmailAddress(email, "End User");
        //    var msg = MailHelper.CreateSingleEmail(from, to, subject, "", message);
        //    return client.SendEmailAsync(msg);
        //}
    }
}
