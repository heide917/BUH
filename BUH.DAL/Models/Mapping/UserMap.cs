using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUH.DAL.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            this.Property(x => x.LastName).IsRequired().HasMaxLength(100);
        }
    }
}
