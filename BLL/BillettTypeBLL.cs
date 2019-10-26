using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BillettTypeBLL
    {

        public List<BillettType> GetBillett_Typer()
        {
            return new BillettTypeDAL().GetBillettTyper();
        }

        public Boolean SetBilletttyper(List<BillettType> BillettTyper)
        {
            return new BillettTypeDAL().SetBilletttyper(BillettTyper);
        }

    }
}
