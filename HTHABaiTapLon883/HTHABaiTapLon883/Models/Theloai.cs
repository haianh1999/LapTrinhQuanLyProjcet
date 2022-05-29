using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HTHABaiTapLon883.Models
{
    public class Theloai
    {
        [Key]
        public int MaTheLoai { get; set; }
        public string TenTheLoai { get; set; }
        public ICollection<Sach> sachs { get; set; }
    }
}