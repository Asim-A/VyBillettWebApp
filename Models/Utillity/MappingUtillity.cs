using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VyBillettWebApp.Models.Utillity
{
    public class MappingUtillity
    {

        readonly public static string DATETIME_FORMAT = "dd/MM/yyyy HH:mm:ss";
        readonly public static IDictionary<string, double> billett_type_til_pris = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
        {
            {"VOKSEN", 130 },
            {"STUDENT", 60 },
            {"BARN", 30 }
        };

        public static double getBillettPris(string billettType) {
            double pris;
            if (!billett_type_til_pris.TryGetValue(billettType, out pris))
            {
                throw new Exception("Billettype Er Ikke Registrert i Systemet ");            
            }
            return pris;
        }
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