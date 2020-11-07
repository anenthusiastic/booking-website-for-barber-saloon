using System;
using System.Collections.Generic;

namespace ui.Models
{
    public class BookingListModel
    {
        public string CustomerName { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime CreatingDate { get; set; }
        public string EmployeeName { get; set; }
        public List<string> serviceNames { get; set; }
        public double TotalPrice { get; set; }
    }
}