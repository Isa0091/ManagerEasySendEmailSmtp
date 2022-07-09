using ManagerEasySendEmailSmtp.Abstract;
using ManagerEasySendEmailSmtp.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEasySendEmailSmtp
{
    public class ManagerEasySendEmailSmtpProvider : IManagerEasySendEmailSmtpProvider
    {
        private MailMessage _mailMessage;
        public ManagerEasySendEmailSmtpProvider()
        {
            _mailMessage = new MailMessage();
        }

        public async Task<string> SendEmail(SendEmailDto sendEmail)
        {
            _mailMessage.From = new MailAddress(sendEmail.SourceEmail, sendEmail.SenderName);
            _mailMessage.To.Add(new MailAddress(sendEmail.ReceiverEmail));
            _mailMessage.IsBodyHtml = sendEmail.TextFormat == TextFormat.Html;
            _mailMessage.Subject = sendEmail.Subject;
            _mailMessage.Body = sendEmail.Message;
            _mailMessage.Priority = MailPriority.Normal;

            if (sendEmail.AttachedFiles != null && sendEmail.AttachedFiles.Any())
                AddAttachments(sendEmail, _mailMessage);

            if (string.IsNullOrEmpty(sendEmail.ReplyToMesaageId) == false)
            {
                _mailMessage.Headers.Add("In-Reply-To", sendEmail.ReplyToMesaageId);
                _mailMessage.Headers.Add("References", sendEmail.ReplyToMesaageId);
            }

            string messageId = Guid.NewGuid().ToString() + "." + sendEmail.SmtpCredentials.Host;
            _mailMessage.Headers.Add("Message-ID", messageId);

            SmtpClient client = new SmtpClient(sendEmail.SmtpCredentials.Host, sendEmail.SmtpCredentials.Port);
            client.UseDefaultCredentials = sendEmail.SmtpCredentials.UseDefaultCrentials;
            client.Credentials = new NetworkCredential(sendEmail.SmtpCredentials.User, sendEmail.SmtpCredentials.Password);
            client.EnableSsl = sendEmail.SmtpCredentials.RequireSsl;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            await client.SendMailAsync(_mailMessage);

            return messageId;
        }

        /// <summary>
        ///  Agrego los archivos adjuntos a enviar por correo electronico
        /// </summary>
        /// <param name="sendEmail"></param>
        /// <returns></returns>
        private void AddAttachments(SendEmailDto sendEmail, MailMessage mailMessage)
        {
            foreach (AttachedFileDto attachedFile in sendEmail.AttachedFiles)
            {
                Stream streamAttachedFile = new MemoryStream(attachedFile.AttachedFile.ToArray());
                Attachment attachment = new Attachment(streamAttachedFile, new ContentType(attachedFile.ContentType));

                mailMessage.Attachments.Add(attachment);
            }
        }
    }
}
