using System.Web.Mvc;
using System.Web.Routing;

namespace Twitter.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("UserProfile", "{controller}/{action}/{username}",
                new
                {
                    controller = "Home",
                    action = "Index",
                    username = UrlParameter.Optional
                });

//            routes.MapRoute("Retweet", "{controller}/{action}/{tweetId}",
//                new
//                {
//                    controller = "Home",
//                    action = "Index"
//                }
//                );

            routes.MapRoute("Default", "{controller}/{action}/{pageSize}/{startIndex}",
                new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional,
                    startIndex = 0,
                    pageSize = 10
                }
                );
        }
    }
}