using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VyBillettWebApp.Models
{
    public class BestillingViewModel
    {
        
        public string Strekning { get; set; }
        public string Dato { get; set; }
        public List<Billett> liste_billetter { get; set; }
        
    }
}