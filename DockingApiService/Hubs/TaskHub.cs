using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace DockingApiService.Hubs;

public class JobHub : Hub
{
    public override Task OnConnectedAsync()
    {
        return Groups.AddToGroupAsync(Context.ConnectionId, $"Job{Context.GetHttpContext().Request.Query["jobId"]}");
    }
}
