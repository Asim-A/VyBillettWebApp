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
            if (ModelState.IsValid)
            {
                //mener dette burde skje et annet sted + må behandle dato.
                System.Diagnostics.Debug.WriteLine("ActionResult registrer med innkunde");
                var b = new Bestillinger();
                b.fra = bestilling.fra;
                b.til = bestilling.til;
                b.reise_dato = bestilling.reise_dato_tid;
                b.bestilling_dato = DateTime.Now;

            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(BestillingViewModel bestilling) {
            return RedirectToAction("LeggInnBestilling", bestilling);
        }
    }
}