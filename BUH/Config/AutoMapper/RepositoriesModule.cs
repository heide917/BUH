using BUH.DAL.Repositories;
using BUH.Domain.Repositories;
using Ninject.Modules;

namespace BUH.Config.AutoMapper
{
    public class RepositoriesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategorieRepository>().To<CategorieRepository>();
            Bind<IAccountRepository>().To<AccountRepository>();
            Bind<IClassRepository>().To<ClassRepository>();
            Bind<ITransactionRepository>().To<TransactionRepository>();
            Bind<IJournalRepository>().To<JournalRepository>();
            Bind<ISourceRepository>().To<SourceRepository>();
        }
    }
}
