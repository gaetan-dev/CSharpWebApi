using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Syntax;

namespace WebApiStarter.Commons.InjectionDependency
{
    // Provides a Ninject implementation of IDependencyScope
    // which resolves services using the Ninject container.
    public class NinjectDependencyScope : IDependencyScope
    {
        protected IResolutionRoot Resolver;

        public NinjectDependencyScope(IResolutionRoot resolver)
        {
            Resolver = resolver;
        }

        public object GetService(Type serviceType)
        {
            if (Resolver == null)
                throw new ObjectDisposedException("this", "This scope has been disposed");

            return Resolver.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (Resolver == null)
                throw new ObjectDisposedException("this", "This scope has been disposed");

            return Resolver.GetAll(serviceType);
        }

        public void Dispose()
        {
            IDisposable disposable = Resolver as IDisposable;
            if (disposable != null)
                disposable.Dispose();

            Resolver = null;
        }
    }
}