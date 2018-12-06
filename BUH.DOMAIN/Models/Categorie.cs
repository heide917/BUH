using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUH.Domain.Models
{
    public class Categorie
    {
        public int Id { get; set; }

        public int ClassId { get; set; }

        public string Number { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
