using System;
using System.Configuration;
using SendGrid;
using BeerScheduler.Contracts;
using SendGrid.Helpers.Mail;

namespace BeerScheduler.NotificationAccessors
{
    public class SendGridAccessor : ISendGridAccessor
    {
        public void Send(string recipient, string subject, string body)
        {
            string apiKey = ConfigurationManager.AppSettings["SendGridApiKey"];

            dynamic sg = new SendGridAPIClient(apiKey);

            Email from = new Email(ConfigurationManager.AppSettings["SendFrom"], "BeerScheduler Support");
            Email to = new Email(recipient);
            Content content = new Content("text/html", body);
            Mail mail = new Mail(from, subject, to, content);

            sg.client.mail.send.post(requestBody: mail.Get());
        }
    }
}
