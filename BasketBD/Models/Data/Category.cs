using System;
using System.Collections.Generic;

namespace BasketBD.Models.Data
{
    public partial class Category
    {
        public Category()
        {
            Items = new HashSet<Items>();
        }

        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string SubCategory { get; set; }
        public string Description { get; set; }
        public int? SerialNo { get; set; }

        public ICollection<Items> Items { get; set; }
    }
}
