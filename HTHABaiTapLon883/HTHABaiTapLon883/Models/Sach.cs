using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HTHABaiTapLon883.Models
{
    public class Sach
    {
        [Key]
        public string IDSach { get; set; }
        public string TenSach { get; set; }
        public string GiaSach { get; set; }
        public int MaTheLoai { get; set; }
        [ForeignKey("MaTheLoai")]
        public virtual Theloai TheLoais { get; set; }
        public string MaTacGia { get; set; }
        [ForeignKey("MaTacGia")]
        public virtual Tacgia TacGias { get; set; }

        public string MaNhaXuatBan { get; set; }
        [ForeignKey("MaNhaXuatBan")]
        public virtual Nhaxuatban Nhaxuatbans { get; set; }
    }
}