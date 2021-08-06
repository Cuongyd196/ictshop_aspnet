using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ictshop.Models;
namespace Ictshop.Controllers
{
    public class UserController : Controller
    {
        Qlbanhang db = new Qlbanhang();
        // ĐĂNG KÝ
        public ActionResult Dangky()
        {
            return View();
        }

        // ĐĂNG KÝ PHƯƠNG THỨC POST
        [HttpPost]
        public ActionResult Dangky(Nguoidung nguoidung)
        {
            try
            {
                // Thêm người dùng  mới
                db.Nguoidungs.Add(nguoidung);
                // Lưu lại vào cơ sở dữ liệu
                db.SaveChanges();
                // Nếu dữ liệu đúng thì trả về trang đăng nhập
                if (ModelState.IsValid)
                    {
                        return RedirectToAction("Dangnhap");
                    }
                return View("Dangky");
                
            }
            catch
            {
                return View();
            }
        }
   
        public ActionResult Dangnhap()
        {
            return View();

        }


        [HttpPost]
        public ActionResult Dangnhap(FormCollection userlog)
        {
            string userMail = userlog["userMail"].ToString();
            string password = userlog["password"].ToString();
            var islogin = db.Nguoidungs.SingleOrDefault(x => x.Email.Equals(userMail) && x.Matkhau.Equals(password));

            if (islogin != null)
                {
                    if (userMail == "Admin@gmail.com")
                        {
                           Session["use"] = islogin;
                           return RedirectToAction("Index", "Admin/Home");
                        }
                     else
                         {
                           Session["use"] = islogin;
                           return RedirectToAction("Index","Home");
                         }
                 }
            else
                {
                    ViewBag.Fail = "Đăng nhập thất bại";
                    return View("Dangnhap");
                }

        }
        public ActionResult DangXuat()
        {
            Session["use"] = null;
            return RedirectToAction("Index","Home");

        }


    }
}