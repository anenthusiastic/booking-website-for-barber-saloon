using System;
using System.Collections.Generic;
using entity;

namespace business.Abstract
{
    public interface IBookingService
    {
        Booking GetById(int id);
        List<Booking> GetAll();
        void Create(Booking entity);
        bool CreateBooking(Booking entity);
        void Update(Booking entity);
        void Delete(Booking entity);
        List<DateTime> GetBusyDays(string employeeId);
        List<DateTime> GetBusyTimes(string employeeId,DateTime selectedDay);
        void Create(Booking entity, int[] serviceIds);
        List<Booking> GetCustomerOldBookings(string customerId);
        List<Booking> GetEmployeeOldBookings(string employeeId);
        List<Booking> GetCustomerFutureBookings(string customerId);
        List<Booking> GetEmployeeFutureBookings(string employeeId);
        List<Booking> GetOldBookings();
        List<Booking> GetFutureBookings();
        List<string> GetServiceNames(int bookingId);
    }
}