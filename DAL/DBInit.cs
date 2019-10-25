using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DAL
{
    public class DBInit : CreateDatabaseIfNotExists<DB>
    {                                           
        protected override void Seed(DB context)
        {
            IList<Billett_type> defaultBillett_typer = new List<Billett_type>();
            defaultBillett_typer.Add(new Billett_type() { billett_type = "Barn", pris =30});
            defaultBillett_typer.Add(new Billett_type() { billett_type = "Student", pris = 60 });
            defaultBillett_typer.Add(new Billett_type() { billett_type = "Voksen", pris = 130 });

            IList<Bestillinger> defaultBestillinger = new List<Bestillinger>();
            var b = new Bestillinger()
            {
                bestilling_id = 1,
                fra = "Fetsund",
                til = "Oslo",
                bestilling_dato = DateTime.Now
            };
            b.billett_liste = new List<Billetter>();

            b.reise_dato = b.bestilling_dato.AddHours(1);

            var bil = new Billetter {
                bestilling_id = b.bestilling_id,
                billett_id = 2,
                billett_type = "Barn"
            };
            b.total_pris = 30;
            b.billett_liste.Add(bil);
            defaultBestillinger.Add(b);

            context.Bestillinger.Add(b);
            context.Billett_typer.AddRange(defaultBillett_typer);

            base.Seed(context);
        }
    }
}