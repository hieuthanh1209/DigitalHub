using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigitalHub.Models;

namespace DigitalHub.Controllers
{
    public class UsersController : Controller
    {
        private DigitalHub_DBEntities database = new DigitalHub_DBEntities();

        // GET: Users
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer cust)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(cust.NameCus))
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập không được để trống");
                if (string.IsNullOrEmpty(cust.PassCus))
                    ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (string.IsNullOrEmpty(cust.EmailCus))
                    ModelState.AddModelError(string.Empty, "Email không được để trống");
                if (string.IsNullOrEmpty(cust.PhoneCus))
                    ModelState.AddModelError(string.Empty, "Điện thoại không được để trống");
                //Kiểm tra xem có người nào đã đăng kí với tên đăng nhập này hay chưa

                var khachhang = database.Customers.FirstOrDefault(k =>
               k.NameCus == cust.NameCus);
                if (khachhang != null)
                    ModelState.AddModelError(string.Empty, "Đã có người đăng kí tên này");
                if (ModelState.IsValid)
                {
                    database.Customers.Add(cust);
                    database.SaveChanges();
                }
                else
                {
                    return View();
                }
            }
            return RedirectToAction("Login");
        }

        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer cust)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(cust.NameCus))
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập không được để trống");
                if (string.IsNullOrEmpty(cust.PassCus))
                    ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (ModelState.IsValid)
                {
                    var khachhang = database.Customers.FirstOrDefault(k => k.NameCus == cust.NameCus && k.PassCus == cust.PassCus);
                    if (khachhang != null)
                    {
                        Session["TaiKhoan"] = khachhang;
                        return RedirectToAction("Index", "Home"); // Chuyển hướng về trang chủ sau khi đăng nhập
                    }
                    else
                        ModelState.AddModelError(string.Empty, "Tên đăng nhập hoặc mật khẩu không đúng");
                }
            }
            return View();
        }


        // GET: Logout
        [HttpGet]
        public ActionResult Logout()
        {
            // Xóa session
            Session.Clear();
            Session.Abandon();

            // Xóa cookie xác thực nếu có
            if (Request.Cookies["UserCookie"] != null)
            {
                var cookie = new HttpCookie("UserCookie")
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                Response.Cookies.Add(cookie);
            }

            TempData["ThongBao"] = "Đăng xuất thành công!";
            return RedirectToAction("Login");
        }

        private bool IsUserLoggedIn()
        {
            return Session["TaiKhoan"] != null;
        }
<<<<<<< HEAD
        public ActionResult ViewHistory()
        {
            if (!IsUserLoggedIn())
            {
                return RedirectToAction("Login");
            }

            var currentCustomer = (Customer)Session["TaiKhoan"];

            // Lấy danh sách sản phẩm đã xem
            var viewedProducts = database.ProductViewHistories
                .Where(v => v.CustomerID == currentCustomer.IDCus)
                .OrderByDescending(v => v.ViewDate)
                .Select(v => v.Product)
                .Distinct()
                .ToList();

            return View(viewedProducts);
        }

        // GET: ChangePassword
        [HttpGet]
        public ActionResult ChangePassword()
        {
            if (!IsUserLoggedIn())
            {
                return RedirectToAction("Login");
            }

            // Lấy thông tin khách hàng từ session
            var currentCustomer = (Customer)Session["TaiKhoan"];

            return View(currentCustomer);
        }

        // POST: ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(Customer model)
        {
            if (!IsUserLoggedIn())
            {
                return RedirectToAction("Login");
            }

            // Lấy thông tin khách hàng từ session
            var currentCustomer = (Customer)Session["TaiKhoan"];
            var customerInDb = database.Customers.Find(currentCustomer.IDCus);

            // Lấy mật khẩu hiện tại, mật khẩu mới và xác nhận mật khẩu từ form
            string currentPassword = Request.Form["CurrentPassword"];
            string newPassword = Request.Form["NewPassword"];
            string confirmPassword = Request.Form["ConfirmPassword"];

            // Kiểm tra mật khẩu hiện tại có khớp không
            if (string.IsNullOrEmpty(currentPassword))
            {
                ModelState.AddModelError("CurrentPassword", "Vui lòng nhập mật khẩu hiện tại.");
            }
            else if (currentPassword != customerInDb.PassCus)
            {
                ModelState.AddModelError("CurrentPassword", "Mật khẩu hiện tại không đúng.");
            }

            // Kiểm tra mật khẩu mới
            if (string.IsNullOrEmpty(newPassword))
            {
                ModelState.AddModelError("NewPassword", "Vui lòng nhập mật khẩu mới.");
            }
            else if (!IsPasswordStrong(newPassword))
            {
                ModelState.AddModelError("NewPassword", "Mật khẩu mới không đủ mạnh. Cần ít nhất 8 ký tự, chứa chữ và số.");
            }

            // Kiểm tra xác nhận mật khẩu
            if (string.IsNullOrEmpty(confirmPassword))
            {
                ModelState.AddModelError("ConfirmPassword", "Vui lòng xác nhận mật khẩu mới.");
            }
            else if (newPassword != confirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "Mật khẩu mới và xác nhận mật khẩu không khớp.");
            }

            if (ModelState.IsValid)
            {
                // Cập nhật mật khẩu mới
                customerInDb.PassCus = newPassword;
                database.SaveChanges();

                TempData["SuccessMessage"] = "Đổi mật khẩu thành công!";
                return RedirectToAction("ChangePassword");
            }
            return View(customerInDb);
        }
=======
>>>>>>> parent of 1642eb9 (đã sửa:)
    }
}