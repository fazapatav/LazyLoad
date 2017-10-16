using Autofac;
using LazyLoad.Aplication.Services.Casos;

namespace LazyLoad.IoC.Configurations
{
    public class AplicationServicesConfiguration
    {
        public static void Configure(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(CasosServices)).As(typeof(ICasosServices)).InstancePerDependency();
        }
    }
}
