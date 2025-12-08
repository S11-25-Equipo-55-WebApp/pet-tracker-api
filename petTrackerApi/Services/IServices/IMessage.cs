namespace petTrackerApi.Services.IServices
{
    public interface IMessage
    {
        void SendEmail(string subject, string body, string to);
    }
}
