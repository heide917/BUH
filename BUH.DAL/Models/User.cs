using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using BUH.DAL.Models;

namespace BUH.DAL.Models
{
    public class User : EntityTypeConfiguration<User>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}