using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUH.Domain.Models
{
    public class Account
    {
        public int Id { get; set; }

        public int CategorieId { get; set; }

        public string CategorieName { get; set; }

        public string ClassName { get; set; }

        public string Number { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
