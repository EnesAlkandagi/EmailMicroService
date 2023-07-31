using Core.Utilities.Results;
using MailKit.Net.Smtp;
using MimeKit;
using NotificationMicroService.Models;

namespace NotificationMicroService.Core.Helpers
{
    public class EmailHelper
    {
        public MimeMessage CreateEmailMessage(EmailMessageModel message, EmailConfiguration emailConfiguration)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", emailConfiguration.From));
            emailMessage.To.AddRange(message.PeopleToSend);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            return emailMessage;
        }

        public Result Send(MimeMessage mailMessage, EmailConfiguration emailConfiguration)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(emailConfiguration.SmtpServer, emailConfiguration.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(emailConfiguration.UserName, emailConfiguration.Password);
                    client.Send(mailMessage);
                    return new SuccessResult("Mail başarıyla gönderildi");
                }
                catch
                {
                    return new ErrorResult("Bir hata ile karşılaşıldı");                    
                    
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}
