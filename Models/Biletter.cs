using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBAPP.Models
{
    public class Biletter
    {
        [Key]
        public int BilettId { get; set; }
        public string strekning { get; set; }
        public string dato { get; set; }
        public BilettType bilettType { get; set; }
        public int antall { get; set; }
    }
}