﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HTHABaiTapLon883.Models
{
    public class Role
    {
        [Key]
        public string RoleID { get; set; }
        public string RoleName { get; set; }
    }
}