using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Entities;

namespace DAL
{
    public class MyContext : DbContext 
    {
        public DbSet<Student> Students
        {
            get;
            set;
        }

        public MyContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

    }
}