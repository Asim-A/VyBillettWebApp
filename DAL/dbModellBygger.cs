using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using Model;

namespace DAL
{
    public class dbModellBygger
    {

        BestillingViewModel bestilling_VM;
        Bestillinger bestillinger;
        public Bestillinger settInnBestilling(BestillingViewModel bestilling)
        {
            DB db = new DB();
            bestilling_VM = bestilling;
            DateTime kombinert_dato = 
                bestilling_VM.reise_dato.Date.Add(bestilling_VM.reise_dato_tid.TimeOfDay);
            

            bestillinger = new Bestillinger
            {
                fra = bestilling_VM.fra,
                til = bestilling_VM.til,
                reise_dato = kombinert_dato,
                
                bestilling_dato = DateTime.Now,
                total_pris = 0,
                billett_liste = new List<Billetter>()
            };
            BuildBilletter("Barn", bestilling_VM.antall_barn);
            BuildBilletter("Student", bestilling_VM.antall_studenter);
            BuildBilletter("Voksen", bestilling_VM.antall_voksne);
            bestillinger.total_pris = MappingUtillity.BeregnBestillingPris(bestillinger);
            
            try
            {
                db.Bestillinger.Add(bestillinger);
                db.SaveChanges();
                return bestillinger;
            }
            catch (Exception feil)
            {
                return null;
                System.Diagnostics.Debug.WriteLine("feil");
            }          
        }       

        private void BuildBilletter(String type, int? antall)
        {
            for (int counter = 0; counter < antall; counter++)
            {
                var billett = new Billetter();
                billett.bestilling_id = bestillinger;
                billett.billett_type = type;
                bestillinger.billett_liste.Add(billett);
            }
        }
    }
}