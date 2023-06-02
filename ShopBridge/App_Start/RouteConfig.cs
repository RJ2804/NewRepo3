using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace ShopBridge
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);


            routes.Ignore("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(name: "aboutGetAllCategories", routeTemplate: "api/{Controller}/{action}",
                defaults: new { Controller = "Categories", action = "GetAllCategories" });

            routes.MapHttpRoute(name: "aboutInsertToCategories", routeTemplate: "api/{Controller}/{action}",
     defaults: new { Controller = "Categories", action = "AddToCategories" });

            routes.MapHttpRoute(name: "aboutGetProduct", routeTemplate: "api/{Controller}/{action}",
defaults: new { Controller = "Product", action = "GetAllProductDetails" });

            routes.MapHttpRoute(name: "aboutDeleteProductIdWIse", routeTemplate: "api/{Controller}/{action}",
defaults: new { Controller = "Product", action = "DeleteProductIdWise" });

            routes.MapHttpRoute(name: "aboutInsertToProducts", routeTemplate: "api/{Controller}/{action}",
defaults: new { Controller = "Product", action = "AddToProductCollection" });

            routes.MapHttpRoute(name: "aboutEditToProducts", routeTemplate: "api/{Controller}/{action}",
defaults: new { Controller = "Product", action = "EditToProductDetails" });
        }
    }
}
