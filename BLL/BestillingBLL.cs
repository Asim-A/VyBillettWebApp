using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using Model;

namespace BLL
{
    public class BestillingBLL
    {/*
        public Bestillinger settInnBestilling(Bestilling bestilling)
        {

            var dbModellBygger = new dbModellBygger();
       //     return dbModellBygger.settInnBestilling(bestilling);

        }*/
            
        public List<Bestilling> GetBestillinger()
        {
            var BestillingDAL = new BestillingDAL();
            return BestillingDAL.GetBestillinger();
        }
    }
} 