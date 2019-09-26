using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VyBillettWebApp.Models
{
    public class BilettType
    {
        [Key]
        public string Navn { get; set; }
        public int pris { get; set; }
        public virtual List<Biletter> BiletterIBilettType { get; set; }
    }
}