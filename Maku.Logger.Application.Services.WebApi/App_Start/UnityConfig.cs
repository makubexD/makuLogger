using Maku.Logger.Services.Command;
using Maku.Logger.Services.Interfaces.Command;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace Maku.Logger.Application.Services.WebApi
{
    public static class UnityConfig
    {
        public static IUnityContainer RegisterComponents()
        {
            var container = new UnityContainer();
            container.AddNewExtension<Interception>();

            container.RegisterType<ILoggerServiceCommand, LoggerServiceCommand>(new HierarchicalLifetimeManager());
            //container.RegisterType<ILoggerServiceCommand, LoggerServiceCommand>();

            
            //container.RegisterTypes();

            return container;
        }
    }
}