using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HTHABaiThucHanh8883.Models
{
    [Table("Nguoi")]
    public class Person
    {
        [Key]
        public string PersonID { get; set; }
        public string PersonName{ get; set; }
    }
}