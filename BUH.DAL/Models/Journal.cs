using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUH.DAL.Models
{
    public class Journal
    {
        public int Id { get; set; }

        public DateTime Date { get; set; } 

        public string DocNumber { get; set; }

        public string DocName { get; set; }

        public string Debet { get; set; }

        public string Kredit { get; set; }

        public string Order { get; set; }
        
        public decimal OperationSum { get; set; }

        public decimal ControlSum { get; set; }

        public decimal NDSSum { get; set; }

        public string Lot { get; set; }

        public int PersonId { get; set; }

        public virtual Person Person { get; set; }

        public int ProviderId { get; set; }

        public virtual Provider Provider { get; set; }

        public int InventoryId { get; set; }

        public virtual Inventory Inventory { get; set; }

        public int SourceId { get; set; }

        public virtual Source Source { get; set; }
                
    }
}
