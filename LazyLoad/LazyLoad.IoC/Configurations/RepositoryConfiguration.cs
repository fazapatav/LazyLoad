using Autofac;
using LazyLoad.Data.Core.Interfaces;
using LazyLoad.Data.Repositories;
using LazyLoad.Data.UnitOfWork;
using LazyLoad.Domain.RepositoriesContracts;

namespace LazyLoad.IoC.Configurations
{
    public class RepositoryConfiguration
    {
        public static void Configure(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(LazyLoadUnitOfWork)).As(typeof(ILazyLoadUnitOfWork)).InstancePerDependency();
            builder.RegisterType(typeof(CasoRepository)).As(typeof(ICasoRepository));
            builder.RegisterType(typeof(EjecucionRepository)).As(typeof(IEjecucionRepository));
            builder.RegisterType(typeof(EjecutorRepository)).As(typeof(IEjecutorRepository));
            builder.RegisterType(typeof(ElementoRepository)).As(typeof(IElementoRepository));
        }
    }
}
