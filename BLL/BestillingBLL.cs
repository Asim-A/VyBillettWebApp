using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using Model;

namespace BLL
{
    public class BestillingBLL
    {
        public Bestillinger settInnBestilling(BestillingViewModel bestilling)
        {
            var dbModellBygger = new dbModellBygger();
            return dbModellBygger.settInnBestilling(bestilling);

        }
            
    }
} 