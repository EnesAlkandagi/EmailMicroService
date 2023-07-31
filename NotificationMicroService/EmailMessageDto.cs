namespace NotificationMicroService
{
    public class EmailMessageDto
    {
        public List<string> PeopleToSend { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
