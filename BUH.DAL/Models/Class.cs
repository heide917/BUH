using System.Collections.Generic;

namespace BUH.DAL.Models
{
    public class Class
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Categorie> Categories { get; set; }
    }
}
