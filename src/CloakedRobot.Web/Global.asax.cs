﻿using CloakedRobot.Common.Tasks;
using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace CloakedRobot.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IDocumentStore RavenStore { get; set; }

        public MvcApplication()
        {
            BeginRequest += (sender, args) =>
            {
                HttpContext.Current.Items["CurrentRequestRavenSession"] = RavenStore.OpenSession();
            };

            EndRequest += (sender, args) =>
            {
                using (var session = (IDocumentSession)HttpContext.Current.Items["CurrentRequestRavenSession"])
                {
                    if (session == null)
                        return;

                    if (Server.GetLastError() != null)
                        return;

                    session.SaveChanges();
                }

                TaskExecutor.StartExecuting();
            };
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

        }

        private void InitializeRavenDb()
        {
            RavenStore = new DocumentStore()
            {
                ConnectionStringName = "RavenDB"
            }.Initialize();
        }

    }
}