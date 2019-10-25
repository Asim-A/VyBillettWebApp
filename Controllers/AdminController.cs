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
           
           
            
            using (var db = new DB()) {
                allesammen = db.Bruker.ToList();
            }


                if (IsValidEmail(bruker.e_postadresse)&& finsIDb(eAdresse))
                {
                    return logInBruker(eAdresse, ePassord);
                    

                }

                else {
                    System.Diagnostics.Debug.WriteLine("hvis email ikke er godkjent");
                    return View("logInBruker");
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
            const int nøkkelLengde = 20;
            var hashPassord = new Rfc2898DeriveBytes(psd, salt, 50);

            return hashPassord.GetBytes(nøkkelLengde);
        }
        static byte[] lagSalt() {
            var saltLengde = 8;
            var salt = new byte[saltLengde];
            using (var random = new RNGCryptoServiceProvider()) 
            {
                random.GetNonZeroBytes(salt);
            }
           // System.Diagnostics.Debug.WriteLine(salt);
            return salt;
        
        }
        static Bruker lagBruker(BestillingViewModel bruker, byte[] passordIDb, string dbSalt) {
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
            byte[] passord;
            using (var db = new DB()) {
                Bruker dbBrukerFunnet = db.Bruker.FirstOrDefault(brk => brk.e_postadresse == eAdresse);

                    salt = dbBrukerFunnet.salt;
                    byte[] saltIByte = Convert.FromBase64String(salt);
                   passord = LagHashetPassord(ePassord, saltIByte);
               

                    if (dbBrukerFunnet.passord.SequenceEqual(passord))
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
                    
                        
                        System.Diagnostics.Debug.WriteLine("-----feil passord-----");
                        return View("logInBruker");
                    }  
                
                

            }
 
        }
        static void registrerBruker(BestillingViewModel bruker) {
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