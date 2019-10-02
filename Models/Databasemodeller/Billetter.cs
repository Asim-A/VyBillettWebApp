using System;
using System.ComponentModel.DataAnnotations;

namespace VyBillettWebApp.Models
{
    public class Billetter
    {
        [Key]
        public int BillettId { get; set; }
        public string fra { get; set; }
        public string til { get; set; }
        public DateTime reise_dato { get; set; }
        public Bestillinger bestilling_id { get; set; }   
        public BillettType billett_type { get; set; }

        public virtual Bestillinger Bestilling { get; set; }

    }
}