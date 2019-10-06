using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VyBillettWebApp.Models;
using VyBillettWebApp.Models.Utillity;
using System.Web.Script.Serialization;


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

        public ActionResult Index_new()
        {
            return View();
        }

        public string ajaxtest()
        {
            System.Diagnostics.Debug.WriteLine(" ajaxtest ");
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize("AJAx \n det funka faen ikke med engang nei, men nå gjørre d");

        }
        
        public string ajaxtestinn(BestillingViewModel bestilling)
        {
            System.Diagnostics.Debug.WriteLine(" ajaxtestinn "+ bestilling.reise_dato);
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize("bestilling date "+bestilling.reise_dato);
        }

        [HttpPost]
        public ActionResult Index(BestillingViewModel bestilling)
        {         
            if (!(bestilling.antall_barn.HasValue || bestilling.antall_studenter.HasValue || bestilling.antall_voksne.HasValue))
            {
                return View();
            }
            List<Bestillinger> bestillinger_liste = new List<Bestillinger>();
            Bestillinger bestilling_utreise;
               Bestillinger bestilling_retur;
            if (ModelState.IsValid)
            {
                var md = new dbModellBygger();
                bestilling_utreise = md.BuildBestillingModells(bestilling, db);
                bestillinger_liste.Add(bestilling_utreise);

                if (bestilling.retur_dato.HasValue)
                {
                    String fra = bestilling.fra;
                    bestilling.fra = bestilling.til;
                    bestilling.til = fra;
                    bestilling.reise_dato = (DateTime) bestilling.retur_dato;
                    bestilling.reise_dato_tid = (DateTime) bestilling.retur_dato_tid;
                    bestilling_retur = md.BuildBestillingModells(bestilling, db);
                    bestillinger_liste.Add(bestilling_retur);

                }
            }

            int id = bestillinger_liste[0].bestilling_id;

            return RedirectToAction("Bestilling_detaljer", new { id = @id });
        }

        public ActionResult Bestilling_detaljer()
        {
            return View();
        }

        /*
        [HttpPost]
        public ActionResult Index(BestillingViewModel bestilling) {
            return RedirectToAction("LeggInnBestilling", bestilling);
        } 
        */

        [HttpGet]
        public ActionResult Liste()
        {
            using (var db = new DB())
            {
                var alleBilletter = db.Bestillinger.ToList();
                return View(alleBilletter);
            }
        }


    }
}