using Maku.Logger.Repository.Commad;
using Maku.Logger.Repository.Interfaces.Commad;
using Maku.Logger.Services.Command;
using Maku.Logger.Services.Interfaces.Command;
using Microsoft.Practices.Unity;

namespace Maku.Logger.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.RegisterType<ILoggerServiceCommand, LoggerServiceCommand>(new HierarchicalLifetimeManager());
            container.RegisterType<ILoggerRepositoryCommand, LoggerRepositoryCommand>();
            
            var loggerSample = container.Resolve<ILoggerServiceCommand>();

            loggerSample.Warning("demo warning", "maku");
            System.Console.ReadLine();
        }
    }
}
