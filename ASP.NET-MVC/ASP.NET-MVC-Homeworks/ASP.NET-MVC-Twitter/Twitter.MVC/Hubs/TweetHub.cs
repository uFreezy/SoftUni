using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Twitter.MVC.Hubs
{
    [HubName("tweet")]
    public class TweetHub : Hub
    {
        public void GetTweets()
        {
            this.Clients.All.receiveTweets();
        }
    }
}