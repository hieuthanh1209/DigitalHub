using DigitalHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalHub.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Danh sách sản phẩm mẫu
            var products = new List<Product>
        {
            new Product { ProductID = 1, NamePro = "Laptop gaming Acer Nitro 16 Phoenix AN16 41 R50Z", DecriptionPro = "Laptop gaming 16gb ram", Price = 31490000, DiscountPrice = 29990000, ImagePro = "https://storage.googleapis.com/a1aa/image/Dlk3VfxEQP3cFiRd4jEUQ1oIicvRcqjs9bmETIpDwkGeqWnTA.jpg" },
            
            // Thêm các sản phẩm khác
        };

            return View(products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult TrangChu()
        {
            return View();
        }
    }
}