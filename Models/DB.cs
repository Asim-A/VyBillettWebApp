using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WEBAPP.Models
{
    public class DB : DbContext
    {
        public DB() : base("name=DB")
        {
            Database.CreateIfNotExists();
            Database.SetInitializer(new DBInit());

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public virtual DbSet<Bestilling> Bestilling { get; set; }
        public virtual DbSet<Biletter> Biletter { get; set; }
        public virtual DbSet<BilettType> BilettType { get; set; }

    }
}