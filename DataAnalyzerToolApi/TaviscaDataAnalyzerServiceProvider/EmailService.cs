using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using CoreContracts.Models;

namespace TaviscaDataAnalyzerServiceProvider
{
    public class EmailService : IEmailService
    {
        public void generatingMail(RecipientDetails details)
        {
            string textBody = "";
            for (int tableCount = 0; tableCount < details.Labels.Length; tableCount++)
            {
                textBody = textBody + "<h2> Analysis Report of " + details.FilterName[tableCount] + "</h2>" +
                               "<h3> from " + details.StartDate[tableCount] + " upto " + details.EndDate[tableCount] + " at " + details.Location[tableCount] + "</h3>" + "<br>" +
                               " <table border=" + 1 + " cellpadding=" + 10 + " cellspacing=" + 0 + " width = " + 500 + ">" +
                               "<tr bgcolor='#D3D3D3'>" +
                               "<td><b>Lables</b></td> " +
                               "<td><b>Statistics</b></td>" +
                               "</tr>";
            for (int loopCount = 0; loopCount < details.Labels[tableCount].Length; loopCount++)
            {
                textBody += "<tr>" +
                            "<td>" + details.Labels[tableCount][loopCount] + "</td>" +
                            "<td> " + details.Statistics[tableCount][loopCount] + "</td> " +
                            "</tr>";
            }
            textBody += "</table>" + "<br>";
        }


        MailMessage mailMessage = new MailMessage("purab2018@gmail.com", details.RecipientEmialId);
            mailMessage.Subject = "Data Analysis Report";
            mailMessage.Body = textBody;
            mailMessage.IsBodyHtml = true;

            NetworkCredential credentials = new NetworkCredential();
            credentials.UserName = "purab2018@gmail.com";
            credentials.Password = "Tavisca@123";

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Credentials = credentials;
            client.Port = 587;
            client.EnableSsl = true;

            try
            {
                client.Send(mailMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
