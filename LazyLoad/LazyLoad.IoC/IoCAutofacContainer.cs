using Autofac;
using Autofac.Integration.WebApi;
using LazyLoad.IoC.Configurations;
using System;
using System.Reflection;
using System.Web.Http.Dependencies;

namespace LazyLoad.IoC
{
    public sealed class IoCAutofacContainer:IAppContainer
    {

        private ContainerBuilder _builder;
        private IContainer _container;

        public IoCAutofacContainer()
        {
            _builder = new ContainerBuilder();
            ConfigureCurrentContainer();
        }

        private void ConfigureCurrentContainer()
        {
            RepositoryConfiguration.Configure(_builder);
            AplicationServicesConfiguration.Configure(_builder);
            DomainConfiguration.Configure(_builder);
        }

        #region IAppContainer Members
        public TService Resolve<TService>()
        {
            return _container.Resolve<TService>();
        }

        public bool TryResolve<TService>(out TService instance, out Exception reason)
        {
            reason = null;
            try
            {
                return _container.TryResolve(out instance);
            }
            catch (Exception ex)
            {
                reason = ex;
                instance = default(TService);
                return false;
            }
        }

        public void Build()
        {
            _container = _builder.Build();
        }

        public IDependencyResolver WebApiDependencyResolver(Assembly webApi)
        {
            _builder.RegisterApiControllers(webApi);
            Build();
            return new AutofacWebApiDependencyResolver(_container);
        }

        #endregion IAppContainer Members
    }
}
