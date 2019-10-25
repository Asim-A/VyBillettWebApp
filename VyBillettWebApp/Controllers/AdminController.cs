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
       
     
       
        static Bruker lagBruker(BestillingViewModel bruker, byte[] passordIDb, string dbSalt)
        {
            Bruker nyBruker = new Bruker
            {
                e_postadresse = bruker.e_postadresse,
                passord = passordIDb,
                dato = DateTime.Now,
                salt = dbSalt

            };
            return nyBruker;
        }
        public ActionResult logInBruker(string eAdresse, string ePassord)
        {

            string salt;
            byte[] passord;
            using (var db = new DB())
            {
                Bruker dbBrukerFunnet = db.Bruker.FirstOrDefault(brk => brk.e_postadresse == eAdresse);

                salt = dbBrukerFunnet.salt;
                byte[] saltIByte = Convert.FromBase64String(salt);
                passord = LagHashetPassord(ePassord, saltIByte);


                if (dbBrukerFunnet.passord.SequenceEqual(passord))
                {
                    var test = (from brk in db.Bruker where brk.e_postadresse == eAdresse select brk.passord);
                    foreach (var v in test)
                    {
                        System.Diagnostics.Debug.WriteLine(v.FirstOrDefault());
                    }
                    var personer = db.Bruker.ToList();
                    System.Diagnostics.Debug.WriteLine(test);
                    System.Diagnostics.Debug.WriteLine("logget inn");

                    return View("SjekkLogIn", personer);
                }
                else
                {


                    System.Diagnostics.Debug.WriteLine("-----feil passord-----");
                    return View("logInBruker");
                }



            }

        }
        static void registrerBruker(BestillingViewModel bruker)
        {
            var saltForHash = lagSalt();
            var dbSalt = Convert.ToBase64String(saltForHash);
            var hashetPassordIDb = LagHashetPassord(bruker.passord, saltForHash);
            Bruker nyBruker = lagBruker(bruker, hashetPassordIDb, dbSalt);
            using (var db = new DB())
            {
                try
                {
                    db.Bruker.Add(nyBruker);
                    db.SaveChanges();

                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("her kan det skrives til fil kanskje også");
                }

            }

        }
        



    }
}