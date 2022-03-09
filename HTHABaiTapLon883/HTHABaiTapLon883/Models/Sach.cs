using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}