using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.Data.Entity;



namespace MathMania.Models
{
    public class OurDbContext : DbContext
    {
        public DbSet<Account> UsersAccount { get; set; }
        public DbSet<LoginVm> UserLog { get; set; }
    
        //public virtual DbSet<LoginVm> UserLog { get; set; }
        //public object UserAccount { get; internal set; }
    }

}