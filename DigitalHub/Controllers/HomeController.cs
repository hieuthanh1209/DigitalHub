using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DigitalHub.Models;
using System.IO;

namespace DigitalHub.Controllers
{
    public class HomeController : Controller
    {
        private DigitalHub_DBEntities db = new DigitalHub_DBEntities();
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
            var products = db.Products.Include(p => p.Category1);
            return View(products.ToList());
        }

        public ActionResult Laptop()
        {
            var products = db.Products.Include(p => p.Category1)
                                      .Where(p => p.Category1.IDCate == "C007");
            return View(products.ToList());
        }

        public ActionResult LinhKien()
        {
            var products = db.Products.Include(p => p.Category1)
                                      .Where(p => p.Category1.IDCate == "C004");
            return View(products.ToList());
        }

        public ActionResult BanPhimChuot()
        {
            var products = db.Products.Include(p => p.Category1)
                                      .Where(p => p.Category1.IDCate == "C005");
            return View(products.ToList());
        }

        public ActionResult TaiNghe()
        {
            var products = db.Products.Include(p => p.Category1)
                                      .Where(p => p.Category1.IDCate == "C006");
            return View(products.ToList());
        }
    }
}