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
    public class ProductModule : NancyModule
    {
        public ProductModule()
        {
            Get["/AddProduct"] = _ =>
            {
                var model = new { user = "", table = "" };
                return View["Product/AddProduct", model];
            };
            Get["/ListProduct"] = _ =>
            {
                var model = new { user = "", table = "" };
                return View["Product/ListProduct", model];
            };
            Get["/EditProduct/{Categority}/{Id}"] = parameters =>
            {
                var c = parameters.Categority;
                var i = parameters.Id;

                var model = new { Name = c, Category = i };
                return View["Product/EditProduct", model];
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