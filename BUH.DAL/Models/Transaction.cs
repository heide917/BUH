using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUH.DAL.Models
{
   public class Transaction
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Order { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public DateTime CreationDate { get; set; }
        
        public ICollection<SubTransaction> SubTransactions { get; set; }
    }
}

