using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;


namespace DAL
{
    // Entiteter 
    public class Bestillinger
    {
        [Key]
        public int bestilling_id { get; set; }
        [Required]
        public string fra { get; set; }
        [Required]
        public string til { get; set; }
        [Required]
        public DateTime reise_dato { get; set; }
        public DateTime? retur_dato { get; set; }
        [Required]
        public DateTime bestilling_dato { get; set; }
        [Required]
        public double total_pris { get; set; }
        [Required]
        public virtual List<Billetter> billett_liste { get; set; }

    }

    public class Billetter
    {
        [Key]
        public int billett_id { get; set; }
        [Required]
        public int bestilling_id { get; set; }
        [Required]
        public String billett_type { get; set; }     
    }

    public class Billett_type
    {
        [Key]
        public String billett_type { get; set; }

        public double pris { get; set; }
    }
    public class Bruker
    {
        [Key]
        public int bruker_id { get; set; }
        [Required]
        public string e_postadresse { get; set; }
        [Required]
        public byte[] passord { get; set; }
        [Required]
        public DateTime dato { get; set; }
        [Required]
        public string salt { get; set; }
    }

    public class DB : DbContext
    {

        public DB() : base("name=DB")
        {
            Database.SetInitializer(new DBInit());

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DB>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public virtual DbSet<Bestillinger> Bestillinger { get; set; }
        public virtual DbSet<Billetter> Billetter { get; set; }
        public virtual DbSet<Billett_type> Billett_typer { get; set; }
        public virtual DbSet<Bruker> Bruker { get; set; }


    }
}