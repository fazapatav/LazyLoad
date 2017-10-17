using Autofac;
using LazyLoad.Domain.DomainServices;
using LazyLoad.Domain.DomainContracts;

namespace LazyLoad.IoC.Configurations
{
    public class DomainConfiguration
    {
        public static void Configure(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(CasoDomain)).As(typeof(ICasoDomain)).InstancePerDependency();
            builder.RegisterType(typeof(EjecucionDomain)).As(typeof(IEjecucionDomain)).InstancePerDependency();
        }
    }
}
