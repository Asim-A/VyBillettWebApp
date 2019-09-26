using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VyBillettWebApp.Models
{
    public class BestillingViewModel
    {
        public string Strekning { get; set; }
        public string Dato { get; set; }
        public BilettType Biletttype { get; set; }
        public int TotalPris{ get; set; }
        public int AntallBarn { get; set; }
        public int AntallStudent { get; set; }
        public int AntallVoksen { get; set; }
        
    }
}