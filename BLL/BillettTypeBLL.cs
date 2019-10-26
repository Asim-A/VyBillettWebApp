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

        public List<BillettType> GetBillettTyper()
        {
            return new BillettTypeDAL().GetBillettTyper();
        }

        public Boolean SetBilletttyper(List<BillettType> BillettTyper)
        {
            return new BillettTypeDAL().SetBilletttyper(BillettTyper);
        }

        public Boolean SetBillettType(BillettType nyBillettType)
        {
            return new BillettTypeDAL().NyBillettType(nyBillettType);
        }

        public Boolean PatchBillettType(BillettType endretBillettType)
        {
            return new BillettTypeDAL().PatchBillettType(endretBillettType);
        }

        public Boolean DeleteBillettType(BillettType slettetBillettType)
        {
            return new BillettTypeDAL().DeleteBillettType(slettetBillettType);
        }

    }
}
