using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HttpModuleHandlerPrac
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*check following link for more details
            http://www.hanselman.com/blog/BackToBasicsDynamicImageGenerationASPNETControllersRoutingIHttpHandlersAndRunAllManagedModulesForAllRequests.aspx
             *
             */
            routes.Add(new Route("images/user.Image",
                new MyCustomImageRouteHandler()));


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id1}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id1 = UrlParameter.Optional
                }
            );

        }
    }

    public class MyCustomImageRouteHandler : IRouteHandler
    {
        public System.Web.IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new CurrentUserImageHandler();
        }
    }
}