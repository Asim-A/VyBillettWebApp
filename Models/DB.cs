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
        public virtual DbSet<Biletter> Biletter { get; set; }
        public virtual DbSet<BilettType> BilettType { get; set; }

        public void LeggInnBestilling(BestillingViewModel bestilling) {
            Biletter NyBilett = new Biletter();
            NyBilett.strekning = bestilling.Strekning;
            NyBilett.dato = bestilling.Dato;
            NyBilett.bilettType = bestilling.Biletttype;
            if (bestilling.Biletttype.ToString() == "BARN")
            {
                NyBilett.antall = bestilling.AntallBarn;
            }
            else if (bestilling.Biletttype.ToString() == "STUDENT")
            {
                NyBilett.antall = bestilling.AntallStudent;
            }
            else {
                NyBilett.antall = bestilling.AntallVoksen;
            }
        
        }

    }
}