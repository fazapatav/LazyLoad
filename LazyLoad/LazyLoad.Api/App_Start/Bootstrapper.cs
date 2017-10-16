using LazyLoad.IoC;
using System.Reflection;
using System.Web.Http;

namespace LazyLoad.Api.App_Start
{
    public static class Bootstrapper
    {
        private static IAppContainer container;

        public static void Run()
        {
            SetAutofacContainer();
        }
        private static void SetAutofacContainer()
        {
            HttpConfiguration configuration = GlobalConfiguration.Configuration;
            container = IoCFactory.Instance.CurrentContainer;
            configuration.DependencyResolver = container.WebApiDependencyResolver(Assembly.GetExecutingAssembly());
        }
    }
}