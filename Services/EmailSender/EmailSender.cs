using System.Net;
using System.Net.Mail;
using mlbd_logistics_management.Services.Interfaces;

namespace mlbd_logistic_management.Services.EmailSender

{
    public class EmailSender : IEmailSender
    {
       public Task SendEmailAsync(string email, string subject, string body)
       {
            var mail = ""; 
            var pw = "";

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pw)
            };

            return client.SendMailAsync( new MailMessage(from: mail, to: email, subject, body));

       }
    }
}