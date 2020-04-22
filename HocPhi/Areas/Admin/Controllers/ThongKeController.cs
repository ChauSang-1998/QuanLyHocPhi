using HocPhi.Common;
using HocPhi.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocPhi.Areas.Admin.Controllers
{
    public class ThongKeController : Controller
    {
        // GET: Admin/ThongKe
        [AjaxOnly]
        [HttpGet]
        public ActionResult DiemDanh()
        {
            using (HocPhiEntities context = new HocPhiEntities())
            {
                var dsLop = (from lop in context.Lops
                             join hs in context.HocSinhs on lop.MaLop equals hs.MaLop
                             join dd in context.DiemDanhs on hs.MaHocSinh equals dd.HocSinh
                             group dd by
                             new
                             {
                                 IDLop = lop.MaLop,
                                 TenLopP = lop.TenLop,

                             }
                             into g
                             select new
                             {
                                 g.Key.IDLop,
                                 TenLopHoc = g.Key.TenLopP,
                                 Mindate = g.Min(x => x.NgayDiemDanh)
                             }).ToList();

                return Json(dsLop, JsonRequestBehavior.AllowGet);

            }
              
        }

        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        [AjaxOnly]
        public ActionResult LichSuDiemDanh (string NgayDiemDanh, string MaLop)
        {
            
            DateTime dt = DateTime.ParseExact(NgayDiemDanh, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            using (HocPhiEntities context = new HocPhiEntities())
            {
                var HsTheoLop = (from hs in context.HocSinhs
                                 join lop in context.Lops on hs.Lop.MaLop equals lop.MaLop
                                 where hs.Lop.MaLop == MaLop
                                 select hs);
                var DsDiemDanh = (from dd in context.DiemDanhs
                                  join hs in HsTheoLop on dd.HocSinh equals hs.MaHocSinh
                                  where dd.NgayDiemDanh.Year == dt.Year && dd.NgayDiemDanh.Month == dt.Month && dd.NgayDiemDanh.Day == dt.Day
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
                foreach (var hs in HSTheoTrangThaiDiemDanh)
                {
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

                return PartialView("LichSuDiemDanh", _hs);
            } 
        }
    }
}