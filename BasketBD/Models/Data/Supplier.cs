using System;
using System.Collections.Generic;

namespace BasketBD.Models.Data
{
    public partial class Supplier
    {
        public Supplier()
        {
            Items = new HashSet<Items>();
        }

        public string SupplierId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? Mobile { get; set; }

        public ICollection<Items> Items { get; set; }
    }
}
