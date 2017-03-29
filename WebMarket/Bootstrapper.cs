using Microsoft.Practices.Unity;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Unity;
using Nancy.Conventions;
using Nancy.TinyIoc;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMarket.Models;

namespace WebMarket
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            // We don't call "base" here to prevent auto-discovery of
            // types/dependencies
        }

        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);

            // Here we register our user mapper as a per-request singleton.
            // As this is now per-request we could inject a request scoped
            // database "context" or other request scoped services.
            container.Register<IUserMapper, DatabaseUser>();
            container.Register<IRepository, Repository.Repository>();
        }

        protected override void RequestStartup(TinyIoCContainer requestContainer, IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(requestContainer, pipelines, context);
            // At request startup we modify the request pipelines to
            // include forms authentication - passing in our now request
            // scoped user name mapper.
            //
            // The pipelines passed in here are specific to this request,
            // so we can add/remove/update items in them as we please.
            var formsAuthConfiguration =
                new FormsAuthenticationConfiguration()
                {
                    RedirectUrl = "login",
                    UserMapper = requestContainer.Resolve<IUserMapper>(),
                };

            FormsAuthentication.Enable(pipelines, formsAuthConfiguration);
        }
        protected override void ConfigureConventions(Nancy.Conventions.NancyConventions nancyConventions)
        {
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("Scripts", "Scripts"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("img", "img"));
            base.ConfigureConventions(nancyConventions);
        }
      
    }
}