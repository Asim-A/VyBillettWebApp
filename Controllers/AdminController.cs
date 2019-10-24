using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using VyBillettWebApp.Models;
using VyBillettWebApp.Models.Databasemodeller;

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
            List<Bruker> randomshit = new List<Bruker>();
            Bruker testshit = new Bruker();
            testshit.bruker_id = 100;
            testshit.dato = DateTime.Now;
            testshit.e_postadresse = "halla12@oslomet.com";
            testshit.passord = "weeb0";
            testshit.salt = "watashiva";
            randomshit.Add(testshit);
            
            using (var db = new DB()) {
                allesammen = db.Bruker.ToList();
            }


                if (IsValidEmail(bruker.e_postadresse)&& finsIDb(eAdresse))
                {
                    return logInBruker(eAdresse, ePassord);
                    

                }

                else {
                    System.Diagnostics.Debug.WriteLine("hvis email ikke er godkjent");
                    return View(randomshit);
                }
          
          
               
            
        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        static byte[] LagHashetPassord(string psd, byte[] salt) {
            byte[] passordIByte = Encoding.UTF8.GetBytes(psd);
            HashAlgorithm hasher = new SHA256Managed();
            byte[] psdOgSalt = new byte[psd.Length + salt.Length];
            for (int i = 0; i < psd.Length; i++) {
                psdOgSalt[i] = passordIByte[i];
            }
            for (int i = 0; i<salt.Length; i++)
            {
                psdOgSalt[psd.Length + i] = salt[i];
            }
            return hasher.ComputeHash(psdOgSalt);
        }
        static byte[] lagSalt() {
            var saltLengde = 7;
            var salt = new byte[saltLengde];
            using (var random = new RNGCryptoServiceProvider()) 
            {
                random.GetNonZeroBytes(salt);
            }
           // System.Diagnostics.Debug.WriteLine(salt);
            return salt;
        
        }
        static Bruker lagBruker(BestillingViewModel bruker, string passordIDb, string dbSalt) {
            Bruker nyBruker = new Bruker
            {
                e_postadresse = bruker.e_postadresse,
                passord = passordIDb,
                dato = DateTime.Now,
                salt = dbSalt

            };
            return nyBruker;
        }
        public ActionResult logInBruker(string eAdresse, string ePassord) {

            string salt;
            string passord;
            using (var db = new DB()) {
              
                    salt = (from bruker in db.Bruker where bruker.e_postadresse == eAdresse select bruker.salt).First();
                    byte[] saltIByte = Convert.FromBase64String(salt);
                    passord = Convert.ToBase64String(LagHashetPassord(ePassord, saltIByte));
                   

                    if (db.Bruker.Where(bruker => bruker.e_postadresse == eAdresse).Select(brukerpas => brukerpas.passord == passord).FirstOrDefault())
                    {
                        var test = (from brk in db.Bruker where brk.e_postadresse == eAdresse select brk.passord);
                        foreach (var v in test) {
                            System.Diagnostics.Debug.WriteLine(v.FirstOrDefault());
                        }
                        var personer = db.Bruker.ToList();
                        System.Diagnostics.Debug.WriteLine(test);
                        System.Diagnostics.Debug.WriteLine("logget inn");

                        return View("SjekkLogIn", personer);
                    }
                    else
                    {
                    List<Bruker> randomshit = new List<Bruker>();
                    Bruker testshit = new Bruker();
                    testshit.bruker_id = 99;
                    testshit.dato = DateTime.Now;
                    testshit.passord = "hahahhaha";
                    testshit.e_postadresse = "hahahhaa@oslomet.com";
                    testshit.salt = "hahhaha";

                        
                        System.Diagnostics.Debug.WriteLine("-----feil passord-----");
                        return View("logInBruker");
                    }  
                
                

            }
 
        }
        static void registrerBruker(BestillingViewModel bruker) {
            var saltForHash = lagSalt();
            var dbSalt = Convert.ToBase64String(saltForHash);
            var hashetPassordIDb = Convert.ToBase64String(LagHashetPassord(bruker.passord, saltForHash));
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
        public static bool finsIDb(string eAdresse) {
            using (var db = new DB()) {
                if (db.Bruker.Any(epos => epos.e_postadresse == eAdresse))
                {
                    return true;
                }
                else {
                    return false;
                }
                  
            }


        }



    }
}