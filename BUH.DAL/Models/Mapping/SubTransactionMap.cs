using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUH.DAL.Models.Mapping
{
    public class SubTransactionMap : EntityTypeConfiguration<SubTransaction>
    {
        public SubTransactionMap()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Name).IsRequired().HasMaxLength(250);
            this.Property(x => x.OrderNumber).IsRequired();
            this.HasRequired(x => x.Debet)
                .WithMany(y => y.SubTransactionsDebet)
                .HasForeignKey(x => x.DebetId)
                .WillCascadeOnDelete(false);
            this.HasRequired(x => x.Kredit)
                .WithMany(y => y.SubTransactionsKredit)
                .HasForeignKey(x => x.KreditId)
                .WillCascadeOnDelete(false);
            this.HasRequired(x => x.Transaction)
                .WithMany(y => y.SubTransactions)
                .HasForeignKey(x => x.TransactionId)
                .WillCascadeOnDelete(false);
            this.HasRequired(x => x.Inventory)
                .WithMany(y => y.SubTransactions)
                .HasForeignKey(x => x.InventoryId)
                .WillCascadeOnDelete(false);
        }
    }
}
