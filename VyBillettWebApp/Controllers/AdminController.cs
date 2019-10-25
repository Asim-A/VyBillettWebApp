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
                    return View();
                }
                else 
                {
                    // bruker har riktig email men feil passord
                    return View();
                };
            }

            else
            {
                // bruker har enten tastet feil format eller så fins ikke denne brukeren
               return View();
            }




        }
       


    }
}