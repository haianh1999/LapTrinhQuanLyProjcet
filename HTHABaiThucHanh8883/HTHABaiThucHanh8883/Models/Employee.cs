using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HTHABaiThucHanh8883.Models
{
    public class Employee
    {
        [Key]
        public string NameEmployee { get; set; }
        public string IDSEmployee { get; set; }
    }
}