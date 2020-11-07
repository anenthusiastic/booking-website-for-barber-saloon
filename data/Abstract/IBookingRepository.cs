using System;
using System.Collections.Generic;
using entity;

namespace data.Abstract
{
    public interface IBookingRepository : IRepository<Booking>
    {
        List<DateTime> GetBusyDays(string employeeId);
        List<DateTime> GetBusyTimes(string employeeId,DateTime selectedDay);
        void Create(Booking entity, int[] serviceIds);
        List<Booking> GetCustomerOldBookings(string customerId);
        List<Booking> GetEmployeeOldBookings(string employeeId);
        List<Booking> GetCustomerFutureBookings(string customerId);
        List<Booking> GetEmployeeFutureBookings(string employeeId);
        List<string> GetServiceNames(int bookingId);
        List<Booking> GetOldBookings();
        List<Booking> GetFutureBookings();
    }
}