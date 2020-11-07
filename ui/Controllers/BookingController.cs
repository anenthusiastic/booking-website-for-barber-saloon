using business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ui.Models;
using entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ui.Identity;
using ui.Extensions;
using Newtonsoft.Json;
using System.Globalization;

namespace ui.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private IBookingService _bookingService;
        private IServiceService _serviceService;
        private UserManager<User> _userManager;
        public BookingController(IBookingService bookingService,IServiceService serviceService,UserManager<User> userManager)
        {
            _bookingService =bookingService;
            _userManager= userManager;
            _serviceService = serviceService;
        }
        [Authorize(Roles="Patron,Çalışan")]
        [HttpPost]
        public async Task<IActionResult> SelectCustomer(CustomerList model,string SelectedCustomer){
            if(string.IsNullOrEmpty(SelectedCustomer)){
                TempData.Put("message",new AlertType(){
                        Title = "Hata",
                        Message = "Boş Bırakılamaz!",
                        Alert="warning"
                    }
                );
                return View(model);
            }
            var customer =await _userManager.FindByIdAsync(SelectedCustomer);
            if(customer==null){
                TempData.Put("message",new AlertType(){
                        Title = "Hata",
                        Message = "Boş Bırakılamaz!",
                        Alert="warning"
                    }
                );
                return View(model);
            }

            return Redirect("/booking/create/"+SelectedCustomer);
        }


        public async Task<IActionResult> CreateBooking(string customerId){
            Console.WriteLine(customerId);
            var user = await _userManager.FindByIdAsync(_userManager.GetUserId(User));
            var result1 = await _userManager.IsInRoleAsync(user, "Patron");
            var result2 = await _userManager.IsInRoleAsync(user, "Çalışan");
            var result = (!result1 && !result2);
            if(!string.IsNullOrEmpty(customerId) && result){
                return View("AccessDenied");
            }

            var employees = await _userManager.GetUsersInRoleAsync("Çalışan");
            if(employees.Count()>1){
                var barberIds = new List<string>();
                var barberNames = new List<string>();
                foreach (var employee in employees)
                {
                   barberIds.Add(employee.Id);
                   barberNames.Add(employee.FirstName+" "+employee.LastName);
                }
                BarberModel model2 = new BarberModel(){
                    BarberIds = barberIds,
                    Names = barberNames,
                    CustomerId =customerId
                };
                Console.WriteLine(model2.CustomerId);
                return View("SelectBarber",model2);
            }

            var times  = _bookingService.GetBusyDays(employees[0].Id);
            /*var busytimes = new string[times.Count-1];
            if(times.Count>2){
                for (int i = 0; i < times.Count-2; i++)
                {
                    busytimes[i]=times[i+1].Day+"/"+times[i+1].Month+"/"+times[i+1].Year;
                }
            }
            else{
                busytimes[0]="tdgdeydy ";
            }*/
            
            var model3 = new BookingModel(){
                CustomerId = customerId,
                EmployeeId = employees[0].Id,
                StartDate = times[0].Day+"/"+times[0].Month+"/"+times[0].Year,
                EndDate = times[times.Count-1].Day+"/"+times[times.Count-1].Month+"/"+times[times.Count-1].Year,
                //BusyDays = busytimes
            };
            
            return View("SelectDay",model3);
        }

         [HttpPost]
        public IActionResult CreateBooking(BookingInfoModel model){
             
             if(string.IsNullOrEmpty(model.CustomerId)){
                 model.CustomerId = _userManager.GetUserId(User);
             }
             var booking = new Booking(){
                EmployeeId = model.EmployeeId,
                date = model.date,
                CustomerId = model.CustomerId ,
                creatingDate = DateTime.Now,
                totalPrice = model.TotalPrice
            };

            try
            {
                if(_bookingService.CreateBooking(booking)){
                    _bookingService.Create(booking,model.ServiceIds);
                    TempData.Put("message",new AlertType(){
                            Title = "Rezervasyonunuz başarılı bir şekilde oluşturuldu",
                            Message = "Randevu saatinizde lütfen salonumuzda olun. Olamayacaksanız rezervasyonunuzu iptal etmeyi unutmayın",
                            Alert="success"
                        }
                    );
                }
                else{
                    TempData.Put("message",new AlertType(){
                            Title = "Bir hata oluştu!!",
                            Message = "Rezervasyonunuz oluşturulurken bir hata ile karşılaşıldı.Lütfen tekrar deneyin",
                            Alert="danger"
                        }
                    );

                }
                
                
                
            }
            catch (System.Exception)
            {
                
                TempData.Put("message",new AlertType(){
                        Title = "Veritabanı hatası!",
                        Message = "Rezervasyonunuz oluşturulurken bir hata ile karşılaşıldı.Lütfen tekrar deneyin",
                        Alert="danger"
                    }
                );

            }
            

            return View("Message");
        }

        [HttpPost]
        public async Task<IActionResult> SelectBarber(BarberModel model){
             
            if(string.IsNullOrEmpty(model.SelectedBarber) ){
                TempData.Put("message",new AlertType(){
                    Title = "Hata",
                    Message = "Boş bırakılamaz!",
                    Alert="warning"
                    }
                );
                return View(model);
            }
            var barber = await _userManager.FindByIdAsync(model.SelectedBarber);
            if(barber==null ){
                 TempData.Put("message",new AlertType(){
                    Title = "Hata",
                    Message = "Kuaför seçmeniz gerekiyor!",
                    Alert="warning"
                    }
                );
                return View(model);
            }
             var times  = _bookingService.GetBusyDays(model.SelectedBarber);
             var model2 = new BookingModel(){
                CustomerId = model.CustomerId,
                EmployeeId = model.SelectedBarber,
                StartDate = times[0].Day+"/"+times[0].Month+"/"+times[0].Year,
                EndDate = times[times.Count-1].Day+"/"+times[times.Count-1].Month+"/"+times[times.Count-1].Year,
                
            };
            return View("SelectDay",model2);
        }

        [HttpPost]
        public IActionResult SelectDay(BookingModel model){
            if( string.IsNullOrEmpty(model.SelectedDay) 
                || string.IsNullOrEmpty(model.StartDate) || string.IsNullOrEmpty(model.EndDate)){
                TempData.Put("message",new AlertType(){
                    Title = "Hata",
                    Message = "Boş bırakılamaz!",
                    Alert="warning"
                    }
                );
                return View(model);
            }
            var selectedDay = Convert.ToDateTime(model.SelectedDay);
            var startDate = Convert.ToDateTime(model.StartDate );
            var endDate = Convert.ToDateTime(model.EndDate );
            if(selectedDay.CompareTo(startDate)==-1 || selectedDay.CompareTo(endDate)==1 ){
                TempData.Put("message",new AlertType(){
                    Title = "Hata",
                    Message = "Seçtiğiniz gün sınırlar dışında!",
                    Alert="warning"
                    }
                );
                return View(model);
            }
            
            var busyTimes= _bookingService.GetBusyTimes(model.EmployeeId,selectedDay);
            var stringbusytimes = new List<List<string>>();
            for (int i = 0; i < busyTimes.Count-1; i++)
            {
                stringbusytimes.Add(new List<string>{busyTimes[i].Hour+":00",(busyTimes[i].Hour+1)+":00"});
            }
            model.BusyTimes = stringbusytimes;
            model.StartTime= busyTimes[busyTimes.Count-1].Hour+":00";
           
            return View("SelectTime",model);
        }

        [HttpPost]
        public IActionResult SelectTime(BookingModel model){
             if( string.IsNullOrEmpty(model.SelectedDay) 
                ||string.IsNullOrEmpty(model.SelectedTime) || string.IsNullOrEmpty(model.StartTime)){
                    TempData.Put("message",new AlertType(){
                        Title = "Hata",
                        Message = "Boş bırakılamaz!",
                        Alert="warning"
                        }
                    );
                return View(model);
            }

            if(model.BusyTimes!=null && model.BusyTimes.Any(i=>string.Equals(i[0],model.SelectedTime))){
                 TempData.Put("message",new AlertType(){
                    Title = "Hata",
                    Message = "Seçtiğiniz saat dolu!",
                    Alert="warning"
                    }
                );
                return View(model);
            }
            var selectedDay = Convert.ToDateTime(model.SelectedDay);
            var selectedTime = DateTime.ParseExact(model.SelectedTime, "HH:mm",
                                        CultureInfo.InvariantCulture);
            var startTime = DateTime.ParseExact(model.StartTime, "HH:mm",
                                        CultureInfo.InvariantCulture);
            if(selectedTime.Hour<10 || selectedTime.Hour>21 ||  selectedTime.CompareTo(startTime)==-1){
                TempData.Put("message",new AlertType(){
                    Title = "Hata",
                    Message = "Seçtiğiniz saat çalışma saatlerimiz dışında!",
                    Alert="warning"
                    }
                );
                return View(model);
            }
            model.Services= _serviceService.GetAll();
            return View("SelectServices",model);
           
        }


        [HttpPost]
        public async Task<IActionResult> SelectServices(BookingModel model,int[] serviceIds){
           if(model.EmployeeId==null || string.IsNullOrEmpty(model.SelectedDay) 
                ||string.IsNullOrEmpty(model.SelectedTime)){
                    TempData.Put("message",new AlertType(){
                        Title = "Hata",
                        Message = "Kuaför ve rezervasyon zamanı boş olamaz!",
                        Alert="warning"
                        }
                    );
                return View(model);
            }
            
            if(serviceIds.Length==0){
                TempData.Put("message",new AlertType(){
                        Title = "Hata",
                        Message = "İşlem seçmelisiniz!",
                        Alert="warning"
                        }
                    );
                return View(model);
            }
            var selectedDay = Convert.ToDateTime(model.SelectedDay);
            var selectedTime = DateTime.ParseExact(model.SelectedTime, "HH:mm",
                                        CultureInfo.InvariantCulture);

            var barber = await _userManager.FindByIdAsync(model.EmployeeId);

            var serviceNames = new List<string>();
            var servicePrices = new List<double>();
            foreach (var id in serviceIds)
            {
                var service = _serviceService.GetById(id);
                serviceNames.Add(service.name);
                servicePrices.Add(service.price);
            }
            var bookingInfoModel = new BookingInfoModel(){
                CustomerId = model.CustomerId,
                EmployeeId = model.EmployeeId,
                date = selectedDay.AddHours(selectedTime.Hour).AddMinutes(selectedTime.Minute),
                ServiceIds = serviceIds,
                barberName =barber.FirstName+" "+barber.LastName,
                barberImageUrl = barber.ImageUrl,
                serviceNames = serviceNames,
                servicePrices = servicePrices
            };
            return View("CreateBooking",bookingInfoModel);
        }

        public async Task<IActionResult> BookingHistory(){
            var userId = _userManager.GetUserId(User);
            var history = _bookingService.GetCustomerOldBookings(userId);
            var modelList = new List<BookingListModel>();
            foreach (var booking in history)
            {
                var barber = await _userManager.FindByIdAsync(booking.EmployeeId);
                var name = barber.FirstName +" "+barber.LastName;
                var model = new BookingListModel(){
                    BookingDate = booking.date,
                    CreatingDate = booking.creatingDate,
                    EmployeeName =name,
                    serviceNames = _bookingService.GetServiceNames(booking.id),
                    TotalPrice = booking.totalPrice
                };

                modelList.Add(model);

            }

            return View(modelList);
            
        }

        public async Task<IActionResult> OnComingBookings(){
            var userId = _userManager.GetUserId(User);
            var history = _bookingService.GetCustomerFutureBookings(userId);
            var modelList = new List<BookingListModel>();
            foreach (var booking in history)
            {
                var barber = await _userManager.FindByIdAsync(booking.EmployeeId);
                var name = barber.FirstName +" "+barber.LastName;
                var model = new BookingListModel(){
                    BookingDate = booking.date,
                    CreatingDate = booking.creatingDate,
                    EmployeeName =name,
                    serviceNames = _bookingService.GetServiceNames(booking.id),
                    TotalPrice = booking.totalPrice
                };

                modelList.Add(model);

            }

            return View(modelList);
            
        }

    }
}