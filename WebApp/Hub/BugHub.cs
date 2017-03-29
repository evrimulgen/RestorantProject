using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace WebApp.Hub
{
    [HubName("Bugs")]
    public class BugHub : Microsoft.AspNet.SignalR.Hub
    {
    }
}