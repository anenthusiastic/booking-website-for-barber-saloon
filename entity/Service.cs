using System.Collections.Generic;

namespace entity
{
    public class Service
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public int time { get; set; }
        public string imageUrl { get; set; }
        public List<BookingService> BookingService { get; set; }
    }
}