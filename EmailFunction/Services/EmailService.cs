using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailFunction.Services
{
    public class EmailService
    {
        public async Task<bool> SendEmail(string message, List<string> to)
        {
            var authentication = new NetworkCredential("hramrez3@gmail.com", "ElGoldoZozoYLolaJiji2240");

            var client = new SmtpClient("smtp.gmail.com")
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = authentication,
                Port = 587,
                EnableSsl = true
            };

            var mailAddress = new MailAddress("hramrez3@gmail.com", "Hector Ramirez");

            var mailMessage = new MailMessage()
            {
                Subject = "Boss Change!!",
                SubjectEncoding = Encoding.UTF8,
                From = mailAddress,

                Body = message,
                BodyEncoding = Encoding.UTF8,
            };

            foreach (var destinatary in to)
            {
                mailMessage.To.Add(new MailAddress(destinatary));
            }

            client.Send(mailMessage);

            return true;
        }

        public async static Task CreateMessage(string correo)
        {
            var email = new EmailService();
            string mensaje = $"Hola mensaje de prueba enviado por {correo}";

            List<string> toAddress = new()
            {
                correo
            };

            await email.SendEmail(mensaje, toAddress);
        }
    }
}
