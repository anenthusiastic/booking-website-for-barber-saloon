using System.Collections.Generic;

namespace entity
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public string imageUrl { get; set; }
        public bool isApproved { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }

    }
}