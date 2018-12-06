using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace BUH.DAL.Models.Mapping
{
    public class InventoryMap : EntityTypeConfiguration<Inventory>
    {
        public InventoryMap()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Number).IsRequired().HasMaxLength(5);
            this.Property(x => x.Description).HasMaxLength(250);
            this.Property(x => x.Title).HasMaxLength(250);
            this.Property(x => x.Manufacturer).HasMaxLength(250);
            this.Property(x => x.Series).IsRequired();
            this.Property(x => x.Unit).IsRequired().HasMaxLength(25);
            this.Property(x => x.Cost).IsRequired();
            this.Property(x => x.Amortization).IsRequired();
            this.Property(x => x.ComingDate).IsRequired();
            this.Property(x => x.StartDate).IsRequired();
            this.Property(x => x.EndDate).IsRequired();
            this.HasRequired(x => x.Account)
                .WithMany(y => y.Inventories)
                .HasForeignKey(x => x.AccountId)
                .WillCascadeOnDelete(false);
            this.HasRequired(x => x.Provider)
                .WithMany(y => y.Inventories)
                .HasForeignKey(x => x.ProviderId)
                .WillCascadeOnDelete(false);
            this.HasRequired(x => x.Person)
                .WithMany(y => y.Inventories)
                .HasForeignKey(x => x.PersonId)
                .WillCascadeOnDelete(false);
        }
    }
     
}