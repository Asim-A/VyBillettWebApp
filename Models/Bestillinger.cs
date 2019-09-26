using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VyBillettWebApp.Models
{
    public class Bestillinger
    {
        [Key]
        public int bestilling_id { get; set; }
        public string strekning { get; set; }
        public string dato { get; set; }
        public virtual List<Biletter> billett_liste { get; set; }

       
    }
}