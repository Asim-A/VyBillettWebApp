using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// Klasser under "Logiskemodeller" mappen er "smarte" modeller som vi har tenkt til å bruker
/// til senere oppgaver, akkurat nå har de ingen funksjon og er der bare for videreutvikling og struktur
/// </summary>
namespace VyBillettWebApp.Models
{
    public abstract class Billett
    {
        public int BillettId { get; set; }
        public string strekning { get; set; }
        public string dato { get; set; }
    }
}