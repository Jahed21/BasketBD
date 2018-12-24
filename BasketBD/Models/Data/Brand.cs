using System;
using System.Collections.Generic;

namespace BasketBD.Models.Data
{
    public partial class Brand
    {
        public Brand()
        {
            Items = new HashSet<Items>();
        }

        public string BrandId { get; set; }
        public string Name { get; set; }

        public ICollection<Items> Items { get; set; }
    }
}
