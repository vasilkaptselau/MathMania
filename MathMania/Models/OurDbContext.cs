using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MathMania.Models
{
    public class OurDbContext : DbContext
    {
        public virtual DbSet<RegisterVm> Users { get; set; }
        public virtual DbSet<LoginVm> UserLog { get; set; }
    }
} 