﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using Model;

namespace DAL
{   //Fra oppgave 1 
    public class dbModellBygger
    {
        public Boolean settInnBestilling(Bestilling bestilling)
        {
            var bestillinger = new Bestillinger
            {
                fra = bestilling.fra,
                til = bestilling.til,
                reise_dato = bestilling.reise_dato,
                retur_dato = bestilling.retur_dato,
                bestilling_dato = bestilling.bestilling_dato,
                total_pris = 0,
                billett_liste = new List<Billetter>()
            };

            var billetttyperDAL = new BillettTypeDAL();
            List<BillettType> billettTyper = billetttyperDAL.GetBillettTyper();
            foreach (Billett b in bestilling.billetter)
            {
                foreach(BillettType bt in billettTyper)
                {
                    if (bt.billett_type == b.billett_type)
                    {
                        bestillinger.total_pris += bt.pris;
                    }
                }                 
            }

            foreach (Billett b in bestilling.billetter){
                var billetter = new Billetter
                {
                    billett_id = b.billett_id,
                    bestilling_id = b.bestilling_id,
                    billett_type = b.billett_type
                };
                bestillinger.billett_liste.Add(billetter);
            }



            try
            {
                DB db = new DB();
                db.Database.Log = logInfo => DBChangesLogger.Log(logInfo);

                db.Bestillinger.Add(bestillinger);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                System.Diagnostics.Debug.WriteLine("feil");
                return false;
                System.Diagnostics.Debug.WriteLine("feil");
            }
        }
        /* 
         BestillingViewModel bestilling_VM;
         Bestillinger bestillinger;
         public Bestillinger settInnBestilling(BestillingViewModel bestilling)
         {

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

             bestillinger.total_pris = BeregnBestillingPris(bestilling);

             BuildBilletter("Barn", bestilling_VM.antall_barn);
             BuildBilletter("Student", bestilling_VM.antall_studenter);
             BuildBilletter("Voksen", bestilling_VM.antall_voksne);


             try
             {
                 DB db = new DB();
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
                 billett.bestilling_id = bestillinger.bestilling_id;
                 billett.billett_type = type;
                 bestillinger.billett_liste.Add(billett);
             }
         }              

         public static double BeregnBestillingPris(BestillingViewModel bestilling)
         {                           
             double total_pris = 0;
             using (var db = new DB()) { 
                 List<Billett_type> btListe = db.Billett_typer.ToList();
                 if (!(bestilling.antall_barn == null)) total_pris += btListe[0].pris * (double)bestilling.antall_barn;
                 if (!(bestilling.antall_studenter == null)) total_pris += btListe[1].pris * (double)bestilling.antall_studenter;
                 if (!(bestilling.antall_voksne == null)) total_pris += btListe[2].pris * (double)bestilling.antall_voksne;
             }
             return total_pris;
         }*/
    }
}