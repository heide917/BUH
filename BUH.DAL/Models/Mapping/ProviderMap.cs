using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUH.DAL.Models.Mapping
{
    public class ProviderMap : EntityTypeConfiguration<Provider>
    {
        public ProviderMap()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Type).IsRequired();
            this.Property(x => x.Bank).IsRequired().HasMaxLength(100);
            this.Property(x => x.Certificate).IsRequired().HasMaxLength(100);
            this.Property(x => x.FullName).IsRequired().HasMaxLength(250);
            this.Property(x => x.OKPO).IsRequired().HasMaxLength(100);
            this.Property(x => x.Title).IsRequired().HasMaxLength(100);
            this.HasRequired(x => x.Account)
                .WithMany(y => y.Providers)
                .HasForeignKey(x => x.AccountId)
                .WillCascadeOnDelete(false);
        }
    }
}
