using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using CoreContracts.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;

namespace TaviscaDataAnalyzerServiceProvider
{
    public class EmailService : IEmailService
    {
        public void generatingMail(RecipientDetails details)
        {
            string reportBody = "";
            for (int tableCount = 0; tableCount < details.Labels.Length; tableCount++)
            {
                reportBody += "<h2> Analysis Report of " + details.FilterName[tableCount] + "</h2>" +
                               "<h3> from " + details.StartDate[tableCount] + " upto " + details.EndDate[tableCount] + " at " + details.Location[tableCount] + "</h3>" + "<br>" +
                               " <table border=" + 1 + " cellpadding=" + 10 + " cellspacing=" + 0 + " width = " + 500 + ">" +
                               "<tr bgcolor='#D3D3D3'>" +
                               "<td><b>Labels</b></td> " +
                               "<td><b>Statistics</b></td>" +
                               "</tr>";
                for (int RowCount = 0; RowCount < details.Labels[tableCount].Length; RowCount++)
                {
                    reportBody += "<tr>" +
                    "<td>" + details.Labels[tableCount][RowCount] + "</td>" +
                    "<td> " + details.Statistics[tableCount][RowCount] + "</td> " +
                    "</tr>";
                }
                reportBody += "</table>" + "<br>";
            }


            StringReader sr = new StringReader(reportBody);
            Document pdfDoc = new Document(PageSize.A4, 50f, 10f, 20f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();

                MailMessage mailMessage = new MailMessage("purab2018@gmail.com", details.RecipientEmialId);
                mailMessage.Subject = "Data Analysis Report";
                mailMessage.Body = "Your analysis report is attached with this Email !";
                mailMessage.IsBodyHtml = true;
                mailMessage.Attachments.Add(new Attachment(new MemoryStream(bytes), "DataAnalysisReport.pdf"));

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
}
