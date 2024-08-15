using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Photon.SignalR.Hubs
{
  [Authorize]
  public class NotificationHub : Hub
  {
    public async Task SendMessage(string user, string msg)
    {
      await Clients.User(Context.UserIdentifier!).SendAsync("ReceiveNotification", msg);
    }
  }
}

