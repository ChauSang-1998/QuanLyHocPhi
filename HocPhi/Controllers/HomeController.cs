using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HocPhi.Models;

namespace HocPhi.Controllers
{
    public class HomeController : Controller
         
    {
        HocPhiEntities db = new HocPhiEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login lg)
        {
            
            if(ModelState.IsValid)
            {
                using (HocPhiEntities db = new HocPhiEntities())
                {
                    var log = db.Admins.Where(a => a.Email.Equals(lg.Email) && a.Password.Equals(lg.MatKhau)).FirstOrDefault();
                    if(log != null)
                    {
                        Session["Admin"] = log.TenAdmin;
                        Session["AdHinh"] = log.HinhAnh;
                        Session["dangnhap"] = log.Email;
                        Session["ID"] = log.ID;
                        return RedirectToAction("Admin/Index", "Admin");
                    }
                    else
                    {
                        ViewBag.SuccessMessage = "Sai tài khoản hoặc mật khẩu !";
                    }
                }
            }
            return View();


        }
    }
}