using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public sealed class Logg : ILogger
    {
        private Logg() { }

        private static readonly Lazy<Logg> instance = new Lazy<Logg>(() => new Logg());

        public static Logg GetInstance
        {
            get
            {
                return instance.Value;
            }
        }
        public void LoggFeil(string melding)
        {
            string filNavn = string.Format("{0}_{1}.log", "Feil", DateTime.Now.ToShortDateString());
            string loggBane = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, filNavn);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(melding);
            using(StreamWriter writer = new StreamWriter(loggBane, true))
            {
                writer.Write(sb.ToString());
                writer.Flush();
            }
        }
    }
}
