using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BrukerDALStub
    {
        List<Bruker> brukerListe = new List<Bruker>();
        Bruker bruker = new Bruker()
        {
            e_postadresse = "tester2@oslomet.com",
            passord = Encoding.Default.GetBytes("à0m$¼ñk²Çü‰¯?œ¥|fèŠ")
        };
        


        public Boolean eksistererBruker(string eAdresse)
        {
            brukerListe.Add(bruker);
            if(brukerListe.Any(p => p.e_postadresse == eAdresse))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public byte[] hentSalt(string eAdresse)
        {
            string salt;
            byte[] saltIByte;

            Bruker dbBrukerFunnet = brukerListe.FirstOrDefault(p => p.e_postadresse == eAdresse);

            salt = dbBrukerFunnet.salt;
            saltIByte = Convert.FromBase64String(salt);

            return saltIByte;
        }

        public bool validerBruker(string eAdresse, byte[] ePassord)
        {
            Bruker dbBrukerFunnet = brukerListe.FirstOrDefault(brk => brk.e_postadresse == eAdresse);

            if (dbBrukerFunnet.passord.SequenceEqual(ePassord))
            {


                return true;
            }
            else
            {


                return false;
            }
        }

        public bool registrerBruker(Bruker bruker)
        {
            
           
            brukerListe.Add(bruker);
                    
           
            return true;
        }
    }
}
