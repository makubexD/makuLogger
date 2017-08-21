using System.Web.Http;
using Maku.Logger.Repository.Commad;
using Maku.Logger.Services.Command;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Maku.Logger.Repository.Interfaces.Commad;
using Maku.Logger.Services.Interfaces.Command;

namespace Maku.Logger.Application.Services.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //// Web API configuration and services
            //// configure the json to use camelCase names
            //var settings = config.Formatters.JsonFormatter.SerializerSettings;
            //settings.Formatting = Formatting.Indented;
            //settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            ////configure Serializer
            //var json = config.Formatters.JsonFormatter;
            //json.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            //UnityConfig.RegisterComponents();

            var container = new UnityContainer();
            container.RegisterType<ILoggerServiceCommand, LoggerServiceCommand>();
            container.RegisterType<ILoggerRepositoryCommand, LoggerRepositoryCommand>();

            config.DependencyResolver = new UnityResolver(container);


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
