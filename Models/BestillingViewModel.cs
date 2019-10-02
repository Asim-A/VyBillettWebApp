using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VyBillettWebApp.Models
{
    public class BestillingViewModel
    {
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
        public int antall_vokse { get; set; }

        [Display(Name = "Reise dato")]
        public DateTime reise_dato_tid { get; set; }        //TODO 
        //skal vi bruke mapping utility her?


    }
}