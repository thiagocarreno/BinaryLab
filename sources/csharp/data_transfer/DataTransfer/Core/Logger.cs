using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.IO;

namespace DataTransfer.Core
{
    public class Logger
    {
        public StringBuilder LogText;

        public Logger()
        {
            LogText = new StringBuilder();
        }

        public void Log(
            string message,
            Enumerators.LogColor color = Enumerators.LogColor.Information
        )
        {
            Check.NotNullOrWhiteSpace(() => message);

            Console.ForegroundColor = (ConsoleColor)color;
            Console.Write(message);
            LogText.Append(message);
            Console.ResetColor();
        }

        public void SendEmail(
            string subject,
            string message,
            params string[] addresses
        )
        {
            Check.NotNullOrWhiteSpace(() => message);

            var stackTrace = new StringBuilder();

            try
            {
                stackTrace.AppendFormat("Data: {0} \r\n", DateTime.Now);
                stackTrace.AppendFormat("Message: {0} \r\n", message);

                using (var client = new SmtpClient())
                {
                    var mail = new MailMessage();
                    mail.Subject = subject;
                    mail.Body = stackTrace.ToString();

                    if (addresses != null && addresses.Length > 0)
                    {
                        foreach (var address in addresses)
                        {
                            mail.To.Add(address);
                        }

                        client.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        public void Write(
            string path
        ) 
        {
            Check.NotNullOrWhiteSpace(() => path);

            File.WriteAllText(
                path,
                LogText.ToString()
            );
        }
    }
}