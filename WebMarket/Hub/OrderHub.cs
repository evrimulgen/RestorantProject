using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace WebMarket.Hub
{
    [HubName("orders")]
    public class OrderHub : Microsoft.AspNet.SignalR.Hub
    {
    }
}