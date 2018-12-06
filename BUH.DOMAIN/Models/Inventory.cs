using System;

namespace BUH.Domain.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        public string Account { get; set; }

        public string Number { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Manufacturer { get; set; }

        public int Series { get; set; }

        public string Unit { get; set; }

        public decimal? Cost { get; set; }

        public decimal Amortization { get; set; }

        public DateTime ComingDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int ProviderId { get; set; }

        public int PersonId { get; set; }
    }
}