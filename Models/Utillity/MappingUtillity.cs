using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VyBillettWebApp.Models.Utillity
{
    public class MappingUtillity
    {

        readonly public static double VOKSEN_MULTIPLIER = 13;

        public enum Billett_Type
        {
            BILLETT = 0,
            VOKSEN = 1,
            STUDENT = 2,
            BARN = 3,
            
        }
                
        readonly public static IDictionary<Billett_Type, int> billett_type_til_pris = new Dictionary<Billett_Type, int>()
        {
            {Billett_Type.VOKSEN, 130 },
            {Billett_Type.STUDENT, 60 },
            {Billett_Type.BARN, 30 }
        };

    
    }
}