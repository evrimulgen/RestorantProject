using Microsoft.Practices.Unity;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace WebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("Bugs", "api/{Controller}");
            app.UseWebApi(config);
            UnityConfig.Register(config);

            app.UseNancy();
        }
       
    }
}