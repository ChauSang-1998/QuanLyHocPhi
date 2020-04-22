using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HocPhi.Models
{
    public class LopVaDiemDanhViewModel
    {
        public string MaLop { get; set; }
        public string TenLop { get; set; }

        public DateTime? MaxDate { get; set; }

        public DateTime? MinDate { get; set; }
    }
}