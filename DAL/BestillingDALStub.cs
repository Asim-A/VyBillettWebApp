using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class BestillingDALStub : DAL.IBestillingDAL
    {
        public List<Bestilling> GetBestillinger()
        {

            List<Bestilling> BestillingListe = new List<Bestilling>();
            var b = new Bestilling()
            {
                bestilling_id = 0,
                fra = "Fetsund",
                til = "Oslo",
                bestilling_dato = DateTime.Now
            };
            b.billett_liste = new List<Billetter>();

            b.reise_dato = b.bestilling_dato.AddHours(1);

            var b2 = new Bestilling()
            {
                bestilling_id = 0,
                fra = "Fetsund",
                til = "Oslo",
                bestilling_dato = DateTime.Now
            };
            b.billett_liste = new List<Billetter>();

            b.reise_dato = b.bestilling_dato.AddHours(1);

            List<Billett> billettListe = new List<Billett>();

            var bil = new Billett
            {
                bestilling_id = b.bestilling_id,
                billett_id = 0,
                billett_type = "Barn"
            };
            b.total_pris = 30;
            b.billetter.Add(bil);
            BestillingListe.Add(b);
            BestillingListe.Add(b2);
            billettListe.Add(bil);


                return BestillingListe;
            }
        }


        public Bestilling GetBestilling(int id)
        {
        if (id == 0)
        {
            var b = new Bestilling();
            b.ID = 0;
            return b;
        }
        else
        {
            var bestilling = new Bestilling()
            {
                bestilling_id = 0,
                fra = "Fetsund",
                til = "Oslo",
                bestilling_dato = DateTime.Now
            };
            bestilling.billetter = new List<Billetter>();

            bestilling.reise_dato = bestilling.reise_dato.AddHours(1);
        
            return bestilling;
        }
    }

        public bool slettBestilling(int id)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
