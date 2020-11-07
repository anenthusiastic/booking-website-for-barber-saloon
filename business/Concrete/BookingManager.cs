using System;
using System.Collections.Generic;
using business.Abstract;
using data.Abstract;
using entity;

namespace business.Concrete
{
    public class BookingManager : IBookingService
    {

        private IBookingRepository  _bookingrepository;
        public BookingManager(IBookingRepository  bookingrepository)
        {
            _bookingrepository = bookingrepository;
        }
        public bool CreateBooking(Booking entity)
        {
            var days = _bookingrepository.GetBusyDays(entity.EmployeeId);
            if(entity.date.CompareTo(days[0])==-1 || entity.date.CompareTo(days[days.Count-1])==1){
                return false;
            }

            var busyhours = _bookingrepository.GetBusyTimes(entity.EmployeeId,entity.date);
            
            for (int i = 0; i < busyhours.Count-1; i++)
            {
                if(busyhours[i].CompareTo(entity.date)==0){
                    return false;
                }
            }

            if(entity.CustomerId==entity.EmployeeId){
                return false;
            }

            _bookingrepository.Create(entity);
            return true;
        }

        public void Delete(Booking entity)
        {
            _bookingrepository.Delete(entity);
        }

        public List<Booking> GetAll()
        {
            return _bookingrepository.GetAll();
        }

        public Booking GetById(int id)
        {
            return _bookingrepository.GetById(id);
        }

        public List<DateTime> GetBusyDays(string employeeId)
        {
           return  _bookingrepository.GetBusyDays(employeeId);
        }

        public void Update(Booking entity)
        {
            _bookingrepository.Update(entity);
        }

        public List<DateTime> GetBusyTimes(string employeeId,DateTime selectedDay)
        {
            return _bookingrepository.GetBusyTimes(employeeId,selectedDay);
        }

        public void Create(Booking entity, int[] serviceIds)
        {
            //control ekle
             _bookingrepository.Create(entity,serviceIds);
        }

        public List<Booking> GetCustomerOldBookings(string customerId)
        {
            return _bookingrepository.GetCustomerOldBookings(customerId);
        }
        public List<Booking> GetEmployeeOldBookings(string employeeId)
        {
            return _bookingrepository.GetEmployeeOldBookings(employeeId);
        }
         public List<Booking> GetCustomerFutureBookings(string customerId)
        {
            return _bookingrepository.GetCustomerFutureBookings(customerId);
        }
        public List<Booking> GetEmployeeFutureBookings(string employeeId)
        {
            return _bookingrepository.GetEmployeeFutureBookings(employeeId);
        }
        
      
         public List<Booking> GetOldBookings()
        { 
            return _bookingrepository.GetOldBookings();
            
        }
        public List<Booking> GetFutureBookings()
        { 
            return _bookingrepository.GetFutureBookings();
            
        }

        public List<string> GetServiceNames(int bookingId)
        {
            return _bookingrepository.GetServiceNames(bookingId);
        }

        public void Create(Booking entity)
        {
            _bookingrepository.Create(entity);
        }

    }
}