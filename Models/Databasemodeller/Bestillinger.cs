using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VyBillettWebApp.Models
{
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
        [Required]
        public DateTime bestilling_dato { get; set; }
        [Required]
        public double total_pris { get; set; }

        [Required]
        public virtual List<Billetter> billett_liste { get; set; }
       
    }
}