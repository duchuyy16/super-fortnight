using System;
using System.Collections.Generic;

#nullable disable

namespace DA_MD2.Models
{
    public partial class Rating
    {
        public int? Id { get; set; }
        public int? IdPhim { get; set; }
        public DateTime? Ngay { get; set; }
        public int? Diem { get; set; }
        public string Ip { get; set; }
    }
}
