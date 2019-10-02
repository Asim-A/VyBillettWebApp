using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VyBillettWebApp.Models
{
    public class BillettType
    {
        [Key]
        public int billett_type_id { get; set; }
        [Required]
        public double  billett_pris { get; set; }
        [Required]
        public virtual List<Billetter> billetter { get; set; }
               
    }
}