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
    public class LetterModule : NancyModule
    {
        public LetterModule()
        {
            Get["/AddLetter"] = _ =>
            {
                return View["Letter/AddLetter"];
            };
            Get["/EditLetter/{letter}"] = parameters =>
            {
                var c = parameters.letter;

                var model = new { Letter = c};
                return View["Letter/EditLetter", model];
            };
            Get["/ListLetter"] = _ =>
            {
                return View["Letter/ListLetter"];
            };
        }

    }
}