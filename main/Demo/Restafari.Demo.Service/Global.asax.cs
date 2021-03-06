﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Restafari.Demo.Service.Models;
using Restafari.Hal;

namespace Restafari.Demo.Service
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            HalConfig.Register(GlobalConfiguration.Configuration);
            HalConfig.RegisterLinkProvider(() => new ContactLinkProvider());
            HalConfig.RegisterLinkProvider(() => new MeetingLinkProvider());
        }
    }
}