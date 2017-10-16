using System;
using System.Reflection;
using System.Web.Http.Dependencies;

namespace LazyLoad.IoC
{
    public interface IAppContainer
    {
        TService Resolve<TService>();
        bool TryResolve<TService>(out TService instance, out Exception reason);
        void Build();
        IDependencyResolver WebApiDependencyResolver(Assembly webApli);
    }
}
