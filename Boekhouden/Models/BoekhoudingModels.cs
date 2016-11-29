using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boekhouden.Models
{
    public class Boekhouding
    {
        public Guid Id { get; set; }

    }

    public class Factuur
    {
        public Guid BoekhoudingId { get; set; }
        public Guid Id { get; set; }
        public ICollection<FactuurRow> Rows { get; set; }
    }

    public class FactuurRow
    {
        public Guid FactuurId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public double TotalPrice { get; set; }
        public double Tax { get; set; }
    }

}