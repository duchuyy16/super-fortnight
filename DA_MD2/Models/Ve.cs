using System;
using System.Collections.Generic;

#nullable disable

namespace DA_MD2.Models
{
    public partial class Ve
    {
        public int Id { get; set; }
        public DateTime? NgayBanVe { get; set; }
        public string SoGhe { get; set; }
        public int? GiaVe { get; set; }
        public int? IdLichChieu { get; set; }
        public int? IdNhanVien { get; set; }
        public int? TinhTrang { get; set; }

        public virtual LichChieu IdLichChieuNavigation { get; set; }
        public virtual NhanVien IdNhanVienNavigation { get; set; }
    }
}
