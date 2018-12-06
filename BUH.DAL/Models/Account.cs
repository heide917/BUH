using System.Collections.Generic;

namespace BUH.DAL.Models
{
    public class Account
    {
        public int Id { get; set; }

        public virtual Categorie Categorie { get; set; }

        public int CategorieId { get; set; }

        public string Number { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<SubTransaction> SubTransactionsDebet { get; set; }

        public ICollection<SubTransaction> SubTransactionsKredit { get; set; }

        public ICollection<Inventory> Inventories { get; set; }

        public ICollection<Provider> Providers { get; set; }
    }
}
