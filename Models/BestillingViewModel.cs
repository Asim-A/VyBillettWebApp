using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VyBillettWebApp.Models
{
    public class BestillingViewModel
    {
        public string Dato { get; set; }
        public List<Billett> liste_billetter { get; set; }

        // dette er både en domenemodell og en view-modell
        public int id { get; set; }

        [Display(Name = "Fra")]
        [Required(ErrorMessage = "Du må velge hvor du skal reise fra")]
        public string fra { get; set; }

        [Display(Name = "Til")]
        [Required(ErrorMessage = "Du må velge hvor du skal reise til")]
        public string til { get; set; }

        [Display(Name = "Antall Barn")]
        public int antall_barn { get; set; }

        [Display(Name = "Antall Studenter")]
        public int antall_studenter { get; set; }

        [Display(Name = "Antall Vokse")]
        public string antall_vokse { get; set; }

        [Display(Name = "Reise dato")]
        [Required(ErrorMessage = "Poststed må oppgis")]
        public string reise_dato_tid { get; set; }
    }
}