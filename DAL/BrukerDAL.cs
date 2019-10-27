using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class BrukerDAL
    {
        public Boolean eksistererBruker(string eAdresse) {

            using (var db = new DB())
            {
                if (db.Bruker.Any(epos => epos.e_postadresse == eAdresse))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        public byte[] hentSalt(string eAdresse)
        {
            string salt;
            byte[] saltIByte;
            using (var db = new DB())
            {
                db.Database.Log = logInfo => DBChangesLogger.Log(logInfo);

                Bruker dbBrukerFunnet = db.Bruker.FirstOrDefault(brk => brk.e_postadresse == eAdresse);

                salt = dbBrukerFunnet.salt;
                saltIByte = Convert.FromBase64String(salt);
            }
            return saltIByte;
            
        }
        public bool validerBruker(string eAdresse, byte[] ePassord) {

            using (var db = new DB())
            {
                Bruker dbBrukerFunnet = db.Bruker.FirstOrDefault(brk => brk.e_postadresse == eAdresse);

                if (dbBrukerFunnet.passord.SequenceEqual(ePassord))
                {

                    
                    return true;
                }
                else
                {


                    return false;
                }



            }

        }

        public BrukerDAL()
        {
        }
        public bool registrerBruker(Bruker bruker) 
        {
            using (var db = new DB())
            {
                try
                {
                    db.Database.Log = logInfo => DBChangesLogger.Log(logInfo);

                    db.Bruker.Add(bruker);
                    db.SaveChanges();
                    

                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("her kan det skrives til fil kanskje også");
                }
                return true;

            }
            
        }
    }
}
