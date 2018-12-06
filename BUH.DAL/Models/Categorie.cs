using System.Collections.Generic;

namespace BUH.DAL.Models
{
    public class Categorie
    {
        public int Id { get; set; }

        public virtual Class Class { get; set; }

        public int ClassId { get; set; }

        public string Number { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
