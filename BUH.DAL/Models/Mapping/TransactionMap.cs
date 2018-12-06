using System.Data.Entity.ModelConfiguration;

namespace BUH.DAL.Models.Mapping
{ 
    public class TransactionMap : EntityTypeConfiguration<Transaction>
    {
	    public TransactionMap() 
	    {
            this.HasKey(x => x.Id);
            this.Property(x => x.Name).IsRequired().HasMaxLength(250);
            this.Property(x => x.Order).IsRequired().HasMaxLength(10);
            this.HasRequired(x => x.User)
                .WithMany(y => y.Transactions)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
