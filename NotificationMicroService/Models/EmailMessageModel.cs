using MimeKit;
using MailKit.Net.Smtp;

namespace NotificationMicroService.Models
{
    public class EmailMessageModel
    {
        public EmailMessageModel(IEnumerable<string> peopleToSend, string subject, string content)
        {
            PeopleToSend = new List<MailboxAddress>();
            PeopleToSend.AddRange(peopleToSend.Select(pts => new MailboxAddress("email", pts)));
            Subject = subject;
            Content = content;
        }

        public List<MailboxAddress> PeopleToSend { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
