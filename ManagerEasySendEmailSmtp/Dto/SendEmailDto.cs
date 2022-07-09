using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEasySendEmailSmtp.Dto
{
    /// <summary>
    /// Calse que contiene lo necesario para el envio de email
    /// </summary>
    public class SendEmailDto
    {
        /// <summary>
        /// Direccion de correo electronico del que envia el email
        /// </summary>
        public string SourceEmail { get; set; }

        /// <summary>
        /// Nombre del remitente del que envia el email
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// Direccion de correo electronico al que se enviara el mensaje
        /// </summary>
        public string ReceiverEmail { get; set; }

        /// <summary>
        /// Mensaje a enviar en el correo
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Indica el formato del mensaje
        /// </summary>
        public TextFormat TextFormat { get; set; }

        /// <summary>
        /// El identificador del mensaje que sera un reply
        /// </summary>
        public string ReplyToMesaageId { get; set; }

        /// <summary>
        /// Titulo de envio del mensaje
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Datos del archivo si se envia
        /// </summary>
        public List<AttachedFileDto> AttachedFiles { get; set; }
        /// <summary>
        /// Credenciales para el envio de smtp
        /// </summary>
        public SmtpCredentialsDto SmtpCredentials { get; set; }
    }
}
