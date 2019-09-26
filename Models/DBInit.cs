using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VyBillettWebApp.Models
{
    public class DBInit : DropCreateDatabaseAlways<DB>
    {
        protected override void Seed(DB context)
        {
            
            base.Seed(context);
        }
    }
}