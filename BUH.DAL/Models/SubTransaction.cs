using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUH.DAL.Models
{
   public class SubTransaction
    {
        public int Id { get; set; }

        public int DebetId { get; set; }

        public virtual Account Debet { get; set; } 

        public int KreditId { get; set; }

        public virtual Account Kredit { get; set; }

        public string Name { get; set; }

        public int OrderNumber { get; set; }  //порядковый номер транзакции

        public int TransactionId { get; set; }

        public virtual Transaction Transaction { get; set; }

        public int InventoryId { get; set; }

        public virtual Inventory Inventory { get; set; }
    }
}
