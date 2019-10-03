﻿using System;
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
        public ActionResult index(BestillingViewModel bestilling) {
            if (ModelState.IsValid)
            {
                var b = new Bestillinger();
                b.fra = bestilling.fra;
                b.til = bestilling.til;
                b.reise_dato = bestilling.reise_dato_tid;
                b.bestilling_dato = DateTime.Now;
             
            }
            return View();

        }
    }
}