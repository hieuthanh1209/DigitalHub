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