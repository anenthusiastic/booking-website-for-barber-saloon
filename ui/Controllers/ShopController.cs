using business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ui.Models;
using entity;
namespace ui.Controllers
{
    public class ShopController : Controller
    {
        private IProductService _productservice;
        public ShopController(IProductService productservice){
             _productservice = productservice;
        }
         public IActionResult List(string category, int page = 1){
            ViewBag.shop = "active";
            const int pageSize = 3;
            return View(new ProductListModel()
            {
                Products = _productservice.GetProductsByCategory(category, page, pageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = _productservice.GetCountByCategory(category),
                    CurrentCategory = category
                }
            });
        }
         public IActionResult Details(string producturl){
             ViewBag.shop = "active";
            if (String.IsNullOrEmpty(producturl))
            {
                return NotFound();
            }
            Product product = _productservice.GetProductDetails(producturl);
            if (product == null)
            {
                return NotFound();
            }
            return View(new ProductDetailModel()
            {
                Product = product,
                Categories = product.ProductCategories.Select(i => i.Category).ToList()
            });
        }
        public IActionResult Search(string search){
            ViewBag.shop = "active";
            return View(new ProductListModel(){
                Products = _productservice.GetProductBySearch(search)
                }
            
            );
        }

    }
}