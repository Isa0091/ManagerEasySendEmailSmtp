using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEasySendEmailSmtp.Dto
{
    /// <summary>
    /// Credenciales necesarias para poder usar los servicios de Smtp
    /// </summary>
    public class SmtpCredentialsDto
    {
        /// <summary>
        /// Constructor para colocar las credenciales
        /// </summary>
        /// <param name="user"></param>
        /// <param name="host"></param>
        /// <param name="password"></param>
        /// <param name="port"></param>
        /// <param name="requireSsl"></param>
        /// <param name="useDefaultCrentials"></param>
        public SmtpCredentialsDto(string user, string host, string password, int port, bool requireSsl, bool useDefaultCrentials)
        {
            User = user;
            Host = host;
            Password = password;
            Port = port;
            RequireSsl = requireSsl;
            UseDefaultCrentials = useDefaultCrentials;
        }
        /// <summary>
        /// Usuario SMTP para autenticarse en el envio de email
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Host del smtp de los email
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// Contraseña del smtp para el envio de email
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Puerto SMTP para el envio de los email del canal
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Requiere SSL en el envio de los email del canal
        /// </summary>
        public bool RequireSsl { get; set; }

        /// <summary>
        /// Usa las credenciales por defecto el smtp
        /// </summary>
        public bool UseDefaultCrentials { get; set; }
    }
}
