using DataModel;
using Nancy;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.Authentication.Forms;
using Nancy.Security;
using Nancy.Extensions;
using WebMarket.Models.Request;

namespace WebMarket.Module
{
    public class CategorityModule : NancyModule
    {
        public CategorityModule()
        {
            Get["/AddCategority"] = _ =>
            {
                var model = new { user = "", table = "" };
                return View["Categority/AddCategority", model];
            };
            Get["/EditCategory/{Categority}/{Id}"] = parameters =>
            {
                var c = parameters.Categority;
                var i = parameters.Id;

                var model = new { Name = c, Letter = i};
                return View["Categority/EditCategority", model];
            };
            Get["/ListCategority"] = _ =>
            {
                var model = new { user = "", table = "" };
                return View["Categority/ListCategority", model];
            };
        }

    }
}