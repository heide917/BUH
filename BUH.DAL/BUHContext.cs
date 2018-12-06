using BUH.DAL.Models;
using BUH.DAL.Models.Mapping;
using System.Data.Entity;

namespace BUH.DAL
{
    public class BUHContext : DbContext
    {
        public BUHContext()
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
        }

        public BUHContext(string connectionStr)
            : base(connectionStr)
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Categorie> Categories { get; set; }

        public DbSet<Class> Classes { get; set; }

        public DbSet<Contract> Contracts { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<Journal> Journals { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<Provider> Providers { get; set; }

        public DbSet<Source> Sources { get; set; }

        public DbSet<SubTransaction> SubTransactions { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AccountMap());
            modelBuilder.Configurations.Add(new CategorieMap());
            modelBuilder.Configurations.Add(new ClassMap());
            modelBuilder.Configurations.Add(new ContractMap());
            modelBuilder.Configurations.Add(new InventoryMap());
            modelBuilder.Configurations.Add(new JournalMap());
            modelBuilder.Configurations.Add(new PersonMap());
            modelBuilder.Configurations.Add(new ProviderMap());
            modelBuilder.Configurations.Add(new SourceMap());
            modelBuilder.Configurations.Add(new SubTransactionMap());
            modelBuilder.Configurations.Add(new TransactionMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
