using Microsoft.AspNetCore.SignalR;

namespace SignalRHub
{
    public class NotifyHub:Hub<ITypedHubClient>
    {
    }

    public class ChartHub : Hub
    {
    }
}
