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
                try
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

                    return BestillingerListe;
                } catch (Exception e)
                {
                    return null;
                }
            }
        }
        
        public Bestilling GetBestilling(int id)
        {            
            using (var db = new DB())
            {
               
                Bestillinger bestillinger = db.Bestillinger.Find(id);
                if (bestillinger == null)
                {
                    return null;
                }
                var Bestilling = new Bestilling
                {
                    ID = bestillinger.bestilling_id,
                    fra = bestillinger.fra,
                    til = bestillinger.til,
                    reise_dato = bestillinger.reise_dato,
                    retur_dato = bestillinger.retur_dato,
                    bestilling_dato = bestillinger.bestilling_dato
                };
                return Bestilling;                              
            }
        }

        public bool slettBestilling(int id)
        {
            using (var db = new DB())
            {
                
                try
                {
                    db.Database.Log = logInfo => DBChangesLogger.Log(logInfo);
                    Bestillinger bestillinger = db.Bestillinger.Find(id);
                    foreach(Billetter billett in bestillinger.billett_liste)
                    {
                        db.Billetter.Remove(billett);
                    }
                    db.Bestillinger.Remove(bestillinger);
                    db.SaveChanges();
                    db.Database.Log = Console.Write;
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }


       
    }
}
