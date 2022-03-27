using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using EmailFunction.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace EmailFunction
{
    public class EmailTrigger
    {
        [Function("EmailTriggerGet")]
        public async static Task<dynamic> Get(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req,
            ILogger log)
        {
            await EmailService.CreateMessage("hramirez2298@gmail.com");

            return "ok";
        }
    }
}
