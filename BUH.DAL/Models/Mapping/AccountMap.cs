using System.Data.Entity.ModelConfiguration;

namespace BUH.DAL.Models.Mapping
{
    public class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Number).IsRequired().HasMaxLength(5);
            this.Property(x => x.Name).IsRequired().HasMaxLength(250);
            this.Property(x => x.Description).HasMaxLength(250);
            this.HasRequired(x => x.Categorie)
                .WithMany(y => y.Accounts)
                .HasForeignKey(x => x.CategorieId)
                .WillCascadeOnDelete(false);
        }
    }
}
