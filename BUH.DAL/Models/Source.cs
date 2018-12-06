using System;
using System.Collections.Generic;
using BUH.DAL.Models;

namespace BUH.DAL.Models
{
    public class Source
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Journal> Journals { get; set; }
    }
}
