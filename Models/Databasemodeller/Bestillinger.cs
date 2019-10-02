using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VyBillettWebApp.Models
{
    public class Bestillinger
    {
        [Key]
        public int bestilling_id { get; set; }
        public DateTime bestilling_dato { get; set; }
        public double total_pris { get; set; }
        public virtual List<Billetter> billett_liste { get; set; }
               
    }
}