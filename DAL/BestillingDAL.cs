using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    //Metodene fungerer ved å aksessere databasen for å hente ut datamodellene. Deretter Konverteres datamodellene til domene modellene og disse returneres.
    public class BestillingDAL
    {
        public List<Bestilling> GetBestillinger()
        {
            using (var db = new DB())
            {
                List<Bestilling> BestillingerListe = db.Bestillinger.Select(b => new Bestilling()
                {
                    ID = b.bestilling_id,
                    fra = b.fra,
                    til = b.til,
                    reise_dato = b.reise_dato,
                    retur_dato = b.retur_dato,
                    bestilling_dato = b.bestilling_dato
                }).ToList();



                //TEST///
                System.Diagnostics.Debug.WriteLine("Billetter på bestillling før");
                foreach (Bestilling b in BestillingerListe)
                {
                    if (b.billetter != null)
                        System.Diagnostics.Debug.WriteLine("Liste størrelse " + b.billetter.Count);
                    else
                        System.Diagnostics.Debug.WriteLine("liste ikke instansiert");

                }
                ///TEST//


                List<Billett> billetter = db.Billetter.Select(b => new Billett()
                {
                    billett_id = b.billett_id,
                    bestilling_id = b.bestilling_id,
                    billett_type = b.billett_type
                }).ToList();

                foreach (Billett b in billetter)
                {
                    /*   b.pris = db.Billett_typer.Select(bt => bt.pris).Where(bt.);*/
                    var pris = from bt in db.Billett_typer
                               where bt.billett_type.Equals(b.billett_type)
                               select bt.pris;
                    b.pris = pris.FirstOrDefault();
                }

                foreach (Bestilling bes in BestillingerListe)
                {
                    bes.billetter = new List<Billett>();
                    foreach (Billett bil in billetter)
                    {
                        if (bil.bestilling_id == bes.ID)
                        {
                            bes.billetter.Add(bil);
                        }
                    }
                }

                ///TEST
                System.Diagnostics.Debug.WriteLine("Billetter på bestillling etter");
                foreach (Bestilling b in BestillingerListe)
                {
                    System.Diagnostics.Debug.WriteLine("Liste størrelse " + b.billetter.Count);
                }
                db.SaveChanges();
                ///TEST              
                return BestillingerListe;
            }
        }


       
    }
}
