using System.Threading;
using Microsoft.AspNet.Identity;

namespace OnlineShop.Service.Infrastructure
{
    public class AspNetUserIdProvider : IUserIdProvider
    {
        public string GetUserId()
        {
            return Thread.CurrentPrincipal.Identity.GetUserId();
        } 
    }
}