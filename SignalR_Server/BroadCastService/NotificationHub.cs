using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_Server.BroadCastService
{
   
    public class NotificationHubChatHub : Hub
    {

        #region Server  Methods
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync(NotificationTypes.Chat, user, message);
        }
        public Task SendMessageToCaller(string user, string message)
        {
            return Clients.Caller.SendAsync(NotificationTypes.Chat, user, message);
        }
        public Task SendMessageToGroup(string user, string message)
        {
            return Clients.Group("J Boys").SendAsync(NotificationTypes.Chat, user, message);
        }
        #endregion

    }
}
