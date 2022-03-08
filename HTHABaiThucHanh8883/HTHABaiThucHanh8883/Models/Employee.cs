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
        public string NamePerson { get; set; }
        public string IDSPerson { get; set; }
    }
}