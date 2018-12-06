using System.Data.Entity.ModelConfiguration;

namespace BUH.DAL.Models.Mapping
{
    public class JournalMap : EntityTypeConfiguration<Journal>
    {
        public JournalMap()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.DocNumber).IsRequired().HasMaxLength(5);
            this.Property(x => x.DocName).IsRequired().HasMaxLength(250);
            this.Property(x => x.Debet).HasMaxLength(10);
            this.Property(x => x.Kredit).HasMaxLength(10);
            this.Property(x => x.Order).HasMaxLength(10);
            this.Property(x => x.Lot).HasMaxLength(50);
            this.Property(x => x.Date).IsRequired();
            this.Property(x => x.OperationSum).IsRequired();
            this.Property(x => x.ControlSum).IsRequired();
            this.Property(x => x.NDSSum).IsRequired();

            this.HasRequired(x => x.Person)
                .WithMany(y => y.Journals)
                .HasForeignKey(x => x.PersonId)
                .WillCascadeOnDelete(false);
                
            this.HasRequired(x => x.Provider)
                .WithMany(y => y.Journals)
                .HasForeignKey(x => x.ProviderId)
                .WillCascadeOnDelete(false);

            this.HasRequired(x => x.Inventory)
                .WithMany(y => y.Journals)
                .HasForeignKey(x => x.InventoryId)
                .WillCascadeOnDelete(false);
               
            this.HasRequired(x => x.Source)
                .WithMany(y => y.Journals)
                .HasForeignKey(x => x.SourceId)
                .WillCascadeOnDelete(false);


         /*     
        public DateTime Date { get; set; }
        public decimal OperationSum { get; set; }
        public decimal ControlSum { get; set; }
        public decimal NDSSum { get; set; }
        public int PersonId { get; set; }

        public int ProviderId { get; set; }
        public int InventoryId { get; set; }
        public int SourceId { get; set; }

        public virtual Person Person { get; set; }

        public virtual Provider Provider { get; set; }

        public virtual Inventory Inventory { get; set; }

        public virtual Source Source { get; set; }
                
             */
        }
    }
}