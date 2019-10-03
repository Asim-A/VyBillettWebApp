using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VyBillettWebApp.Models;

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

        [HttpPost]
        public ActionResult Index(BestillingViewModel bestilling) {


            return RedirectToAction("LeggInnBestilling", bestilling);
        }

        public ActionResult LeggInnBestilling(BestillingViewModel bestilling)
        {
            return View(bestilling);
        }

    }
}