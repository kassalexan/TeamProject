using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TeamProject
{
    public class AppContext : DbContext
    {
        public AppContext() : base("name=AppContext")
        {

        }

        public DbSet<User> Users { get; set; }

        //Fluent API
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasKey(i => i.Id);
        }
    }
}
