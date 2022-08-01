using System;
using System.Collections.Generic;

#nullable disable

namespace DA_MD2.Models
{
    public partial class LichChieu
    {
        public LichChieu()
        {
            Ves = new HashSet<Ve>();
        }

        public int Id { get; set; }
        public int? IdSuatChieu { get; set; }
        public int? IdPhong { get; set; }
        public int? IdPhim { get; set; }
        public DateTime? NgayChieu { get; set; }

        public virtual Phim IdPhimNavigation { get; set; }
        public virtual Phong IdPhongNavigation { get; set; }
        public virtual SuatChieu IdSuatChieuNavigation { get; set; }
        public virtual ICollection<Ve> Ves { get; set; }
    }
}
