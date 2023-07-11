﻿using MimeKit;
using MailKit.Net.Smtp;

namespace EmailService
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailSenderService(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }
        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }
        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;

            var htmlContent = message.Content.Replace("{{resetToken}}", message.ResetToken); 

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = htmlContent;

            emailMessage.Body = bodyBuilder.ToMessageBody();

            return emailMessage;
        }


        private void Send(MimeMessage mailMessage) 
        { 
            using(var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

                    client.Send(mailMessage);
                }
                catch (Exception)
                {

                    throw;
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
