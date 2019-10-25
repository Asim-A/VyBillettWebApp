using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using System.Web.Script.Serialization;
using BLL;
using VyBillettWebApp.Models;

namespace VyBillettWebApp.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var bll = new BestillingBLL();
            List <Bestilling> bestillinger = bll.GetBestillinger();
            foreach(Bestilling b in bestillinger)
            {
                System.Diagnostics.Debug.WriteLine(" id: " + b.ID + " \nfra-til: " + b.fra+"-" + b.til); 
            }
            return View();
        }

        public ActionResult Index_new()
        {
            return View();
        }        

        [HttpPost]
        public ActionResult Index(BestillingViewModel bestilling)
        {         
           /* if (!(bestilling.antall_barn.HasValue || bestilling.antall_studenter.HasValue || bestilling.antall_voksne.HasValue))
            {
                return View();
            }
            List<Bestillinger> bestillinger_liste = new List<Bestillinger>();
            Bestillinger bestilling_utreise;
               Bestillinger bestilling_retur;
            if (ModelState.IsValid)
            {
                var md = new BestillingBLL();
                bestilling_utreise = md.settInnBestilling(bestilling);
                bestillinger_liste.Add(bestilling_utreise);

                if (bestilling.retur_dato.HasValue)
                {
                    String fra = bestilling.fra;
                    bestilling.fra = bestilling.til;
                    bestilling.til = fra;
                    bestilling.reise_dato = (DateTime) bestilling.retur_dato;
                    bestilling.reise_dato_tid = (DateTime) bestilling.retur_dato_tid;
                    bestilling_retur = md.settInnBestilling(bestilling);
                    bestillinger_liste.Add(bestilling_retur);
                }
            }

            int id = bestillinger_liste[0].bestilling_id;*/

            return RedirectToAction("Bestilling_detaljer");
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
            return null;
        }


    }
}