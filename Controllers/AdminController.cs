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
          
            if (IsValidEmail(bruker.e_postadresse))
            {
                using (var db = new DB()) {
                    if (db.Bruker.Any(epos => epos.e_postadresse == eAdresse))
                    {
                        System.Diagnostics.Debug.WriteLine("FANT BRUKER I DB");
                        logInBruker(eAdresse, ePassord);
                    }
                    else { System.Diagnostics.Debug.WriteLine("-----FANT IKKE----"); }
                    
                }

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

                        var personer = db.Bruker.ToList();
                        return View(personer);
                    }

            }

            else {
                return View(bruker);
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
        static void logInBruker(string eAdresse, string ePassord) {

            string salt;
            string passord;
            using (var db = new DB()) {
                if (db.Bruker.Any(epos => epos.e_postadresse == eAdresse))
                {
                    salt = (from bruker in db.Bruker where bruker.e_postadresse == eAdresse select bruker.salt).First();
                    byte[] saltIByte = Convert.FromBase64String(salt);
                    passord = Convert.ToBase64String(LagHashetPassord(ePassord, saltIByte));
                    if (db.Bruker.Where(bruker => bruker.e_postadresse == eAdresse).Select(brukerpas => brukerpas.passord == passord).First())
                    {
                        System.Diagnostics.Debug.WriteLine((from s in db.Bruker where s.e_postadresse == eAdresse select s.passord).FirstOrDefault());
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("------FUNKER IKKE FINNER IKKE PASSORD------");
                    }
                    System.Diagnostics.Debug.WriteLine("FANT BRUKER I DB");
                    logInBruker(eAdresse, ePassord);
                }
                else { System.Diagnostics.Debug.WriteLine("retunere view som ikke fant"); }
             

            }
            
            
            
            using (var db = new DB()) {
                
                if (db.Bruker.Where(bruker => bruker.e_postadresse == eAdresse).Select(brukerpas => brukerpas.passord == passord).First())
                {
                    System.Diagnostics.Debug.WriteLine((from s in db.Bruker where s.e_postadresse == eAdresse select s.passord).FirstOrDefault());
                }
                else {
                    System.Diagnostics.Debug.WriteLine("------FUNKER IKKE FINNER IKKE PASSORD------");
                }
            }

        }


    }
}