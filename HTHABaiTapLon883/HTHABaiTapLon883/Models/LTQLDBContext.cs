using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace HTHABaiTapLon883.Models
{
    public partial class LTQLDBContext : DbContext
    {
        public LTQLDBContext()
            : base("name=LTQLDBContext")
        { }
             public virtual DbSet<Tacgia> TacGias { get; set; }
 


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
