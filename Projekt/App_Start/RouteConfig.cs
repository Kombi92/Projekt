using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Projekt
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("DodajUcznia", "DodajUcznia", new
            {
                controller = "Uczen",
                action = "Create"
            });

            routes.MapRoute("EdycjaUcznia", "EdycjaUcznia", new
            {
                controller = "Uczen",
                action = "Edit"
            });

            routes.MapRoute("DodajLekcje", "DodajLekcje", new
            {
                controller = "Lekcja",
                action = "Create"
            });

            routes.MapRoute("EdytujLekcje", "EdytujLekcje", new
            {
                controller = "Lekcja",
                action = "Edit"
            });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
