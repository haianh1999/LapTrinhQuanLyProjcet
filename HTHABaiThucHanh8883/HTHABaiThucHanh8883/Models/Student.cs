using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HTHABaiThucHanh8883.Models
{
    [Table("Học sinh")]
    public class Student
    {
        [Key]
        public string NameStudent {get; set;}
        public string IDStudent { get; set; }
    }
}