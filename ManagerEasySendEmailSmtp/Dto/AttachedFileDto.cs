using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEasySendEmailSmtp.Dto
{
    public class AttachedFileDto
    {
        /// <summary>
        /// Si se requiere enviar un archivo adjuto se envian los bytes 
        /// </summary>
        public List<byte> AttachedFile { get; set; }

        /// <summary>
        /// El content type del archivo
        /// </summary>
        public string ContentType { get; set; }
    }
}
