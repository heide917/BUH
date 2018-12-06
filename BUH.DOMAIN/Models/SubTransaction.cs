using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUH.Domain.Models
{
    public class SubTransaction
    {
        public int Id { get; set; }

        public int DebetId { get; set; }

        public int KreditId { get; set; }

        public string Name { get; set; }

        public int OrderNumber { get; set; } 

        public int TransactionId { get; set; }

        public int InventoryId { get; set; }
    }
}
