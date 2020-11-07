using System;
using System.Collections.Generic;
namespace ui.Models
{
    public class BookingInfoModel
    {
        public string CustomerId { get; set; } 
        public string EmployeeId { get; set; }
        public string barberName { get; set; }
        public string barberImageUrl { get; set; }
        public int[] ServiceIds { get; set; }
        public List<string> serviceNames { get; set; }
        public List<double> servicePrices { get; set; }
        public DateTime date { get; set; }
        public double TotalPrice { get; set; }
    }
}