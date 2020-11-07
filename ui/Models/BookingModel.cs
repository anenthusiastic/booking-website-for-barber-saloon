using System.Collections.Generic;
using System;
using ui.Identity;
using entity;
using System.ComponentModel.DataAnnotations;

namespace ui.Models
{
    public class BookingModel
    {
        public string CustomerId { get; set; }
        public string EmployeeId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string[] BusyDays { get; set; }
        public string SelectedDay { get; set; }
        public string StartTime { get; set; }
        public List<List<string>> BusyTimes{ get; set; }
        public string SelectedTime { get; set; }
        public List<Service> Services { get; set; }


    }
}