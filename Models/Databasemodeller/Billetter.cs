using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public BillettType billett_type_id { get; set; }

    }
}