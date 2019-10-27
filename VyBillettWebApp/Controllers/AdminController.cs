using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using VyBillettWebApp.Models;
using Model;
using BLL;
using Logger;
using System.Web.Script.Serialization;

namespace VyBillettWebApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        private ILogger _ILogger;
        public AdminController()
        {
            _ILogger = Logg.GetInstance;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            _ILogger.LoggFeil(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }

        [HttpPost]
        public ActionResult SjekkLogIn(BrukerViewModel bruker)
        {

            if(Session["LoggetInn"] != null)
            {
                RedirectToAction("admin_page_billett_typer");
            }

            var eAdresse = bruker.e_postadresse;
            var ePassord = bruker.passord;
            List<Bruker> allesammen;

            var brukerbll = new BrukerBLL();


            if (brukerbll.IsValidEmail(eAdresse) && brukerbll.eksistererBruker(eAdresse))
            {
                if (brukerbll.validerBruker(eAdresse, ePassord))
                {
                    // bruker har riktig passord og email
                    Session["LoggetInn"] = true;
                    ViewBag.InnLogget = true;
                    System.Diagnostics.Debug.WriteLine("riktig passord og bruker");
                    return RedirectToAction("admin_page_billett_typer");
                }
                else 
                {
                    Session["LoggetInn"] = false;
                    System.Diagnostics.Debug.WriteLine("riktig email feil passord");
                    // bruker har riktig email men feil passord
                    ViewBag.InnLogget = false;
                    
                    return View("../Home/Index");
                };
            }

            else
            {
                Session["LoggetInn"] = false;
                System.Diagnostics.Debug.WriteLine("bruker fins ikke");
                // bruker har enten tastet feil format eller så fins ikke denne brukeren
                ViewBag.InnLogget = false;
                return View("../Home/Index");
            }




        }
       
        public ActionResult admin_page_billett_typer()
        {

            var liste_billettTyper = new BillettTypeBLL().GetBillettTyper();

            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    return View(liste_billettTyper);
                }
                else
                {
                    return View("../Home/Index");
                }

            }
            return View("../Home/Index");
        }

        public ActionResult admin_page_bestillinger()
        {
            var liste_bestilling = new BestillingBLL().GetBestillinger();
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    return View(liste_bestilling);
                }
                else
                {
                    return View("../Home/Index");
                }

            }
            return View("../Home/Index");
        }


        //public ActionResult admin_page_billett_typer()
        //{
        //    var liste_billettTyper = new BillettTypeBLL().GetBillettTyper();
        //    System.Diagnostics.Debug.WriteLine("AHAHHAHAHA");
        //    return View(liste_billettTyper);
        //}


        public string get_billett_typer()
        {
            List<BillettType> liste_billett_typer = new BillettTypeBLL().GetBillettTyper();

            foreach (var i in liste_billett_typer)
            {
                System.Diagnostics.Debug.WriteLine("LOG: " + i.billett_type + " " + i.pris);
            }

            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(liste_billett_typer);
            System.Diagnostics.Debug.WriteLine(json);
            return json;
        }

        [HttpGet]
        public void slett_billett_type(string billett_type)
        {

            var btBLL = new BillettTypeBLL();
            if (btBLL.DeleteBillettType(billett_type)) { }
        }

        [HttpGet]
        public void slett_bestilling(int id)
        {
            var bll = new BestillingBLL();

            if (bll.slettBestilling(id)) {
                System.Diagnostics.Debug.WriteLine("============GÅR===========");
            }

        }

        [HttpPost]
        public void ny_billet_type(BillettType billettType)
        {
            var btBLL = new BillettTypeBLL();

            btBLL.NyBillettType(billettType);
        }

        [HttpPost]
        public void endre_billett_pris(BillettType endret_bt)
        {
            var btBLL = new BillettTypeBLL();
            if (btBLL.PatchBillettType(endret_bt))
            {
            }
        }


    }
}