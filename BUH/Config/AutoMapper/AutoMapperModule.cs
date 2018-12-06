using AutoMapper;
using BUH.Config.AutoMapper.Profiles;
using Ninject.Modules;

namespace BUH.Config.AutoMapper
{
    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            var mapperConfiguration = this.CreateConfiguration();
            Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();
            Bind<IMapper>().ToMethod(ctx => new Mapper(mapperConfiguration, type => ctx.Kernel.GetService(type)));
        }

        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AccountProfile>();
                cfg.AddProfile<CategorieProfile>();
                cfg.AddProfile<ClassProfile>();
                cfg.AddProfile<ContractProfile>();
                cfg.AddProfile<InventoryProfile>();
                cfg.AddProfile<JournalProfile>();
                cfg.AddProfile<PersonProfile>();
                cfg.AddProfile<ProviderProfile>();
                cfg.AddProfile<SourceProfile>();
                cfg.AddProfile<SubTransactionProfile>();
                cfg.AddProfile<TransactionProfile>();
                cfg.AddProfile<UserProfile>();
            });

            config.AssertConfigurationIsValid();
            return config;
        }
    }
}
