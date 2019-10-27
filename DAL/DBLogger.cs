using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBChangesLogger
    {
        
        public static void Log(string melding)
        {

            string filNavn = string.Format("{0}_{1}.log", "DBendringer", DateTime.Now.ToShortDateString());
            string loggBane = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, filNavn);
            System.Diagnostics.Debug.WriteLine("Logger i" + AppDomain.CurrentDomain.BaseDirectory + " " + filNavn);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("----------------------------------------");
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(melding);

            if (File.Exists(loggBane))
            {
                using (StreamWriter writer = new StreamWriter(loggBane, true))
                {
                    writer.Write(sb.ToString());
                    writer.Flush();
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(loggBane, false))
                {
                    writer.Write(sb.ToString());
                    writer.Flush();
                }
            }


        }
    }

   
}
