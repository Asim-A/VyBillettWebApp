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
          
            return View();
        }

        public ActionResult LeggInnBestilling(BestillingViewModel bestilling)
        {
            System.Diagnostics.Debug.WriteLine("LeggInnBestilling med innkunde");
            if (ModelState.IsValid)
            {
                var md = new ModellBuilder();
                md.BuildBestillingModells(bestilling, db);
               
            }
            ///////////for test
            List<BestillingViewModel> TestListeBestillinger = db.Bestillinger.Select(b => new BestillingViewModel()
            {
                fra = b.fra,
                til = b.til,
                reise_dato_tid = b.reise_dato                
            }).ToList();                            
            System.Diagnostics.Debug.WriteLine("fitte i helvete kukk system  "+TestListeBestillinger[0].fra);
            System.Diagnostics.Debug.WriteLine("fitte i helvete kukk system  ANTALL" + TestListeBestillinger.Count);

            /////////////
            return View();
        }

        [HttpPost]
        public ActionResult Index(BestillingViewModel bestilling) {
            return RedirectToAction("LeggInnBestilling", bestilling);
        }
    }
}