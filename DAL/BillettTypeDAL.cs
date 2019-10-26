using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class BillettTypeDAL
    {

        public List<BillettType> GetBillettTyper()
        {
            using (var db = new DB())
            {
                List<BillettType> list_billett_typer = db.Billett_typer.Select(element => new BillettType()
                {
                    billett_type = element.billett_type,
                    pris = element.pris
                }).ToList();

                return list_billett_typer;
            }
        }

        public bool SetBilletttyper(List<BillettType> billettTyper)
        {
            using (var db = new DB())
            {
                try
                {                    
                    foreach (var entity in db.Billett_typer)
                        db.Billett_typer.Remove(entity);

                    var list_billett_typer = new List<Billett_type>();

                    foreach (var billetttype in billettTyper)
                    {
                        list_billett_typer.Add(new Billett_type
                        {
                            billett_type = billetttype.billett_type,
                            pris = billetttype.pris
                        });
                    }
                    db.Billett_typer.AddRange(list_billett_typer);
                    db.SaveChanges();
                    return true;
                }  catch (Exception e)
                {
                    return false;
                }
            }
        }

        /* 
         * Tar inn BillettType, 
         * sjekker om pris er riktig verdi, 
         * sjekker om typen allerede eksisterer,
         * hvis prissjekken er ok typen ikke eksisterer legges den (nyBillettType) inn i Billett_typer tabellen
        */
        public Boolean NyBillettType(BillettType nyBillettType)
        {
            Boolean succeeded = false;

            if (checkValidPrisInput(nyBillettType.pris))
            {
                using (var db = new DB())
                {
                    Billett_type nyDatabaseBillettType = new Billett_type()
                    {
                        billett_type = nyBillettType.billett_type,
                        pris = nyBillettType.pris
                    };

                    if(!billettTypeExists(db, nyBillettType.billett_type))
                    {
                        db.Billett_typer.Add(nyDatabaseBillettType);
                        db.SaveChanges();
                        succeeded = true;
                    }

                }
            }

            return succeeded;
            
        }

        /*
         * Sjekker pris er ok
         * leter etter billett_type ved PK
         * hvis den eksisterer blir endringen gjort
         * 
        */ 
        public Boolean PatchBillettType(BillettType endretBillettType)
        {
            Boolean succeeded = false;


            if (checkValidPrisInput(endretBillettType.pris))
            { 
                using (var db = new DB())
                {
                    Billett_type currentItem = db.Billett_typer.Find(endretBillettType.billett_type);

                    if(currentItem != null)
                    {
                        currentItem.pris = endretBillettType.pris;
                        db.SaveChanges();
                        succeeded = true;
                    }
                    
                }
            }
            return succeeded;
        }

        /*
         * Sjekker pris er ok
         * sjekker om typen allerede eksisterer
         * hvis den eksisterer blir et nytt Billett_type objekt laget også brukes den for å fjerne
         * fra dbset-et.
         * 
        */
        public Boolean DeleteBillettType(BillettType slettetBillettType)
        {
            Boolean succeeded = false;

            using (var db = new DB())
            {
                if(!billettTypeExists(db, slettetBillettType.billett_type))
                {
                    Billett_type slettetDBBilettType = new Billett_type()
                    {
                        billett_type = slettetBillettType.billett_type,
                        pris = slettetBillettType.pris
                    };
                    db.Billett_typer.Remove(slettetDBBilettType);
                    db.SaveChanges();
                    succeeded = true;
                }
            }

            return succeeded;
        }

        // Hjelpemetode: pris tillates bare å være 1 eller høyere. Negative verdier er ikke lurt å ha.
        private Boolean checkValidPrisInput(Double pris)
        {
            return (pris < 1); 
        }

        // Hjelpemetode som 
        private Boolean billettTypeExists(DB entry, string inputType)
        {
            return entry.Billett_typer.Find(inputType) != null;
        }

    }
}
