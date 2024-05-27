using Microsoft.AspNetCore.SignalR;

namespace RusRoads.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task Send(string username, string message)
        {
            await this.Clients.All.SendAsync("Send", username, message);
        }
    }
}
