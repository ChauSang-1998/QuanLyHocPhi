using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using HocPhi.Models;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using HocPhi.Common;

using System.Data.Entity;

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
        public JsonResult GetStateListhehoc_hocsinh(string mahocsinh)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<HocSinh> ds = db.HocSinhs.Where(x => x.MaHeHoc == mahocsinh).ToList();
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
        [HttpGet]
        public ActionResult ChonLopDiemDanh()
        {
            using (HocPhiEntities context = new HocPhiEntities())
            {
                var dsLop = (from lop in context.Lops
                             select lop).ToList();
                return View(dsLop);
            }
                
        }
        [HttpPost]
        public ActionResult LayDanhSachDiemDanh(FormCollection form)
        {
            string MaLop = form[0].ToString();
            ViewBag.Operation = "create";
            using (HocPhiEntities context = new HocPhiEntities())
            {
                var HsTheoLop = (from hs in context.HocSinhs
                                 join lop in context.Lops on hs.Lop.MaLop equals lop.MaLop
                                 where hs.Lop.MaLop == MaLop
                                 select hs);
                var DsDiemDanh = (from dd in context.DiemDanhs
                                  join hs in HsTheoLop on dd.HocSinh equals hs.MaHocSinh
                                  where dd.NgayDiemDanh.Year == DateTime.Now.Year && dd.NgayDiemDanh.Month == DateTime.Now.Month && dd.NgayDiemDanh.Day == DateTime.Now.Day
                                  select dd
                                  ).ToList();
                var HSTheoTrangThaiDiemDanh = HsTheoLop.FullOuterJoin(DsDiemDanh, a => a.MaHocSinh, b => b.HocSinh, (a, b, MaHocSinh) => new 
                {
                    MaHocSinh,
                    a.TenHocSinh,
                    a.GioiTinh,
                    a.NamSinh,
                    a.TenPhuHuynh,
                    a.DienThoai,
                    a.DiaChiLienHe,
                    b?.TrangThaiDiemDanh
                });
                List<DiemDanhViewModel> _hs = new List<DiemDanhViewModel>();
                foreach(var hs in HSTheoTrangThaiDiemDanh)
                {
                    if (hs.TrangThaiDiemDanh != null)
                    {
                        ViewBag.Operation = "edit";
                    }
                    _hs.Add(new DiemDanhViewModel()
                    {
                        MaHocSinh = hs.MaHocSinh,
                        TenHocSinh = hs.TenHocSinh,
                        GioiTinh = hs.GioiTinh,
                        NamSinh = hs.NamSinh,
                        TenPhuHuynh = hs.TenPhuHuynh,
                        DienThoai = hs.DienThoai,
                        DiaChiLienHe = hs.DiaChiLienHe,
                        TrangThaiDiemDanh = hs.TrangThaiDiemDanh
                    });
                }
                Session["TongSoHocSinh"] = _hs.Count();
                return View("LayDanhSachDiemDanh", _hs);

            }
                
        }
        
        [HttpPost]
        public ActionResult DiemDanhUpdate(FormCollection form)
        {
            string[] status = form["statuslist"].ToString().Split(new Char[] { ',' });
            List<bool> statusbool = status.Select(x =>{
                    if (x == "true") return true;
                    else return false;
            }).ToList();
            string[] dsHS  = form[1].ToString().Split(new Char[] { ',' });
            ViewBag.TongSoHocSinh = (int)Session["TongSoHocSinh"];
            using (HocPhiEntities context = new HocPhiEntities())
            {
                using (IDbConnection db = new SqlConnection(context.Database.Connection.ConnectionString))
                {
                    if (form["operation"].ToString() == "create")
                    {
                        int i = 0;
                        dsHS.ToList().ForEach(
                            x =>
                            {
                                var p = new DynamicParameters();
                                p.Add("@MahocSinh", x);
                                p.Add("@TrangThai", statusbool[i]);
                                db.Execute("sp_DiemDanhHS", p, commandType: CommandType.StoredProcedure);
                                i++;
                            });
                        ViewBag.DaDiemDanh = i;
                    }
                    else
                    {
                        int j = 0;
                        dsHS.ToList().ForEach(
                            x =>
                            {
                                var q = new DynamicParameters();
                                q.Add("@MaHs", x);
                                q.Add("@TrangThaiDiemDanh", statusbool[j]);
                                db.Execute("sp_CapNhatTrangThaiDiemDanh", q, commandType: CommandType.StoredProcedure);
                                j++;
                            });
                        ViewBag.DaDiemDanh = j;
                    }    
                }
            }
            return View();

        }
        public ActionResult BienLai()
        {
            var blai = db.BienLais.ToList();
            TempData["Tienan"] = "50000";          
            return View(blai);
        }
        [HttpGet]
        public ActionResult ThemBienLai()
        {
            ViewBag.HeHoc_MHH = new SelectList(db.HeHocs.ToList().OrderBy(n => n.MaHeHoc), "MaHeHoc", "MaHeHoc");
            ViewBag.Ma_HS = new SelectList(db.HocSinhs.ToList().OrderBy(n => n.MaHocSinh), "MaHocSinh", "MaHocSinh");

            return View();
        }
        [HttpPost]
        public ActionResult ThemBienLai(BienLai BienLai)
        {
            ViewBag.HeHoc_MHH = new SelectList(db.HeHocs.ToList().OrderBy(n => n.MaHeHoc), "MaHeHoc", "MaHeHoc");
            ViewBag.Ma_HS = new SelectList(db.HocSinhs.ToList().OrderBy(n => n.MaHocSinh), "MaHocSinh", "MaHocSinh");

            db.BienLais.Add(BienLai);
            db.SaveChanges();
            return RedirectToAction("BienLai");
           
        }

    }
    
}