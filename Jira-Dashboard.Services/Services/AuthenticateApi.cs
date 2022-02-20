using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jira_Dashboard.Services.Services
{
    public class AuthenticateApi
    {
        public static string Authentication()
        {
            var username = "hramirez2298@gmail.com";
            var password = "vg0xJlx5mwCRlr3wA3Ry1F88";

            string encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                               .GetBytes(username + ":" + password));

            return encoded;
        }
    }
}
