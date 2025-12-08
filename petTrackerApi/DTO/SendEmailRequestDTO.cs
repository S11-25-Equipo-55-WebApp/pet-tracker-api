namespace petTrackerApi.DTO
{
    public class SendEmailRequestDTO
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string To { get; set; }
    }
}
