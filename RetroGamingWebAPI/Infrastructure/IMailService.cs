using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetroGamingWebAPI.Infrastructure
{
    public interface IMailService
    {
        void SendMail(string message);
    }
}
