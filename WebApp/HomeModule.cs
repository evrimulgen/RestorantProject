using Nancy;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

namespace WebApp.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ =>
            {
                var model = new { title = "We've Got Issues..." };
                return View["Views/Home", model];
            };
        }
    }
}