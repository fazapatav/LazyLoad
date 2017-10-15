using Autofac;

namespace LazyLoad.IoC.Configurations
{
    public class RepositoryConfiguration
    {
        public static void Configure(ContainerBuilder builder)
        {
            //builder.RegisterType(typeof(CasosServices)).As(typeof(ICasosServices)).InstancePerDependency();
        }
    }
}
