using Microsoft.AspNetCore.Mvc;
using business.Abstract;
using ui.Models;
namespace ui.Controllers
{
    public class HomeController:Controller
    {
        private IServiceService _serviceservice;
        public HomeController(IServiceService serviceservice){
             _serviceservice = serviceservice;
        }
        public IActionResult Index(){
            ViewBag.home = "active";
            return View(new ServiceListModel() {
                Services = _serviceservice.GetAll()
            });
        }

         public IActionResult About(){
            ViewBag.about = "active";
            return View();
        }
         public IActionResult Service(){
            ViewBag.service = "active";
            return View(new ServiceListModel() {
                Services = _serviceservice.GetAll()
            });
        }
         public IActionResult Contact(){
            ViewBag.contact = "active";
            return View();
        }
    }
}