using business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ui.Models;
using ui.EmailService;
using entity;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ui.Identity;
using ui.Extensions;

namespace ui.Controllers
{
    [Authorize(Roles="Çalışan,Patron")]
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        private IBookingService _bookingService;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;
        private IEmailSender _emailSender;
        public AdminController(IProductService productService, ICategoryService categoryService, RoleManager<IdentityRole> roleManager, UserManager<User> userManager,IEmailSender emailSender, IBookingService bookingService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _roleManager = roleManager;
            _userManager = userManager;
            _emailSender = emailSender;
            _bookingService = bookingService;
        }
        [Authorize(Roles="Patron")]
        public IActionResult UserList(){
            ViewBag.kullanıcılar  = "active";
            return View(_userManager.Users);

        }

        [Authorize(Roles="Patron")]
        public IActionResult CreateUser(){
            ViewBag.kullanıcılar  = "active";
            ViewBag.Roles = _roleManager.Roles;
            return View();
        }

        [Authorize(Roles="Patron")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreateModel model,string[] selectedRoles){
            ViewBag.Roles = _roleManager.Roles;
             if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Girdiğiniz bilgiler kriterlere uymuyor!");
                ViewBag.kullanıcılar  = "active";
                return View(model);
            }

            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                EmailConfirmed = model.EmailConfirmed,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                PhoneNumberConfirmed = model.PhoneNumberConfirmed
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user,selectedRoles);
                if(!user.EmailConfirmed){
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new
                    {
                        userId = user.Id,
                        token = code
                    });
                    try
                    {
                        await _emailSender.SendEmailAsync(model.Email, "Hesabınızı Onaylayınız.", $"Lütfen email hesabınızı onaylamak için linke <a href='http://localhost:5000{callbackUrl}'>tıklayınız.</a>");
                        TempData.Put("message",new AlertType(){
                                Title = "Kullanıcı oluşturuldu",
                                Message = "Kullanıcı başarılı bir şekilde oluşturuldu",
                                Alert="success"
                            }
                        );
                    }
                    catch (System.Exception)
                    {
                        TempData.Put("message",new AlertType(){
                                Title = "Hata!",
                                Message = "E-mail onay maili gönderilirken bir hata oluştu!",
                                Alert="danger"
                            }
                        );
                        return View(model);
                    }
                }
                return RedirectToAction("UserList");
            }


            ModelState.AddModelError("", "Bir hata oluştu!Bunun sebebi; kullanımda olan bir e-mail veya kullanıcı adı girmeniz, veya şifrenizin kriterlere uymaması olabilir!");
            return View(model);
        }

        [Authorize(Roles="Patron")]
        public async Task<IActionResult> EditUser(string id){
            ViewBag.kullanıcılar  = "active";
            if(string.IsNullOrEmpty(id)){
                return RedirectToAction("UserList");
            }
            var user = await _userManager.FindByIdAsync(id);
            if(user==null){
                return RedirectToAction("UserList");
            }
            var roles = _roleManager.Roles.Select(i=>i.Name);
            ViewBag.Roles = roles;
            var selectedroles  = await _userManager.GetRolesAsync(user);
            var model = new UserModel(){
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                SelectedRoles =selectedroles
            };
            return View(model);

        }

        [Authorize(Roles="Patron")]
        [HttpPost]
        public async Task<IActionResult> EditUser(UserModel model,string[] selectedRoles){
            ViewBag.kullanıcılar  = "active";
            if(ModelState.IsValid){
                var user = await _userManager.FindByIdAsync(model.Id);
                if(user !=null){
                    
        
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.UserName = model.UserName;
                    user.Email = model.Email;
                    user.EmailConfirmed = model.EmailConfirmed;
                    user.PhoneNumber = model.PhoneNumber;
                    user.PhoneNumberConfirmed = model.PhoneNumberConfirmed;

                    var result  = await _userManager.UpdateAsync(user);
                    if(result.Succeeded){
                        var roles = await _userManager.GetRolesAsync(user);
                        if(selectedRoles==null){

                            var result2 = await _userManager.RemoveFromRolesAsync(user,roles);
                            if(result2.Succeeded){
                                return RedirectToAction("UserList");
                            }
                            model.SelectedRoles = selectedRoles;
                            ViewBag.Roles = _roleManager.Roles.Select(i=>i.Name);;
                            return View(model);
                        }
                        await _userManager.RemoveFromRolesAsync(user,roles.Except(selectedRoles));
                        await _userManager.AddToRolesAsync(user,selectedRoles.Except(roles));
                        return RedirectToAction("UserList");
                    }
                    model.SelectedRoles = selectedRoles;
                    ViewBag.Roles = _roleManager.Roles.Select(i=>i.Name);
                    return View(model);
                }

                return RedirectToAction("UserList");
            }
            model.SelectedRoles = selectedRoles;
            ViewBag.Roles = _roleManager.Roles.Select(i=>i.Name);;
            return View(model);

        }

        [Authorize(Roles="Patron")]
        public IActionResult RoleList(){
            ViewBag.roller  = "active";
            return View(_roleManager.Roles);

        }

        [Authorize(Roles="Patron")]
        public async Task<IActionResult> EditRole(string id){
            ViewBag.roller  = "active";
            var role =await _roleManager.FindByIdAsync(id);
            if(role==null || string.IsNullOrEmpty(id)){
                return RedirectToAction("RoleList");
            }
            var members = new List<User>();
            var nonmembers = new List<User>();
            foreach (var user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user,role.Name)?members:nonmembers;
                list.Add(user);
                
            }
            var model = new RoleDetails(){
                Role = role,
                Members = members,
                NonMembers = nonmembers
            };
            return View(model);
        }

        [Authorize(Roles="Patron")]
        [HttpPost]
        public async Task<IActionResult> EditRole(RoleEditModel model){
            ViewBag.roller  = "active";
            if(!ModelState.IsValid){
                TempData.Put("message",new AlertType(){
                        Title = "Hata!",
                        Message = "Bir hata oluştu!",
                        Alert="danger"
                    }
                );
                return View(model);
            }
            if(model.IdsToAdd==null && model.IdsToDelete==null){
               return RedirectToAction("RoleList");
            }
            if(string.IsNullOrEmpty(model.RoleId)){
                TempData.Put("message",new AlertType(){
                        Title = "Hata!",
                        Message = "Bir hata oluştu!",
                        Alert="danger"
                    }
                );
                return View(model);
            }
            var role = await _roleManager.FindByIdAsync(model.RoleId);
            if(role==null){
                TempData.Put("message",new AlertType(){
                        Title = "Hata!",
                        Message = "Bir hata oluştu!",
                        Alert="danger"
                    }
                );
                 return View(model);
            }
            foreach (var id in model.IdsToAdd?? new string[]{})
            {
                if(!string.IsNullOrEmpty(id)){
                    var user = await _userManager.FindByIdAsync(id);
                    if(user!=null){
                        var result = await _userManager.AddToRoleAsync(user,model.RoleName);
                        if(!result.Succeeded){
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("",error.Description);
                            }
                            
                        }
                    }
                    else{
                         ModelState.AddModelError("",id+" id'sine sahip bir kullanıcı yok!");
                    }
                }
                else{
                     ModelState.AddModelError("","Null id'li kullanıcı eklenemez!");
                }
            }

            foreach (var id in model.IdsToDelete?? new string[]{})
            {
                if(!string.IsNullOrEmpty(id)){
                    var user = await _userManager.FindByIdAsync(id);
                    if(user!=null){
                        var result = await _userManager.RemoveFromRoleAsync(user,model.RoleName);
                        if(!result.Succeeded){
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("",error.Description);
                            }
                            
                        }
                    }
                    else{
                         ModelState.AddModelError("","Rolden silmeye çalıştığınız "+id+" id'sine sahip kullanıcı yok!");
                    }
                }
                else{
                     ModelState.AddModelError("","Null id'li kullanıcı silinemez!");
                }
            }
            return Redirect("/admin/roles/"+model.RoleId);

        }

        [Authorize(Roles="Patron")]
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string roleId){
            var role =await _roleManager.FindByIdAsync(roleId);
            if(role==null || role.Name=="Patron"){
                TempData.Put("message",new AlertType(){
                        Title = "Hata!",
                        Message = "Bu rolü silemezsin!",
                        Alert="danger"
                    }
                );
                return View();
            }
            var result = await _roleManager.DeleteAsync(role);
            if(result.Succeeded){
                TempData.Put("message",new AlertType(){
                        Title = "Rol silindi",
                        Message = "Rol başarıyla silindi!",
                        Alert="success"
                    }
                );
                return RedirectToAction("RoleList");
            }
            TempData.Put("message",new AlertType(){
                        Title = "Hata!",
                        Message = "Databaseden rol silinirken bir hata meydana geldi!",
                        Alert="danger"
                    }
                );
            return RedirectToAction("RoleList");

        }

        public IActionResult ProductList()
        {
            ViewBag.ürünler  = "active";
            return View(new ProductListModel()
            {
                Products = _productService.GetAll()
            });
        }


        [HttpGet]
        public IActionResult CreateProduct()
        {
            ViewBag.ürünler  = "active";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductModel model,IFormFile file)
        {
            ViewBag.ürünler  = "active";
            if (ModelState.IsValid)
            {
                var entity = new Product()
                {
                    name = model.Name,
                    price =(double) model.Price,
                    description = model.Description,
                    url = model.CreateUrl(),
                    isApproved = model.IsApproved
                };
                if (file!=null)
                {
                    var extension = Path.GetExtension(file.FileName);
                    string randomname = string.Format($"{Guid.NewGuid()}{extension}");
                    entity.imageUrl = randomname;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img\\products", randomname);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                try
                {
                    _productService.Create(entity);
                    var msg = new AlertType(){
                        Message = $"{entity.name} isimli ürün başarıyla eklendi",
                        Alert = "success"
                    };
                    TempData["message"] = JsonConvert.SerializeObject(msg);
                    return RedirectToAction("ProductList");
                }
                catch (System.Exception)
                {
                    var msg= new AlertType(){
                        Message = $"{entity.name} isimli ürün eklenirken bir hata oluştu!",
                        Alert = "warning"
                    };
                    TempData["message"] = JsonConvert.SerializeObject(msg);
                    return View(model);
                }
            }
            var msg1 = new AlertType(){
                    Message = "Oluşturmaya çalıştığınız ürün kriterlere uymuyor!",
                    Alert = "warning"
            };
            TempData["message"] =JsonConvert.SerializeObject(msg1) ;
            return View(model);

        }



        public IActionResult EditProduct(int? id)
        {
            ViewBag.ürünler  = "active";
            if (id == null)
            {
                return NotFound();
            }
            var entity = _productService.GetByIdWithCategories((int)id);

            if (entity == null)
            {
                return NotFound();
            }

            var model = new ProductModel()
            {
                Id = entity.id,
                Name = entity.name,
                Price = entity.price,
                Description = entity.description,
                ImageUrl = entity.imageUrl,
                IsApproved = entity.isApproved,
                SelectedCategories = entity.ProductCategories.Select(i => i.Category).ToList()
            };

            ViewBag.Categories = _categoryService.GetAll();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductModel model, int[] categoryIds, IFormFile file)
        {
            ViewBag.ürünler  = "active";
            if (ModelState.IsValid)
            {
                var entity = _productService.GetById(model.Id);

                if (entity == null)
                {
                    var msg = new AlertType(){
                    Message = "Bu id'ye sahip bir ürün yok!",
                    Alert = "warning"
                    };
                    TempData["message"] = JsonConvert.SerializeObject(msg);
                    return NotFound();
                }

                entity.name = model.Name;
                entity.description = model.Description;               
                entity.price = (double)model.Price;
                entity.url = model.CreateUrl();
                entity.isApproved = model.IsApproved;
                if (file!=null)
                {
                    var extension = Path.GetExtension(file.FileName);
                    string randomname = string.Format($"{Guid.NewGuid()}{extension}");
                    entity.imageUrl = randomname;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img\\products", randomname);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                _productService.Update(entity, categoryIds);
                 var msg1 = new AlertType(){
                    Message = $"{entity.name} isimli ürün başarıyla güncellendi!",
                    Alert = "success"
                };
                TempData["message"] = JsonConvert.SerializeObject(msg1);
                
                return RedirectToAction("ProductList");
            }

            ViewBag.Categories = _categoryService.GetAll();
             var msg2 = new AlertType(){
                    Message = "ürün kriterlere uymuyor!",
                    Alert = "warning"
                };
            TempData["message"] = JsonConvert.SerializeObject(msg2);
            var entity1 = _productService.GetByIdWithCategories(model.Id);
            var model2 = new ProductModel()
            {
                Id = entity1.id,
                Name = entity1.name,
                Price = entity1.price,
                Description = entity1.description,
                ImageUrl = entity1.imageUrl,
                IsApproved = entity1.isApproved,
                SelectedCategories = entity1.ProductCategories.Select(i => i.Category).ToList()
            };
            
            return View(model2);

        }

        [Authorize(Roles="Patron")]
        [HttpPost]
        public IActionResult DeleteProduct(int productId)
        {
            var entity = _productService.GetById(productId);

            if (entity == null)
            {
                var msg1 = new AlertType(){
                    Message = "Bu id'ye sahip bir ürün yok!",
                    Alert = "warning"
                };
                TempData["message"] = JsonConvert.SerializeObject(msg1);
                return NotFound();
            }
            _productService.Delete(entity);
                var msg2 = new AlertType(){
                Message = $"{entity.name} isimli ürün başarılıyla silindi!",
                Alert = "success"
            };
            TempData["message"] = JsonConvert.SerializeObject(msg2);
            return RedirectToAction("ProductList");
            
        }

        public IActionResult CategoryList()
        {
             ViewBag.kategoriler  = "active";
            return View(new CategoryListModel()
            {
                Categories = _categoryService.GetAll()
            });
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            ViewBag.kategoriler  = "active";
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryModel model)
        {
            ViewBag.kategoriler  = "active";
            if(ModelState.IsValid){
                var entity = new Category()
                {
                    name = model.Name,
                    url = model.CreateUrl()
                };
                _categoryService.Create(entity);
                 var msg1 = new AlertType(){
                    Message = $"{entity.name} isimli kategori başarıyla eklendi!",
                    Alert = "success"
                };
                TempData["message"] = JsonConvert.SerializeObject(msg1);
                 return RedirectToAction("CategoryList");
            }
            var msg = new AlertType(){
                Message = "kategori kriterlere uymuyor!",
                Alert = "warning"
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);

            return View(model);
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            ViewBag.kategoriler  = "active";
            var entity = _categoryService.GetByIdWithProducts(id);
            if (entity == null)
            {
                var msg = new AlertType(){
                    Message = "Bu id'ye sahip bir kategori yok!",
                    Alert = "warning"
                };
                TempData["message"] = JsonConvert.SerializeObject(msg);
                return NotFound();
            }

            return View(new CategoryModel()
            {
                Id = entity.id,
                Name = entity.name,
                Products = entity.ProductCategories.Select(p => p.Product).ToList()
            });

        }

        [HttpPost]
        public IActionResult EditCategory(CategoryModel model)
        {
            ViewBag.kategoriler  = "active";
            if(ModelState.IsValid){
                var entity = _categoryService.GetById(model.Id);
                if (entity == null)
                {
                    var msg = new AlertType(){
                        Message = "Bu id'ye sahip bir kategori yok!",
                        Alert= "warning"
                    };
                    TempData["message"] = JsonConvert.SerializeObject(msg);
                    return RedirectToAction("CategoryList");
                }

                entity.name = model.Name;
                entity.url = model.CreateUrl();
                _categoryService.Update(entity);
                var msg1 = new AlertType(){
                        Message = $"{entity.name} isimli kategori başarıyla güncellendi!",
                        Alert = "success"
                    };
                TempData["message"] = JsonConvert.SerializeObject(msg1);
                return RedirectToAction("CategoryList");
            }
            var msg2 = new AlertType(){
                    Message = "Kategori adı kriterlere uymuyor!",
                    Alert = "warning"
                };
            TempData["message"] = JsonConvert.SerializeObject(msg2);

            var entity2 = _categoryService.GetByIdWithProducts(model.Id);
            return View(new CategoryModel()
            {
                Id = entity2.id,
                Name = entity2.name,
                Products = entity2.ProductCategories.Select(p => p.Product).ToList()
            });
            
        }

        [Authorize(Roles="Patron")]
        [HttpPost]
        public IActionResult DeleteCategory(int categoryId)
        {
            var entity = _categoryService.GetById(categoryId);

            if (entity != null)
            {
                _categoryService.Delete(entity);
                var msg1 = new AlertType(){
                    Message = $"{entity.name} isimli kategori başarıyla silindi!",
                    Alert = "success"
                };
                TempData["message"] = JsonConvert.SerializeObject(msg1);
                return RedirectToAction("CategoryList");
            }
            var msg = new AlertType(){
                Message = "Bu id'ye sahip bir kategori yok!",
                Alert = "warning"
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);
            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        public IActionResult DeleteFromCategory(int categoryId, int productId)
        {
            var product = _productService.GetById(productId);
            var kategori = _categoryService.GetById(categoryId);
            _categoryService.DeleteFromCategory(categoryId, productId);
            var msg = new AlertType(){
                Message = $"{product.name} isimli ürün {kategori.name} kategorisinden başarıyla silindi!",
                Alert = "success"
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);
            return Redirect("/admin/categories/" + categoryId);
        }

        public async Task<IActionResult> CreateBooking(){
            var customers =await _userManager.GetUsersInRoleAsync("Müşteri");
            var model = new CustomerList(){
                Customers = (List<User>)customers
            };
            return View("Views/Booking/SelectCustomer.cshtml",model);
        }

        public async Task<IActionResult> BookingHistory(){
            var employeeId = _userManager.GetUserId(User);
            var history = _bookingService.GetEmployeeOldBookings(employeeId);
            var modelList = new List<BookingListModel>();
            foreach (var booking in history)
            {
                var customer = await _userManager.FindByIdAsync(booking.CustomerId);
                var name = customer.FirstName +" "+customer.LastName;
                var model = new BookingListModel(){
                    BookingDate = booking.date,
                    CreatingDate = booking.creatingDate,
                    CustomerName = name,
                    serviceNames = _bookingService.GetServiceNames(booking.id),
                    TotalPrice = booking.totalPrice
                };

                modelList.Add(model);

            }

            return View(modelList);
            
        }

        [Authorize(Roles="Patron")]
        public async Task<IActionResult> AllBookingHistory(){

            var history = _bookingService.GetOldBookings();
            var modelList = new List<BookingListModel>();
            foreach (var booking in history)
            {
                var customer = await _userManager.FindByIdAsync(booking.CustomerId);
                var employee = await _userManager.FindByIdAsync(booking.EmployeeId);
                var customername = customer.FirstName +" "+customer.LastName;
                var employeename = employee.FirstName +" "+employee.LastName;
                var model = new BookingListModel(){
                    BookingDate = booking.date,
                    CreatingDate = booking.creatingDate,
                    CustomerName = customername,
                    EmployeeName = employeename,
                    serviceNames = _bookingService.GetServiceNames(booking.id),
                    TotalPrice = booking.totalPrice
                };

                modelList.Add(model);

            }

            return View(modelList);
            
        }

        public async Task<IActionResult> OnComingBookings(){

            var history = _bookingService.GetEmployeeFutureBookings(_userManager.GetUserId(User));
            var modelList = new List<BookingListModel>();
            foreach (var booking in history)
            {
                var customer = await _userManager.FindByIdAsync(booking.CustomerId);
                var customername = customer.FirstName +" "+customer.LastName;
                var model = new BookingListModel(){
                    BookingDate = booking.date,
                    CreatingDate = booking.creatingDate,
                    CustomerName = customername,
                    serviceNames = _bookingService.GetServiceNames(booking.id),
                    TotalPrice = booking.totalPrice
                };

                modelList.Add(model);

            }

            return View(modelList);
            
        }

        [Authorize(Roles="Patron")]
        public async Task<IActionResult> AllOnComingBookings(){

            var history = _bookingService.GetFutureBookings();
            var modelList = new List<BookingListModel>();
            foreach (var booking in history)
            {
                var customer = await _userManager.FindByIdAsync(booking.CustomerId);
                var employee = await _userManager.FindByIdAsync(booking.EmployeeId);
                var customername = customer.FirstName +" "+customer.LastName;
                var employeename = employee.FirstName +" "+employee.LastName;
                var model = new BookingListModel(){
                    BookingDate = booking.date,
                    CreatingDate = booking.creatingDate,
                    CustomerName = customername,
                    EmployeeName = employeename,
                    serviceNames = _bookingService.GetServiceNames(booking.id),
                    TotalPrice = booking.totalPrice
                };

                modelList.Add(model);

            }

            return View(modelList);
            
        }
    }
}