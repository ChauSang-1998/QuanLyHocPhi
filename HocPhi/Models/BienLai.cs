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
    
    public partial class BienLai
    {
        public int MaBienLai { get; set; }
       
        public string MaHocSinh { get; set; }
        public Nullable<System.DateTime> NgayNop { get; set; }
        public string NguoiNop { get; set; }
        public Nullable<double> TienAn1ngay { get; set; }
        public Nullable<double> TienAn1thang { get; set; }
        public Nullable<bool> TrangThai { get; set; }
    
        public virtual HocSinh HocSinh { get; set; }
    }
}
