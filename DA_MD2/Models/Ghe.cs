using System;
using System.Collections.Generic;

#nullable disable

namespace DA_MD2.Models
{
    public partial class Ghe
    {
        public int Id { get; set; }
        public string SoGhe { get; set; }
        public int? IdLoaiGhe { get; set; }
        public int? IdPhong { get; set; }
        public string Day { get; set; }
        public int? Hang { get; set; }

        public virtual LoaiGhe IdLoaiGheNavigation { get; set; }
        public virtual Phong IdPhongNavigation { get; set; }
    }
}
