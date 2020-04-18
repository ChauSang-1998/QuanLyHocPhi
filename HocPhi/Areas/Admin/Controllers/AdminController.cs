using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using HocPhi.Models;

namespace HocPhi.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        HocPhiEntities db = new HocPhiEntities();
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Inde1x()
        {
            return View();
        }

        public ActionResult HeHoc()
        {
            var hehoc = db.HeHocs.ToList();

            return View(hehoc);
        }
        [HttpGet]
        public ActionResult ThemHeHoc()
        {

            return View();
        }

        [HttpPost]
        public ActionResult ThemHeHoc(HeHoc hehoc)
        {

            db.HeHocs.Add(hehoc);
            db.SaveChanges();
            return RedirectToAction("HeHoc");
        }
        [HttpGet]
        public ActionResult SuaHeHoc(string mahehoc)
        {
            HeHoc hehoc = db.HeHocs.SingleOrDefault(n => n.MaHeHoc == mahehoc);
            return View(hehoc);
        }

        [HttpPost]
        public ActionResult SuaHeHoc(HeHoc hehoc)
        {
            db.Entry(hehoc).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("HeHoc");
        }
        public ActionResult XoaHeHoc(string mahehoc)
        {
            HeHoc hehoc = db.HeHocs.SingleOrDefault(n => n.MaHeHoc == mahehoc);
            db.HeHocs.Remove(hehoc);
            db.SaveChanges();
            return RedirectToAction("HeHoc");
        }
        public ActionResult HocSinh()
        {
            var hocsinh = db.HocSinhs.ToList();

            return View(hocsinh);
        }
        [HttpGet]
        public ActionResult ThemHocSinh()
        {
            ViewBag.HeHoc_MHH = new SelectList(db.HeHocs.ToList().OrderBy(n => n.MaHeHoc), "MaHeHoc", "MaHeHoc");
            ViewBag.Lop_MaL = new SelectList(db.Lops.ToList().OrderBy(n => n.MaLop), "MaLop", "MaLop");

            return View();
        }
        [HttpPost]
        public ActionResult ThemHocSinh(HocSinh hocsinh)
        {
            ViewBag.HeHoc_MHH = new SelectList(db.HeHocs.ToList().OrderBy(n => n.MaHeHoc), "MaHeHoc", "MaHeHoc");
            ViewBag.Lop_MaL = new SelectList(db.Lops.ToList().OrderBy(n => n.MaLop), "MaLop", "MaLop");

            db.HocSinhs.Add(hocsinh);
            db.SaveChanges();
            return RedirectToAction("HocSinh");
        }
        [HttpGet]
        public ActionResult SuaHocSinh(string mahocsinh)
        {
            HocSinh hocsinh = db.HocSinhs.SingleOrDefault(n => n.MaHocSinh == mahocsinh);
            return View(hocsinh);
        }

        [HttpPost]
        public ActionResult SuaHocSinh(HocSinh hocsinh)
        {
            db.Entry(hocsinh).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("HocSinh");
        }
        public ActionResult XoaHocSinh(string mahocsinh)
        {
            HocSinh hocsinh = db.HocSinhs.SingleOrDefault(n => n.MaHocSinh == mahocsinh);
            db.HocSinhs.Remove(hocsinh);
            db.SaveChanges();
            return RedirectToAction("HocSinh");
        }

        public ActionResult Lop()
        {
            var lop = db.Lops.ToList();
            ViewBag.Lop_MaL = new SelectList(db.Lops.ToList().OrderBy(n => n.MaLop), "MaLop", "MaLop");
            return View(lop);


        }
        [HttpGet]
        public ActionResult XemHocSinh(string malop)
        {
            var products = db.HocSinhs.Where(pr => pr.MaLop == malop).ToList();

            return View(products);
        }

        public JsonResult GetStateListLop_hocsinh(string malop)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<HocSinh> ds = db.HocSinhs.Where(x => x.MaLop == malop).ToList();
            return Json(ds, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetStateListhehoc_lop(string malop)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Lop> ds = db.Lops.Where(x => x.MaHeHoc == malop).ToList();
            return Json(ds, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult ThemLop()
        {

            ViewBag.Ma_GV = new SelectList(db.GiaoViens.ToList().OrderBy(n => n.MaGiaoVien), "MaGiaoVien", "MaGiaoVien");

            ViewBag.HeHoc_MHH = new SelectList(db.HeHocs.ToList().OrderBy(n => n.MaHeHoc), "MaHeHoc", "MaHeHoc");
            return View();
        }
        [HttpPost]
        public ActionResult ThemLop(Lop lop)
        {
            ViewBag.Ma_GV = new SelectList(db.GiaoViens.ToList().OrderBy(n => n.MaGiaoVien), "MaGiaoVien", "MaGiaoVien");

            ViewBag.HeHoc_MHH = new SelectList(db.HeHocs.ToList().OrderBy(n => n.MaHeHoc), "MaHeHoc", "MaHeHoc");
            db.Lops.Add(lop);
            db.SaveChanges();
            return RedirectToAction("Lop");
        }
        [HttpGet]
        public ActionResult SuaLop(string malop)
        {
            ViewBag.Ma_GV = new SelectList(db.GiaoViens.ToList().OrderBy(n => n.MaGiaoVien), "MaGiaoVien", "MaGiaoVien");

            Lop lop = db.Lops.SingleOrDefault(n => n.MaLop == malop);
            return View(lop);
        }

        [HttpPost]
        public ActionResult SuaLop(Lop lop)
        {
            ViewBag.Ma_GV = new SelectList(db.GiaoViens.ToList().OrderBy(n => n.MaGiaoVien), "MaGiaoVien", "MaGiaoVien");

            db.Entry(lop).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Lop");
        }
        public ActionResult XoaLop(string malop)
        {
            Lop lop = db.Lops.SingleOrDefault(n => n.MaLop == malop);
            db.Lops.Remove(lop);
            db.SaveChanges();
            return RedirectToAction("Lop");
        }
        public ActionResult DiemDanh()
        {
            return View();
        }
        public ActionResult exit()
        {
            Session.Clear();
            return Redirect("/Home/Login");
        }
        public ActionResult GiaoVien()
        {
            var gv = db.GiaoViens.ToList();
            return View(gv);
        }
        [HttpGet]
        public ActionResult ThemGiaoVien()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ThemGiaoVien(GiaoVien gv)
        {

            db.GiaoViens.Add(gv);
            db.SaveChanges();
            return RedirectToAction("GiaoVien");
        }
        [HttpGet]
        public ActionResult SuaGiaoVien(string magiaovien)
        {
            GiaoVien gv = db.GiaoViens.SingleOrDefault(n => n.MaGiaoVien == magiaovien);
            return View(gv);
        }

        [HttpPost]
        public ActionResult SuaGiaoVien(GiaoVien gv)
        {
            db.Entry(gv).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("GiaoVien");
        }
        public ActionResult XoaGiaoVien(string magiaovien)
        {
            GiaoVien gv = db.GiaoViens.SingleOrDefault(n => n.MaGiaoVien == magiaovien);
            db.GiaoViens.Remove(gv);
            db.SaveChanges();
            return RedirectToAction("GiaoVien");
        }
        public ActionResult ChonLopDiemDanh()
        {
            using (HocPhiEntities context = new HocPhiEntities())
            {
                var dsLop = (from lop in context.Lops
                             select lop).ToList();
                return View(dsLop);
            }
                
        }
        [HttpGet]
        public ActionResult LayDanhSachDiemDanh(string MaLop)
        {
            using (HocPhiEntities context = new HocPhiEntities())
            {
                var HsTheoLop = (from hs in context.HocSinhs
                                 join lop in context.Lops on hs.Lop.MaLop equals lop.MaLop
                                 where hs.Lop.MaLop == MaLop
                                 select hs).ToList();
                return View(HsTheoLop);
            }
                
        }
    }
}