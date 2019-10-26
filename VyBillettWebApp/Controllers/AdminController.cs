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

namespace VyBillettWebApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpPost]
        public ActionResult SjekkLogIn(BestillingViewModel bruker)
        {
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
                    System.Diagnostics.Debug.WriteLine("riktig passord og bruker");
                    return View("../Home/admin_page_billett_typer");
                }
                else 
                {
                    Session["LoggetInn"] = false;
                    System.Diagnostics.Debug.WriteLine("riktig email feil passord");
                    // bruker har riktig email men feil passord
                    bruker.loginErrorMessage = "feil passord";
                    
                    return View("../Home/Index", bruker);
                };
            }

            else
            {
                Session["LoggetInn"] = false;
                System.Diagnostics.Debug.WriteLine("bruker fins ikke");
                // bruker har enten tastet feil format eller så fins ikke denne brukeren
              
                return View("../Home/Index");
            }




        }
       


    }
}