using Autofac;
using System;

namespace LazyLoad.IoC
{
    public sealed class IoCFactory
    {
        private static readonly Lazy<IoCFactory> _instancia = new Lazy<IoCFactory>(() => new IoCFactory());
        private IoCAutofacContainer _currentContainer;
        private IoCFactory()
        {
            _currentContainer = new IoCAutofacContainer();
        }
        public IAppContainer CurrentContainer
        {
            get{ return _currentContainer;}
        }

        public static IoCFactory Instance
        {
            get { return _instancia.Value; }
        }
    }
}
