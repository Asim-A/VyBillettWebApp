using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;


namespace VyBillettWebApp.Models
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
        public virtual DbSet<Bestillinger> Bestilling { get; set; }
        public virtual DbSet<Billetter> Billetter { get; set; }
        public virtual DbSet<BillettType> BillettType { get; set; }

        public void LeggInnBestilling(BestillingViewModel bestilling) {
                                              
        }

    }
}