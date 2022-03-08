using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace HTHABaiThucHanh8883.Models
{
    public partial class LTQLDBcontext : DbContext
    {
        public LTQLDBcontext()
            : base("name=LTQLDBcontext")
        { }
            public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
    }
    

    }

