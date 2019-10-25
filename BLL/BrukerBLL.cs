using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class BrukerBLL
    {
        public bool IsValidEmail(string eAdresse)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(eAdresse);
                return addr.Address == eAdresse;
            }
            catch
            {
                return false;
            }
        }
        public Boolean eksistererBruker(string eAdresse) 
        {
            var brukerDAL = new BrukerDAL();
            return brukerDAL.eksistererBruker(eAdresse);
            

        }
        public bool validerBruker(string eAdresse, string ePassord)
        {
            var brukerdal = new BrukerDAL();

            byte[] salt = brukerdal.hentSalt(eAdresse);
            var passord = LagHashetPassord(ePassord, salt);
            return brukerdal.validerBruker(eAdresse, passord);

        }
        static byte[] LagHashetPassord(string psd, byte[] salt)
        {
            const int nøkkelLengde = 20;
            var hashPassord = new Rfc2898DeriveBytes(psd, salt, 50);

            return hashPassord.GetBytes(nøkkelLengde);
        }
        public bool registrerBruker(string eAdresse, string ePassord) 
        {
                var brukerdal = new BrukerDAL();

                var saltForHash = lagSalt();
                var dbSalt = Convert.ToBase64String(saltForHash);
                var hashetPassordIDb = LagHashetPassord(ePassord, saltForHash);
                Bruker nyBruker = new Bruker
            {
                e_postadresse = eAdresse,
                passord = hashetPassordIDb,
                dato = DateTime.Now,
                salt = dbSalt

            };
            return brukerdal.registrerBruker(nyBruker);
            

            

        }
        static byte[] lagSalt()
        {
            var saltLengde = 8;
            var salt = new byte[saltLengde];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }  
            return salt;
        }
    }
}
