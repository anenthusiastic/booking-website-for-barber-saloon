using System.Collections.Generic;

namespace entity
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}