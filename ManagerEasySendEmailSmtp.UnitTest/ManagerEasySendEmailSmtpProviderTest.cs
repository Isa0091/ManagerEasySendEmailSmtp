using AutoFixture;
using ManagerEasySendEmailSmtp.Abstract;
using ManagerEasySendEmailSmtp.Dto;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEasySendEmailSmtp.UnitTest
{
    public class ManagerEasySendEmailSmtpProviderTest
    {
        private Fixture fixture;

        /// <summary>
        /// Contructor donde puede colcoar sus credenciales para realizar las diferentes pruebas propuestas
        /// </summary>
        public ManagerEasySendEmailSmtpProviderTest()
        {
            fixture = new Fixture();
            fixture.Customize<SendEmailDto>(x => x
                .With(z => z.Message, "test")
                .With(z => z.ReceiverEmail, "")
                .With(z => z.SenderName, "")
                .With(z => z.SourceEmail, "")
                .With(z => z.Subject, "")
                .Without(z => z.AttachedFiles)
                .With(z => z.TextFormat, TextFormat.PlainText)
                .With(z => z.SmtpCredentials, new SmtpCredentialsDto("","","", 0, false, false)));
        }

        [Test]
        public async Task SendEmail_SendEmailTextFormat_SendEmailSuccess()
        {
            //Preparar
            IManagerEasySendEmailSmtpProvider sendEmailSmtpProvider = GetManagerEasySendEmailSmtpProvider();
            SendEmailDto sendEmail = fixture.Create<SendEmailDto>();

            //Ejecutar
            string messageId = await sendEmailSmtpProvider.SendEmail(sendEmail);

            //Probar
            Assert.IsNotNull(messageId);
        }

        [Test]
        public async Task SendEmail_SendEmailWithReply_SendEmailReplySuccess()
        {
            //Preparar
            IManagerEasySendEmailSmtpProvider sendEmailSmtpProvider = GetManagerEasySendEmailSmtpProvider();
            SendEmailDto sendEmail = fixture.Create<SendEmailDto>();

            string messageId = await sendEmailSmtpProvider.SendEmail(sendEmail);
            sendEmail.ReplyToMesaageId = messageId;
            sendEmail.Message = "es reply to" + messageId;

            //Ejecutar
            string secondMessageId = await sendEmailSmtpProvider.SendEmail(sendEmail);

            //Probar
            Assert.IsNotNull(secondMessageId);
        }


        [Test]
        public async Task SendEmail_SendEmailWithAttachedFile_SendEmailSuccess()
        {
            //Preparar
            IManagerEasySendEmailSmtpProvider sendEmailSmtpProvider = GetManagerEasySendEmailSmtpProvider();

            SendEmailDto sendEmail = fixture.Create<SendEmailDto>();
            sendEmail.AttachedFiles = new List<AttachedFileDto>{ new AttachedFileDto()
            {
                AttachedFile = GetBytesToFileToBae64(GetImageBase64()),
                ContentType = "image/png"
            }
            };

            //Ejecutar
            string messageId = await sendEmailSmtpProvider.SendEmail(sendEmail);

            //Probar
            Assert.IsNotNull(messageId);
        }


        [Test]
        public async Task SendEmail_SendEmailWithHtml_SendEmailSuccess()
        {
            //Preparar
            IManagerEasySendEmailSmtpProvider sendEmailSmtpProvider = GetManagerEasySendEmailSmtpProvider();

            SendEmailDto sendEmail = fixture.Create<SendEmailDto>();
            sendEmail.TextFormat = TextFormat.Html;
            sendEmail.Message = GetHtmlContent();

            //Ejecutar
            string messageId = await sendEmailSmtpProvider.SendEmail(sendEmail);

            //Probar
            Assert.IsNotNull(messageId);
        }


        #region Metodos privados
        /// <summary>
        /// Obtengo el provider
        /// </summary>
        /// <returns></returns>
        private IManagerEasySendEmailSmtpProvider GetManagerEasySendEmailSmtpProvider()
        {
            return new ManagerEasySendEmailSmtpProvider();
        }

        /// <summary>
        /// Transformo un archivo de base64 a un listado de bytes
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private List<byte> GetBytesToFileToBae64(string file)
        {
            byte[] bytesFile = Convert.FromBase64String(file);
            return bytesFile.ToList();
        }

        /// <summary>
        /// Imagen en bytes
        /// </summary>
        /// <returns></returns>
        private string GetImageBase64()
        {
            return "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";
        }

        /// <summary>
        /// Obtengo contenido html
        /// </summary>
        /// <returns></returns>
        private string GetHtmlContent()
        {
            return "<h1 style='color: #5e9ca0;'>You can edit <span style='color: #2b2301;'>this demo</span> text!</h1>" +
                "<h2 style = 'color: #2e6c80;' > How to use the editor:</h2>" +
                "<p> Paste your documents in the visual editor on the left or your HTML code in the source editor in the right. <br/>" +
                " Edit any of the two areas and see the other changing in real time.&nbsp;</p><p>Click the " +
                "<span style = 'background-color: #2b2301; color: #fff; display: inline-block; padding: 3px 10px; font-weight: bold; border-radius: 5px;' >" +
                " Clean </span> button to clean your source code.</ p ><p> &nbsp;</p> ";
        }
        #endregion
    }
}
