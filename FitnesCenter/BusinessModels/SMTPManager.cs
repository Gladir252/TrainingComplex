using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FitnesCenter.BusinessModels
{
    public static class SMTPManager
    {
        public static void SendMessage(string recipient, string body)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("myusername@gmail.com", "mypwd"),
                EnableSsl = true
            };
            client.Send("myusername@gmail.com", recipient, "your password", body);
        }
    }
}
