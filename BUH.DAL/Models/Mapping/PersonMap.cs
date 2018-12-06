using System.Data.Entity.ModelConfiguration;

namespace BUH.DAL.Models.Mapping
{
    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.FullName).HasMaxLength(250);
            this.Property(x => x.Department).HasMaxLength(150);
        }
    }
}
