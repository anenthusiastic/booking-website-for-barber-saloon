using System;
using System.Collections.Generic;
namespace entity
{
    public class Booking
    {
        public int id { get; set; }
        public string CustomerId { get; set; }
        public DateTime date { get; set; }
        public string EmployeeId { get; set; }
        public DateTime creatingDate { get; set; }
        public double totalPrice { get; set; }
        public List<BookingService> BookingServices { get; set; }
    }
}