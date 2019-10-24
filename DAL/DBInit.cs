using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DAL
{
    public class DBInit : DropCreateDatabaseAlways<DB>
    {                                           
        protected override void Seed(DB context)
        {
            IList<Billett_type> defaultBillett_typer = new List<Billett_type>();
            defaultBillett_typer.Add(new Billett_type() { billett_type = "Barn", pris =30});
            defaultBillett_typer.Add(new Billett_type() { billett_type = "Student", pris = 60 });
            defaultBillett_typer.Add(new Billett_type() { billett_type = "Voksen", pris = 130 });

            context.Billett_typer.AddRange(defaultBillett_typer);

            base.Seed(context);
        }
    }
}