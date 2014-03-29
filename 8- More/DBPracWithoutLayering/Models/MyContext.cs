using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //var entity = modelBuilder.Entity<Student>();

            //entity.Map(mc => mc.ToTable("dbo.Students")).HasKey(key => key.StudentID);

            //entity.Property(p => p.StudentID).HasColumnName("StudentID");

            //entity.Property(x => x.StudentID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            //entity.Property(p => p.Name).HasColumnName("Name");
            //entity.Property(p => p.Address).HasColumnName("Address");
            //entity.Property(p => p.Age).HasColumnName("Age");

        }
    }
}