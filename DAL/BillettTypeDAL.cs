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
    }
}
