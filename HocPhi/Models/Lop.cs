//------------------------------------------------------------------------------
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
    
    public partial class Lop
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lop()
        {
            this.HocSinhs = new HashSet<HocSinh>();
        }
    
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public string MaHeHoc { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public string MaGiaoVien { get; set; }
        public string GhiChu { get; set; }
        public Nullable<System.DateTime> NgayBatDau { get; set; }
        public string MaGiaoVien1 { get; set; }
    
        public virtual GiaoVien GiaoVien { get; set; }
        public virtual HeHoc HeHoc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HocSinh> HocSinhs { get; set; }
        public virtual GiaoVien GiaoVien1 { get; set; }
        public virtual GiaoVien GiaoVien2 { get; set; }
        public virtual GiaoVien GiaoVien11 { get; set; }
    }
}
