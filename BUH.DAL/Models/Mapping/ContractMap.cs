using System.Data.Entity.ModelConfiguration;

namespace BUH.DAL.Models.Mapping
{
    
     public class ContractMap : EntityTypeConfiguration<Contract>
     {
         public ContractMap()
         {
             this.HasKey(x => x.Id);
             this.Property(x => x.Number).IsRequired().HasMaxLength(5);
             this.Property(x => x.Object).IsRequired().HasMaxLength(250);
             this.Property(x => x.DateStart).IsRequired();
             this.Property(x => x.DateEnd).IsRequired();
             
            this.HasRequired(x => x.Provider)
                 .WithMany(y => y.Contracts)
                 .HasForeignKey(x => x.ProviderId)
                 .WillCascadeOnDelete(false);

   
         }
     }
     
}
