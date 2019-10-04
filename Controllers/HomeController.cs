using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VyBillettWebApp.Models;
using VyBillettWebApp.Models.Utillity;

namespace VyBillettWebApp.Controllers
{
    
    public class HomeController : Controller
    {
        private DB db = new DB();
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Index()
        {
            List<BestillingViewModel> TestListeBestillinger = db.Bestillinger.Select(b => new BestillingViewModel()
            {
                fra = b.fra,
                til = b.til,
                reise_dato_tid = b.reise_dato,
                antall_voksne = b.billett_liste.Count
            }).ToList();
            foreach (var testshitmannen in TestListeBestillinger)
            {
                System.Diagnostics.Debug.WriteLine(testshitmannen.fra);
                System.Diagnostics.Debug.WriteLine(testshitmannen.til);
                System.Diagnostics.Debug.WriteLine(testshitmannen.antall_barn);
                System.Diagnostics.Debug.WriteLine(testshitmannen.antall_studenter);
                System.Diagnostics.Debug.WriteLine(testshitmannen.antall_voksne);
                System.Diagnostics.Debug.WriteLine(testshitmannen.reise_dato_tid);
               
            }

            return View();
        }

        public ActionResult LeggInnBestilling(BestillingViewModel bestilling)
        {
            System.Diagnostics.Debug.WriteLine("LeggInnBestilling med innkunde");
            if (ModelState.IsValid)
            {
                var md = new dbModellBygger();
                md.BuildBestillingModells(bestilling, db);
               
            }
            ///////////for test
            
            
            




            /////////////
            return View();
        }

        [HttpPost]
        public ActionResult Index(BestillingViewModel bestilling) {
            return RedirectToAction("LeggInnBestilling", bestilling);
        }
    }
}