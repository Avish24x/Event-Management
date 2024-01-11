using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Management.Service.Models
{
    public class EmailConfiguration
    {
        public string From { get; set; } = null!;

        public string smtpServer { get; set; } = null!;

        public int Port { get; set; } 

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
