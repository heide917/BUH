using System.Data.Entity.ModelConfiguration;

namespace BUH.DAL.Models.Mapping
{
    public class ClassMap : EntityTypeConfiguration<Class>
    {
        public ClassMap()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Number).IsRequired().HasMaxLength(5);
            this.Property(x => x.Name).IsRequired().HasMaxLength(100);
            this.Property(x => x.Description).HasMaxLength(250);
        }
    }
}