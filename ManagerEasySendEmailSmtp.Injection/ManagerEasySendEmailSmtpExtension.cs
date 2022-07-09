using ManagerEasySendEmailSmtp.Abstract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEasySendEmailSmtp.Injection
{
    public static class ManagerEasySendEmailSmtpExtension
    {
        /// <summary>
        /// Agrega la injeccion de dependencias
        /// </summary>
        /// <param name="services"></param>
        public static void AddManagerEasySendEmailSmtp(this IServiceCollection services)
        {
            services.AddScoped<IManagerEasySendEmailSmtpProvider, ManagerEasySendEmailSmtpProvider>();
        }
    }
}
