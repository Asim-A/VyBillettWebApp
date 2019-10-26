using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    class Billett_TypeDAL
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
    }
}
