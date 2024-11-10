using DigitalHub.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalHub.Controllers
{
    public class ProductsController : Controller
    {
        private DigitalHub_DBEntities db = new DigitalHub_DBEntities();

        public ActionResult Details(int id)
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            // Ghi nhận lịch sử xem sản phẩm
            SaveProductViewHistory(id);

            return View(product);
        }

        private void SaveProductViewHistory(int productId)
        {
            if (Session["TaiKhoan"] != null)
            {
                var currentCustomer = (Customer)Session["TaiKhoan"];

                var viewHistory = new ProductViewHistory
                {
                    CustomerID = currentCustomer.IDCus,
                    ProductID = productId,
                    ViewDate = DateTime.Now
                };

                db.ProductViewHistories.Add(viewHistory);
                db.SaveChanges();
            }
        }
    }

}