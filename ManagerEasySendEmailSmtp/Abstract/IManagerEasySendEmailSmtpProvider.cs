using ManagerEasySendEmailSmtp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEasySendEmailSmtp.Abstract
{
    /// <summary>
    /// Maneja un envio mas facil de mensajes de texto a travez de credenciales smtp
    /// </summary>
    public interface IManagerEasySendEmailSmtpProvider
    {
        /// <summary>
        /// Envia un email con los datos especificados
        /// </summary>
        /// <param name="sendEmail"></param>
        /// <returns></returns>
        Task<string> SendEmail(SendEmailDto sendEmail);
    }
}
