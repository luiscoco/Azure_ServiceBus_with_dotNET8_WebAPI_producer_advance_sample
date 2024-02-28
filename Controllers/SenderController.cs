using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Mvc;

namespace ServiceBusSenderApi.Controllers
{
    public class MessageDto
    {
        public string? Body { get; set; }
        public string? SessionId { get; set; }
        public DateTime? ScheduledEnqueueTimeUtc { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class ServiceBusSenderController : ControllerBase
    {
        private static string connectionString = "Endpoint=sb://myservicebus1974.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=c/7ve5kw9QuPqM8YSUWQvNTrjM+y5hkmp+ASbE85qY4=";
        private static string queueName = "myqueue";
        private static ServiceBusClient client;
        private static ServiceBusSender sender;

        static ServiceBusSenderController()
        {
            client = new ServiceBusClient(connectionString);
            sender = client.CreateSender(queueName);
        }

        [HttpPost("send")]
        public async Task<ActionResult> SendMessage([FromBody] MessageDto messageDto)
        {
            var message = new ServiceBusMessage(messageDto.Body);

            if (!string.IsNullOrEmpty(messageDto.SessionId))
            {
                message.SessionId = messageDto.SessionId;
            }

            if (messageDto.ScheduledEnqueueTimeUtc.HasValue)
            {
                message.ScheduledEnqueueTime = messageDto.ScheduledEnqueueTimeUtc.Value;
            }

            await sender.SendMessageAsync(message);
            return Ok($"Sent message: {messageDto.Body}");
        }
    }
}
