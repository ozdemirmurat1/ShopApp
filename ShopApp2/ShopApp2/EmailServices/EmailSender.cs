using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp2.Presentation.EmailServices
{
    public class EmailSender : IEmailSender
    {
        private const string SendGridKey = "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";
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(SendGridKey, subject, htmlMessage, email);
        }

        private Task Execute(string sendGridKey, string subject, string message, string email)
        {
            var client = new SendGridClient(sendGridKey);

            var msg = new SendGridMessage()
            {
                From=new EmailAddress("info@shopapp.com","Shop App"),
                Subject=subject,
                PlainTextContent=message,
                HtmlContent=message
            };
            msg.AddTo(new EmailAddress(email));
            return client.SendEmailAsync(msg);
        }
    }
}
