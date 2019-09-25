using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBAPP.Models
{
    public class Bestilling
    {
        [Key]
        public int BId { get; set; }
        public string strekning { get; set; }
        public string dato { get; set; }
        public virtual List<Biletter> biletterIBestilling { get; set; }

       
    }
}