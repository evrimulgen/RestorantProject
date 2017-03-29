using Microsoft.Practices.Unity;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Unity.WebApi;
using System.Linq;
using Repository;


namespace WebApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IProductRepository, Repository>(new HierarchicalLifetimeManager());
            
           // GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IProductRepository, Repository>(new HierarchicalLifetimeManager());
            
            config.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}