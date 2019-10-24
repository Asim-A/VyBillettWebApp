using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;


namespace DAL
{
     public class DB : DbContext
    {        

        public DB() : base("DB")
        {
            Database.SetInitializer(new DBInit());

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public virtual DbSet<Bestillinger> Bestillinger { get; set; }
        public virtual DbSet<Billetter> Billetter { get; set; }
        public virtual DbSet<Billett_type> Billett_typer { get; set; }


    }
}