using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VyBillettWebApp.Models;
using VyBillettWebApp.Models.Databasemodeller;

namespace VyBillettWebApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpPost]
        public ActionResult SjekkLogIn(BestillingViewModel bruker)
        {
            Bruker nyBruker = new Bruker();
            nyBruker.e_postadresse = bruker.e_postadresse;
            nyBruker.passord = bruker.passord;
            using (var db = new DB())
            {
                try
                {
                    db.Bruker.Add(nyBruker);
                    db.SaveChanges();
                }
                catch (Exception e) {
                    System.Diagnostics.Debug.WriteLine("oppsie");
                }

                var perosner = db.Bruker.ToList();
                return View(perosner);
            }
               
            
        }
       
    }
}