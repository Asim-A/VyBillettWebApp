using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;

namespace DAL
{
    public class DBInit : CreateDatabaseIfNotExists<DB>
    {                                           
        protected override void Seed(DB context)
        {
            Bruker testbruker = new Bruker()
            {
                bruker_id = 10,
                dato = DateTime.Now,
                e_postadresse = "tester1@oslomet.com",
                passord = Encoding.Default.GetBytes("à0m$¼ñk²Çü‰¯?œ¥|fèŠ"),
                salt = "JQNyws7BdxU="


            };
            IList<Billett_type> defaultBillett_typer = new List<Billett_type>();
            defaultBillett_typer.Add(new Billett_type() { billett_type = "Barn", pris =30});
            defaultBillett_typer.Add(new Billett_type() { billett_type = "Student", pris = 60 });
            defaultBillett_typer.Add(new Billett_type() { billett_type = "Voksen", pris = 130 });

            IList<Bestillinger> defaultBestillinger = new List<Bestillinger>();
            var b = new Bestillinger()
            {
                bestilling_id = 0,
                fra = "Fetsund",
                til = "Oslo",
                bestilling_dato = DateTime.Now
            };
            b.billett_liste = new List<Billetter>();

            b.reise_dato = b.bestilling_dato.AddHours(1);

            var bil = new Billetter {
                bestilling_id = b.bestilling_id,
                billett_id = 0,
                billett_type = "Barn"
            };
            b.total_pris = 30;
            b.billett_liste.Add(bil);
            defaultBestillinger.Add(b);

            context.Bestillinger.Add(b);
            context.Billett_typer.AddRange(defaultBillett_typer);
            context.Bruker.Add(testbruker);

            base.Seed(context);
        }
    }
}