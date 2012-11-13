using System.Web.Routing;
using AttributeRouting.Web.Mvc;
using CloakedRobot.Web.Infrastructure;

[assembly: WebActivator.PreApplicationStartMethod(typeof(CloakedRobot.Web.App_Start.AttributeRouting), "Start")]

namespace CloakedRobot.Web.App_Start {
    public static class AttributeRouting {
		public static void RegisterRoutes(RouteCollection routes) {
            
			// See http://github.com/mccalltd/AttributeRouting/wiki for more options.
			// To debug routes locally using the built in ASP.NET development server, go to /routes.axd
            
			routes.MapAttributeRoutes(cfg =>
			                              {
			                                  cfg.UseLowercaseRoutes = true;
                                              cfg.AddRoutesFromAssemblyOf<BlogController>();
			                              });
		}

        public static void Start() {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
