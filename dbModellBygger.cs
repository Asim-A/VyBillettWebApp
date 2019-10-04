﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VyBillettWebApp.Models;
using VyBillettWebApp.Models.Utillity;

namespace VyBillettWebApp
{
    public class dbModellBygger
    {

        BestillingViewModel bestilling_VM;
        Bestillinger bestillinger;
        internal void BuildBestillingModells(BestillingViewModel bestilling, DB db)
        {
            bestilling_VM = bestilling;
            bestillinger = new Bestillinger
            {
                fra = bestilling_VM.fra,
                til = bestilling_VM.til,
                reise_dato = bestilling_VM.reise_dato_tid,
                bestilling_dato = DateTime.Now,
                total_pris = 0,
                billett_liste = new List<Billetter>()
            };
            BuildBilletter("Barn", bestilling_VM.antall_barn);
            BuildBilletter("Student", bestilling_VM.antall_studenter);
            BuildBilletter("Voksen", bestilling_VM.antall_voksne);
            BeregnBestillingPris();
               
            try
            {
                db.Bestillinger.Add(bestillinger);
                db.SaveChanges();
            }
            catch (Exception feil)
            {              
                System.Diagnostics.Debug.WriteLine("feil");
            }          
        }       

        private void BuildBilletter(String type, int antall)
        {
            for (int counter = 0; counter < antall; counter++)
            {
                var billett = new Billetter();
                billett.bestilling_id = bestillinger;
                billett.billett_type = type;
                bestillinger.billett_liste.Add(billett);
            }
        }

        private void BeregnBestillingPris()
        {
            foreach (Billetter b in bestillinger.billett_liste)
            {
                bestillinger.total_pris = bestillinger.total_pris + MappingUtillity.getBillettPris(b.billett_type);
            }
        }
    }
}