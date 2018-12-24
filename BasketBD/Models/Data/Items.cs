using System;
using System.Collections.Generic;

namespace BasketBD.Models.Data
{
    public partial class Items
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string SupplierId { get; set; }
        public string BrandId { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? SalePrice { get; set; }
        public DateTime? EexpireDate { get; set; }
        public string SlideTitle { get; set; }
        public string NewArrivalTitle { get; set; }
        public string Picture { get; set; }

        public Brand Brand { get; set; }
        public Category CategoryNavigation { get; set; }
        public Supplier Supplier { get; set; }
    }
}
