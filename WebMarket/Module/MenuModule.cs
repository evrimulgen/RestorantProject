using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.Security;
using Nancy.Authentication.Forms;

namespace WebMarket.Module
{
    public class MenuModule : NancyModule
    {
        public MenuModule()
        {
            //this.RequiresAuthentication();
            Get["/"] = _ =>
            {
                //var model = new { user = Context.CurrentUser.UserName};
                var model = new { user = "", table = ""};
                return View["Categority/AddCategority", model];
            };
           
            Get["/GridTables"] = _ =>
            {
                // var model = new { user = "Mozo:" + Context.CurrentUser.UserName, table = "" };
                var model = new { user = "Mozo:", table = "" };
                return View["GridTables", model];
            };
            Get["/GridMenu/{Number}"] = parameters =>
            {
                string d = parameters.Number;
                var model = new { user = Context.CurrentUser.UserName, table = d, IsTable = true };
                return View["GridMenu", model];
            };
            Get["/Monitor"] = _ =>
            {
                // var model = new { user = "Mozo:" + Context.CurrentUser.UserName, table = "" };
                var model = new { user = "Mozo:", table = "" };
                return View["Home/Monitor", model];
            };
        }
    }
}