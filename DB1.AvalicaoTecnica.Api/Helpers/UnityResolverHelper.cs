using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace DB1.AvalicaoTecnica.Api.Helpers
{
    public class UnityResolverHelper : IDependencyResolver
    {
        protected IUnityContainer container;

        public UnityResolverHelper(IUnityContainer container)
        {
            if(container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new UnityResolverHelper(child);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch(ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch(ResolutionFailedException)
            {
                return null;
            }
        }

        public void Dispose()
        {
            container.Dispose();
        }
    }
}