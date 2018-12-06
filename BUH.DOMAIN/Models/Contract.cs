using System;

namespace BUH.Domain.Models
{ 
    public class Contract
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string Object { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public int ProviderId { get; set; }
    }
}
