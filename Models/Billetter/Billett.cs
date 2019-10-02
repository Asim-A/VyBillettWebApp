using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VyBillettWebApp.Models
{
    public abstract class Billett
    {
        public int BillettId { get; set; }
        public string strekning { get; set; }
        public string dato { get; set; }
    }
}