using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VyBillettWebApp.Models.Utillity
{
    public class MappingUtillity
    {

        readonly public static string DATETIME_FORMAT = "dd/MM/yyyy HH:mm:ss";
        
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

        public static string DateTimeNowToString()
        {
            return DateTimeToString(DateTime.Now);
        }

        public static string DateTimeToString(DateTime dateTime)
        {
            return dateTime.ToString();
        }
            
        public static DateTime DefaultStringToDateTime(String date) 
        {
                    return StringToDateTime(date, DATETIME_FORMAT);
        }

        public static DateTime StringToDateTime(String date, String dateFormatString) 
        {
            return DateTime.ParseExact(date, dateFormatString, null);
        }

        
    }
}