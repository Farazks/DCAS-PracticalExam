using Microsoft.CodeAnalysis.Emit;
using Microsoft.Extensions.Options;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System;

namespace DCAS_PracticalExam.HelperModels
{
    public class MailSender
    {
        private readonly SmtpConfig smtpConfig;

        //Constructor to injecct Our Configuration service 
        //which is service.Configuration<SmtpConfigModel>() in startup.cs class
        //this will copy all the data available in smtpconfig variaable in appSeeting.json
        //to smtpConfigModel
        public MailSender(IOptions<SmtpConfig> smtpConfig)
        {
            this.smtpConfig = smtpConfig.Value;
        }


        public async Task<string> SendEmailPublic(EmailOptions options)
        {
            return await SendEmail(options);
        }

        private async Task<string> SendEmail(EmailOptions emailOptions)
        {
            try
            {
                MailMessage mail = new MailMessage()
                {
                    Subject = emailOptions.subject,
                    Body = emailOptions.body,
                    From = new MailAddress(smtpConfig.senderAddress, smtpConfig.senderDisplayName),
                    IsBodyHtml = smtpConfig.isBodyHtml,
                    BodyEncoding = Encoding.Default
                };

                if (emailOptions.attachment != null)
                {
                    Attachment att = new Attachment(new MemoryStream(emailOptions.attachment), emailOptions.licenceNo + ".pdf");
                    mail.Attachments.Add(att);
                }
                foreach (var address in emailOptions.toEmail.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    mail.To.Add(new MailAddress(address));
                }

                NetworkCredential networkCredential = new NetworkCredential(smtpConfig.userName, smtpConfig.password);
                SmtpClient client = new SmtpClient()
                {
                    Host = smtpConfig.host,
                    Port = smtpConfig.port,
                    EnableSsl = smtpConfig.enableSsl,
                    Credentials = networkCredential
                };
                await client.SendMailAsync(mail);

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
