using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HTHABaiTapLon883.Models
{
    public class Tacgia
    {
        [Key]
        public string MaTacGia { get; set; }
        public string TenTacGia { get; set; }
    }
}