using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VyBillettWebApp.Models
{
    public class Billetter
    {
        [Key]
        public int billett_id { get; set; }
        [Required]
        public Bestillinger bestilling_id { get; set; }
        [Required]
        public BillettType billett_type_id { get; set; }

    }
}