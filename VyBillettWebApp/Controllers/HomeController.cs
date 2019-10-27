﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using System.Web.Script.Serialization;
using BLL;
using VyBillettWebApp.Models;
using Logger;


namespace VyBillettWebApp.Controllers
{
    
    public class HomeController : Controller
    {
        private ILogger _ILogger;
        public HomeController()
        {
            _ILogger = Logg.GetInstance;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            _ILogger.LoggFeil(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
        public ActionResult Index()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
            if (Session["LoggetInn"] == null)
            {
                
                Session["LoggetInn"] = false;
                ViewBag.InnLogget = false;
            }
            else {
              
                ViewBag.InnLogget = Session["LoggetInn"];
            }
            /*
            new Model.BillettType
            {
             billett_type
             

            }*/
           
           
            var bll = new BestillingBLL();
            List <Bestilling> bestillinger = bll.GetBestillinger();
            foreach(Bestilling b in bestillinger)
            {
                System.Diagnostics.Debug.WriteLine("id:      " + b.ID + "\nfra-til: " + b.fra+"-" + b.til+"\n"); 
            }
            return View();
        }

        public ActionResult Index_new()
        {
            return View();
        }        


        [HttpPost]
        public ActionResult Index(BestillingViewModel bestillingViewModel)
        {         
            if (!(bestillingViewModel.antall_barn.HasValue || bestillingViewModel.antall_studenter.HasValue || bestillingViewModel.antall_voksne.HasValue))
            {
                return View();
            }           
            List<Bestilling> bestillinger_liste = new List<Bestilling>();
            Bestilling bestilling;
            Boolean BestillingSattInn = false;
            if (ModelState.IsValid)
            {
                bestilling = TilDomeneModell(bestillingViewModel);
                var md = new BestillingBLL();
                BestillingSattInn = md.settInnBestilling(TilDomeneModell(bestillingViewModel));
                bestillinger_liste.Add(bestilling);
            }
            if (BestillingSattInn)
            {
                int id = bestillinger_liste[0].ID;
                return RedirectToAction("Bestilling_detaljer", new { id = @id });
            }
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

        public Bestilling TilDomeneModell(BestillingViewModel bestilling_VM)
        {
            DateTime kombinert_dato = bestilling_VM.reise_dato.Date.Add(bestilling_VM.reise_dato_tid.TimeOfDay);
            var bestilling = new Bestilling
            {
                fra = bestilling_VM.fra,
                til = bestilling_VM.til,
                reise_dato = kombinert_dato,
                bestilling_dato = DateTime.Now,
                
                billetter = new List<Billett>()
            };
            lagBilletter("Barn", bestilling_VM.antall_barn, bestilling);
            lagBilletter("Student", bestilling_VM.antall_studenter, bestilling);
            lagBilletter("Voksen", bestilling_VM.antall_voksne, bestilling);
            return bestilling;            
        }

        private void lagBilletter(String type, int? antall, Bestilling bestilling)
        {
            for (int counter = 0; counter < antall; counter++)
            {
                var billett = new Billett();
                billett.bestilling_id = bestilling.ID;
                billett.billett_type = type;
                bestilling.billetter.Add(billett);
            }
        }

        [HttpGet]
        public ActionResult Liste()
        {
            List<Bestilling> bestillinger = new BestillingBLL().GetBestillinger();
            return View(bestillinger);
        }
            /*
                if (bestillingViewModel.retur_dato.HasValue)
                {
                    String fra = bestillingViewModel.fra;
                    bestillingViewModel.fra = bestillingViewModel.til;
                    bestillingViewModel.til = fra;
                    bestillingViewModel.reise_dato = (DateTime) bestillingViewModel.retur_dato;
                    bestillingViewModel.reise_dato_tid = (DateTime) bestillingViewModel.retur_dato_tid;
                    bestilling_retur = md.settInnBestilling(bestillingViewModel);
                    bestillinger_liste.Add(bestilling_retur);*/
    }
}