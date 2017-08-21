using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;

namespace Maku.Logger.Console
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        private bool _isDisposed;

        private readonly IUnityContainer _container;

        public UnityDependencyResolver(IUnityContainer container)
        {
            Contract.Requires<ArgumentNullException>(container != null);
            _container = container;
        }

        public IDependencyScope BeginScope()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }

            var child = _container.CreateChildContainer();
            return new UnityDependencyResolver(child);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }

            if (disposing)
            {
                _container.Dispose();
            }
            
            _isDisposed = true;
        }
    }
}
