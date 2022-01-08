using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_Server.BroadCastService
{

    public class NotificationHubChatHub : Hub
    {
        private static List<string> ConnectedClientIds = new List<string>();
        #region Server  Methods

        /// <summary>
        /// This method sends back message to all clients
        /// </summary>
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync(NotificationTypes.All, user, message);
        }

        /// <summary>
        /// This method sends back message to only that client which calls this
        /// </summary>

        public async Task SendMessageToCaller(string request)
        {
            var caller = Clients.Caller;
            var connectionId = Context.ConnectionId;
            await caller.SendAsync(NotificationTypes.Caller, $"You are requesting from this Connection Id: {connectionId}\n Your Request is: {request}");
        }
        public async Task SendMessageToGroup(string groupId, string user, string message)
        {
            await Clients.Group(groupId).SendAsync(NotificationTypes.Group, user, message);
        }

        public override Task OnConnectedAsync()
        {
            ConnectedClientIds.Add(Context.ConnectionId);
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            ConnectedClientIds.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
        #endregion

    }
}
