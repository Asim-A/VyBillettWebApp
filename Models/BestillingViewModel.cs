using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPP.Models
{
    public class BestillingViewModel
    {
        public string Strekning { get; set; }
        public string Dato { get; set; }
        public string Biletttype { get; set; }
        public int TotalPris{ get; set; }
        public int AntallBarn { get; set; }
        public int AntallStudent { get; set; }
        public int AntallVoksen { get; set; }
        
    }
}