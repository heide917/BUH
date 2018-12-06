using System.Data.Entity.ModelConfiguration;

namespace BUH.DAL.Models.Mapping
{
    public class CategorieMap : EntityTypeConfiguration<Categorie>
    {
        public CategorieMap()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Number).IsRequired().HasMaxLength(5);
            this.Property(x => x.Name).IsRequired().HasMaxLength(150);
            this.Property(x => x.Description).HasMaxLength(250);
            this.HasRequired(x => x.Class)
                .WithMany(y => y.Categories)
                .HasForeignKey(x => x.ClassId)
                .WillCascadeOnDelete(false);
        }
    }
}
