using System.Web.Http;
using Maku.Logger.Repository.Commad;
using Maku.Logger.Services.Command;
using Microsoft.Practices.Unity;
using Maku.Logger.Repository.Interfaces.Commad;
using Maku.Logger.Services.Interfaces.Command;

namespace Maku.Logger.Application.Services.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<ILoggerServiceCommand, LoggerServiceCommand>();
            container.RegisterType<ILoggerRepositoryCommand, LoggerRepositoryCommand>();

            config.DependencyResolver = new UnityResolver(container);
            
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
