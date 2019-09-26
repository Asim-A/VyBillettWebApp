using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VyBillettWebApp.Models
{
    public class Bestillinger
    {
        [Key]
        public int bestilling_id { get; set; }
        public virtual List<Billetter> billett_liste { get; set; }
               
    }
}