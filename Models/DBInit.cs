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
            var barn = new BilettType {
                Navn = "BARN",
                pris = 10
            };
            var student = new BilettType
            {
                Navn = "STUDENT",
                pris = 20
            };
            var voksen = new BilettType
            {
                Navn = "VOKSEN",
                pris = 30
            };
            context.BilettType.Add(barn);
            context.BilettType.Add(student);
            context.BilettType.Add(voksen);
            base.Seed(context);
        }
    }
}