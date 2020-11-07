using System;
using System.Collections.Generic;
using System.Linq;
using data.Abstract;
using entity;
using Microsoft.EntityFrameworkCore;

namespace data.Concrete.EFCore
{
    public class EFCoreBookingRepository : GenericRepository<Booking, BarberContext>, IBookingRepository
    {
        public List<DateTime> GetBusyDays(string employeeId)
        {
            List<DateTime> times = new List<DateTime>();
            var date = createStartDate(DateTime.Now); 
            times.Add(date);
            List<DateTime> workdates;
            using (var context = new BarberContext()){
                workdates = context.Bookings.Where(i=>i.EmployeeId==employeeId ).Select(i=>i.date).ToList();
            }

            for (int i = 0; i < 31; i++)
            {
                
                bool flag =true;
                while(date.Hour>=10 && date.Hour<=21 ){
                    if(!workdates.Contains(date)){
                        flag = false;
                        break;
                    }
                    date = date.AddHours(1);
                }
                if(flag){
                    times.Add(date);
                }
                date = date.AddDays(1);
                date.AddHours(date.Hour*-1);
                date = date.AddMinutes(date.Minute*-1);
                date = date.AddSeconds(date.Second*-1);
                date = date.AddHours(10);
            }
            times.Add(date.AddDays(-1));
            return times;
            /*
            List<DateTime> busyTimes;
            using (var context = new BarberContext()){
                busyTimes = context.Bookings.Where(i=>(i.EmployeeId==employeeId )).Select(i=>i.date).ToList();
            }
            
            foreach (var busyTime in busyTimes)
            {
                WorkTimes.Remove(busyTime);
            }

            return WorkTimes;*/
        }

        private DateTime createStartDate(DateTime moment){
            DateTime startDate = new DateTime();
            if(moment.Hour>=21 && moment.Hour<24){
                startDate = moment.AddDays(1);
                startDate.AddHours(moment.Hour*-1);
                startDate = startDate.AddMinutes(moment.Minute*-1);
                startDate = startDate.AddSeconds(moment.Second*-1);
                startDate = startDate.AddHours(10);
            }
            else if(moment.Hour>=0 &&moment.Hour<=9){
                startDate = moment;
                startDate = startDate.AddHours(moment.Hour*-1);
                startDate = startDate.AddMinutes(moment.Minute*-1);
                startDate = startDate.AddSeconds(moment.Second*-1);
                startDate = startDate.AddHours(10);
            }
            else{
                startDate = moment;
                startDate = startDate.AddMinutes(moment.Minute*-1);
                startDate = startDate.AddSeconds(moment.Second*-1);
                startDate = startDate.AddHours(1);
            }
            return startDate;
        }

        public List<DateTime> GetBusyTimes(string employeeId,DateTime selectedDay)
        {
            List<DateTime> busyTimes;
            using (var context = new BarberContext()){
                busyTimes = context.Bookings.Where(i=>(i.EmployeeId==employeeId && i.date.Day==selectedDay.Day && i.date.Month==selectedDay.Month &&i.date.Year ==selectedDay.Year)).Select(i=>i.date).ToList();
            }
            if(selectedDay.Day == DateTime.Now.Day  && selectedDay.Month == DateTime.Now.Month &&selectedDay.Year == DateTime.Now.Year ){
                 busyTimes.Add(createStartDate(DateTime.Now));
            }
            else{
                busyTimes.Add(selectedDay.AddHours(10));
            }
           
            return busyTimes;
        }
        public void Create(Booking entity, int[] serviceIds)
        {
            using (var context = new BarberContext())
            {
                var booking = context.Bookings
                                   .Include(i => i.BookingServices)
                                   .FirstOrDefault(i => (i.EmployeeId == entity.EmployeeId && i.date == entity.date));

                if (booking != null)
                {
                    booking.BookingServices = serviceIds.Select(servId => new BookingService()
                    {
                        ServiceId = servId,
                        BookingId = booking.id
                    }).ToList();

                    context.SaveChanges();
                }
            }
        }

        public List<Booking> GetCustomerOldBookings(string customerId)
        { 
            using (var context = new BarberContext()){
                return context.Bookings.Where(i=>i.CustomerId==customerId && i.date.CompareTo(DateTime.Now)==-1).ToList();
            }
            
        }
        public List<Booking> GetCustomerFutureBookings(string customerId)
        { 
            using (var context = new BarberContext()){
                return context.Bookings.Where(i=>i.CustomerId==customerId && i.date.CompareTo(DateTime.Now)==1).ToList();
            }
            
        }

        public List<Booking> GetEmployeeOldBookings(string employeeId)
        { 
            using (var context = new BarberContext()){
                return context.Bookings.Where(i=>i.EmployeeId==employeeId &&i.date.CompareTo(DateTime.Now)==-1).ToList();
            }
            
        }
        public List<Booking> GetEmployeeFutureBookings(string employeeId)
        { 
            using (var context = new BarberContext()){
                return context.Bookings.Where(i=>i.EmployeeId==employeeId &&i.date.CompareTo(DateTime.Now)==1).ToList();
            }
            
        }

        public List<Booking> GetOldBookings()
        { 
            using (var context = new BarberContext()){
                return context.Bookings.Where(i=>i.date.CompareTo(DateTime.Now)==-1).ToList();
            }
            
        }
        public List<Booking> GetFutureBookings()
        { 
            using (var context = new BarberContext()){
                return context.Bookings.Where(i=>i.date.CompareTo(DateTime.Now)==1).ToList();
            }
            
        }


        public List<string> GetServiceNames(int bookingId)
        {
            
            using (var context = new BarberContext()){
                var booking =  context.Bookings.Where(i=>i.id==bookingId).Include(i=>i.BookingServices).ThenInclude(i=>i.service).FirstOrDefault();
                return (booking.BookingServices.Select(i=>i.service.name).ToList());                      
            }
        }
    }
}