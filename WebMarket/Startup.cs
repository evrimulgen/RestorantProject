using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebMarket.Unity;

namespace WebMarket
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("Products", "api/{Controller}/{id}");
            app.UseWebApi(config);
            UnityConfig.Register(config);


            app.UseNancy();
        }
    }
}