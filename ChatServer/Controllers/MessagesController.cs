using System.Threading.Tasks;
using ChatServer.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace ChatServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : Controller
    {
        private NotificationsMessageHandler NotificationsMessageHandler { get; set; }

        public MessagesController(NotificationsMessageHandler notificationsMessageHandler)
        {
            NotificationsMessageHandler = notificationsMessageHandler;
        }

        [HttpGet]
        public async Task SendMessage([FromQuery]string message)
        {
           await NotificationsMessageHandler.SendMessageToAllAsync(message);
        }
    }
}