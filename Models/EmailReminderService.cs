using System.Net.Mail;
using System.Net;


namespace MedicationReminder.Models
{
    public class EmailReminderService : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
         
                var currentTime = DateTime.Now;
                var scheduledTime = new DateTime(2023, 12, 25, 22, 27, 0);
             
                // Set the time to 10:00 AM

                if (currentTime >= scheduledTime)
                {
                   
                    await SendEmail("pradyunyachunchwar84@gmail.com", "Reminder: Take your medicine", "Don't forget to take your medicine.");

                
                    scheduledTime = scheduledTime.AddDays(0);
                }

                var delayTime = scheduledTime - currentTime;
                await Task.Delay(delayTime, stoppingToken);
            }
        }

        private async Task SendEmail(string toEmail, string subject, string message)
        {
            using var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("21030118@ycce.in", "dgkl wpsk beve cdhb"),
                EnableSsl = true,
            };

            using var mailMessage = new MailMessage("21030118@ycce.in", toEmail, subject, message);
            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
