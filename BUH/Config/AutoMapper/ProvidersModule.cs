using BUH.Domain.Providers.Abstraction;
using BUH.Domain.Providers.Concrete;
using Ninject.Modules;

namespace BUH.Config.AutoMapper
{
    public class ProvidersModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IConfigProvider>().To<ConfigProvider>();
        }
    }
}
