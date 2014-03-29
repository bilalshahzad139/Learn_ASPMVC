using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DBPracWithEF.Models
{
    public class SMSContext : DbContext
    {
        public DbSet<Users> Users
        {
            get;
            set;
        }
        public DbSet<TeacherDTO> Teachers
        {
            get;
            set;
        }
        public DbSet<StudentDTO> Students
        {
            get;
            set;
        }
        public DbSet<AddressDTO> Addresses
        {
            get;
            set;
        }
        public SMSContext()
        {
            //this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

    }
}