using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBAPP.Models;

namespace WEBAPP.Controllers
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
        public ActionResult LeggInnBestilling(BestillingViewModel bestilling) {
           




            return null;
        }

    }
}