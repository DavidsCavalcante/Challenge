/// <summary>
/// IA.Hubs
/// </summary>

namespace IA.Hubs
{
    using Microsoft.AspNetCore.SignalR;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// SubscriptionHub
    /// </summary>
    public class SubscriptionHub : Hub
    {
        /// <summary>
        /// OnConnectedAsync
        /// </summary>
        /// <returns>base.OnConnectedAsync()</returns>
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        /// <summary>
        /// OnDisconnectedAsync
        /// </summary>
        /// <param name="exception">Exception exception</param>
        /// <returns>base.OnDisconnectedAsync(exception)</returns>
        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}