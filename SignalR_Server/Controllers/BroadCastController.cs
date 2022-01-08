using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR_Server.BroadCastService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_Server.Controllers
{
    [Route("api")]
    [ApiController]
    public class BroadCastController : ControllerBase
    {
        public readonly NotificationHubChatHub _notificationHubChatHub;
        public BroadCastController(NotificationHubChatHub notificationHubChatHub)
        {
            _notificationHubChatHub = notificationHubChatHub;
        }
        [HttpPost("broadcast-message")]
        public async Task<bool> BroadCastMessage(string sender,string message)
        {
            await _notificationHubChatHub.SendMessage(sender,message);
            return true;
        }
    }
}
