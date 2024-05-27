using Microsoft.AspNetCore.SignalR;

namespace RusRoads.Application.Hubs;

public class ChatHub : Hub
{
    public async Task Send(string message)
    {
        await this.Clients.All.SendAsync("Message", message);
    }
}
