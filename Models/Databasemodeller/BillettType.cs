using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VyBillettWebApp.Models
{
    public abstract class BillettType
    {
        [Key]
        public string billett_type { get; set; }
        [Required]
        public double billett_pris { get; set; }
    }
}