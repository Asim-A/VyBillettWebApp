using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VyBillettWebApp.Models;
using VyBillettWebApp.Models.Utillity;
using System.Web.Script.Serialization;


namespace VyBillettWebApp.Controllers
{
    
    public class HomeController : Controller
    {
        private DB db = new DB();
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Index()
        {
          
            return View();
        }

        public string ajaxtest()
        {
            System.Diagnostics.Debug.WriteLine(" ajaxtest ");
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize("AJAx \n det funka faen ikke med engang nei, men nå gjørre d");

        }
        
        public string ajaxtestinn(BestillingViewModel bestilling)
        {
            System.Diagnostics.Debug.WriteLine(" ajaxtestinn "+ bestilling.reise_dato_tid);
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize("bestilling date "+bestilling.reise_dato_tid);
        }

        [HttpPost]
        public ActionResult Index(BestillingViewModel bestilling)
        {
            System.Diagnostics.Debug.WriteLine("LeggInnBestilling med innkunde");
            if (ModelState.IsValid)
            {
                var md = new dbModellBygger();
                md.BuildBestillingModells(bestilling, db);

            }
            ///////////for test
            string toSeachFor = "osloveiendenne";
            List<Bestillinger> bestillinger_liste = db.Bestillinger.ToList();
            IEnumerable<Bestillinger> match = bestillinger_liste.Where(x => x.fra.Equals(toSeachFor));
            foreach (Bestillinger b in match) {
                System.Diagnostics.Debug.WriteLine(" id " + b.bestilling_id);
                System.Diagnostics.Debug.WriteLine(" fra "+b.fra);
                System.Diagnostics.Debug.WriteLine(" til "+b.til); 
            }


            List<BestillingViewModel> TestListeBestillinger = db.Bestillinger.Select(b => new BestillingViewModel()
            {
                fra = b.fra,
                til = b.til,               
                antall_barn = b.billett_liste.Where(x => x.billett_type.Equals("Barn")).Count(),
                antall_studenter = b.billett_liste.Where(x => x.billett_type.Equals("Student")).Count(),
                antall_voksne = b.billett_liste.Where(x => x.billett_type.Equals("Voksen", StringComparison.InvariantCultureIgnoreCase)).ToList().Count(),
                reise_dato_tid = b.reise_dato
            }).ToList();

            foreach (var testshitmannen in TestListeBestillinger) {
                System.Diagnostics.Debug.WriteLine("============== nytt BestillingViewModel i TestListeBestillingerView ===============");
                System.Diagnostics.Debug.WriteLine(testshitmannen.fra); 
                System.Diagnostics.Debug.WriteLine(testshitmannen.til); 
                System.Diagnostics.Debug.WriteLine(testshitmannen.antall_barn); 
                System.Diagnostics.Debug.WriteLine(testshitmannen.antall_studenter);
                System.Diagnostics.Debug.WriteLine(testshitmannen.antall_voksne);
                System.Diagnostics.Debug.WriteLine(testshitmannen.reise_dato_tid); 
            }
            System.Diagnostics.Debug.WriteLine("============== TestListeBestillingerview antall elementer:  "+TestListeBestillinger.Count);

            List<Billetter> TestListebilletter = db.Billetter.ToList();
            System.Diagnostics.Debug.WriteLine("============== TestListeBilletter antall billetter"+ TestListebilletter.Count());
            foreach (var testshitmannen in TestListebilletter)
            {

                System.Diagnostics.Debug.WriteLine("============== nye billet i  TestListeBilletter ========");
                System.Diagnostics.Debug.WriteLine("Billett id  "+testshitmannen.billett_id);
                System.Diagnostics.Debug.WriteLine("bestilling id  "+testshitmannen.bestilling_id.bestilling_id);
                System.Diagnostics.Debug.WriteLine("Billett_type id  "+testshitmannen.billett_type);
            }

            List<Bestillinger> testListebBestillinger = db.Bestillinger.ToList();
            System.Diagnostics.Debug.WriteLine("==========*********** TestListebestillinger antall billetter" + TestListebilletter.Count());
            foreach (var testshitmannen in testListebBestillinger)
            {
                System.Diagnostics.Debug.WriteLine("==========****==== nye billet i  TestListeBilletter ========");
                System.Diagnostics.Debug.WriteLine("bestilling id  " + testshitmannen.bestilling_id);
                System.Diagnostics.Debug.WriteLine("bestilling fra  " + testshitmannen.fra);
                System.Diagnostics.Debug.WriteLine("bestilling Til  " + testshitmannen.til);
                System.Diagnostics.Debug.WriteLine("bestilling TOTALPRIS  " + testshitmannen.total_pris);
                System.Diagnostics.Debug.WriteLine("bestilling reise_dato  " + testshitmannen.reise_dato);
                System.Diagnostics.Debug.WriteLine("bestilling bestilling_dato  " + testshitmannen.bestilling_dato);
                System.Diagnostics.Debug.WriteLine("bestilling liste  " + testshitmannen.billett_liste.Count());

            }


            /////////////
            return View();
        }
        /*
        [HttpPost]
        public ActionResult Index(BestillingViewModel bestilling) {
            return RedirectToAction("LeggInnBestilling", bestilling);
        } 
        */

        [HttpGet]
        public ActionResult Liste()
        {
            using (var db = new DB())
            {
                var alleBilletter = db.Bestillinger.ToList();
                return View(alleBilletter);
            }
        }


    }
}