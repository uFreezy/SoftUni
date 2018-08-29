using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Twitter.MVC.Hubs
{
    [HubName("notifications")]
    public class NotificationsHub : Hub
    {
        //private string _username;

        public void GetNotifications(string username)
        {
            //var name = Context.QueryString["username"];

            var hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationsHub>();

            hubContext.Clients.Group(username).receiveNotification();
        }

        public override Task OnConnected()
        {
            var name = this.Context.QueryString["username"];
            // _username = name;

            this.Groups.Add(this.Context.ConnectionId, name);

            return base.OnConnected();
        }
    }
}