using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUH.Domain.Models
{
    public class Provider
    {
        public int Id { get; set; }

        public int Type { get; set; }

        public string OKPO { get; set; }

        public string Title { get; set; }

        public string Certificate { get; set; }

        public string FullName { get; set; }

        public string Bank { get; set; }

        public int AccountId { get; set; }
    }
}
