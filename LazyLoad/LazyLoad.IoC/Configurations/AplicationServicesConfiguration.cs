using Autofac;
using LazyLoad.Aplication.Services;

namespace LazyLoad.IoC.Configurations
{
    public class AplicationServicesConfiguration
    {
        public static void Configure(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(CasosServices)).As(typeof(ICasosServices)).InstancePerDependency();
            builder.RegisterType(typeof(EjecucionServices)).As(typeof(IEjecucionServices)).InstancePerDependency();
        }
    }
}
