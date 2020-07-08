﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HocPhi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class HocSinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HocSinh()
        {
            this.DiemDanhs = new HashSet<DiemDanh>();
            this.BienLais = new HashSet<BienLai>();
        }
        [Required(ErrorMessage = "Vui lòng nhập mã học sinh")]
        public string MaHocSinh { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên học sinh")]

        public string TenHocSinh { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn giới tính")]

        public string GioiTinh { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập năm sinh")]

        public Nullable<System.DateTime> NamSinh { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn mã lớp")]

        public string MaLop { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn mã hệ học")]

        public string MaHeHoc { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên phụ huynh")]

        public string TenPhuHuynh { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]

        public string DienThoai { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ liên hệ")]

        public string DiaChiLienHe { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập ngày đăng ký")]

        public Nullable<System.DateTime> NgayDangKy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiemDanh> DiemDanhs { get; set; }
        public virtual HeHoc HeHoc { get; set; }
        public virtual Lop Lop { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BienLai> BienLais { get; set; }
    }
}
