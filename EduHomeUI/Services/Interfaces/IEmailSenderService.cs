namespace EmailService
{
    public interface IEmailSenderService
    {
        void SendEmail(Message message);
    }
}
