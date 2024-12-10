using Microsoft.AspNetCore.SignalR;

namespace ProiectMPA.Hubs
{
    public class OrderHub : Hub
    {
        public async Task NotifyOrderStatusChanged(int orderId, string status, string userId)
        {
            await Clients.Group(userId).SendAsync("ReceiveOrderStatusChange", orderId, status);
        }

        public async Task JoinGroup(string userId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userId);
        }

        public async Task LeaveGroup(string userId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, userId);
        }
    }
}
