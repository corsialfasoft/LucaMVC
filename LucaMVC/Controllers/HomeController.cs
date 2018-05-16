using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LucaMVC.Models;
using DataTransferObjects;

namespace LucaMVC.Controllers {
	public class HomeController : Controller {
		public ActionResult Index() {
			return View();
		}

		public ActionResult About() {
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact() {
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult Dettagli(int i, DTMenu menu) {
			if ( i == 1 ) {
				ViewBag.data = DateTime.Today.ToString("dd/MM/yyyy");
				ViewBag.pasto = "pranzo";
				ViewBag.Message = "Dettagli del pranzo";
				ViewBag.p_primo = "pasta";
				ViewBag.p_secondo = "carne";
				ViewBag.p_contorno = "pomodori";
				ViewBag.p_dolce = "frutta";
				return View("Dettaglio");
			} else if (i == 2) {
				ViewBag.data = DateTime.Today.ToString("dd/MM/yyyy");
				ViewBag.pasto = "cena";
				ViewBag.Message = "Dettagli della cena";
				ViewBag.c_primo = "minestra";
				ViewBag.c_secondo = "pesce";
				ViewBag.c_contorno = "fagiolini";
				ViewBag.c_dolce = "budino";
				return View("Dettaglio");
			}
			return View("Dettaglio");
		}

		[HttpPost]
		public ActionResult Dettaglio(DateTime data) {
			DomainModel dm = new DomainModel();
			List<DTMenu> liMen = dm.ListaDeiMenu(data);
			ViewBag.ListeMenu = liMen;
			return View("Dettaglio");
		}

		public ActionResult Menu() {
			ViewBag.Message = "Inserisci il menù pranzo/cena";
			return View("Menu");
		}

		[HttpPost]
		public ActionResult Menu(DateTime date, string pasto, string primo, string secondo, string contorno, string dolce) {
			ViewBag.Message = $"Hai inserito il seguente menù";

			//ViewBag.data = date;
			//ViewBag.pasto = pasto;
			//ViewBag.primo = primo ;
			//ViewBag.secondo = secondo;
			//ViewBag.contorno = contorno;
			//ViewBag.dolce = dolce;

			List<DTPrimo> listaPrimi =new List<DTPrimo> () { { new DTPrimo(primo) } };
			List<DTSecondo> listaSecondi = new List<DTSecondo> () { { new DTSecondo(secondo) } };
			List<DTContorno> listaContorni = new List<DTContorno> () { { new DTContorno(contorno) } };
			List<DTDolce> listaDolci = new List<DTDolce>() { { new DTDolce(dolce) } };
			DTMenu dtM;
			if ( pasto == "pranzo" ) {
				dtM = new DTMenu(date, 0, listaPrimi, listaSecondi, listaContorni, listaDolci);
			} else if (pasto == "cena") {
				dtM = new DTMenu(date, 1, listaPrimi, listaSecondi, listaContorni, listaDolci);
			} else {
				throw new Exception("Tipologia del menù (pranzo / cena) errata!");
			}
			DomainModel dm = new DomainModel();
			dm.AddMenu (dtM);
			ViewBag.Menu = dtM;
			return View("Menu");
		}
				
		public ActionResult Giorno() {
			ViewBag.Message = $"Riferimenti ai dettagli di pranzo e cena";			
			ViewBag.data = DateTime.Today.ToString("dd/MM/yyyy");

			//ViewBag.p_primo = "pasta";
			//ViewBag.p_secondo = "carne";
			//ViewBag.p_contorno = "pomodori";
			//ViewBag.p_dolce = "frutta";

			//ViewBag.c_primo = "minestra";
			//ViewBag.c_secondo = "pesce";
			//ViewBag.c_contorno = "fagiolini";
			//ViewBag.c_dolce = "budino";

			DomainModel dm = new DomainModel();
			//dm.Giornata(DateTime.Today);
			return View("Giorno");
		}

		[HttpPost]
		public ActionResult Giorni(DateTime dateTime, string tipoMenu) {
			ViewBag.Message = $"Riferimenti ai dettagli di pranzo e cena";
			//ViewBag.data = DateTime.Today.ToString("dd/MM/yyyy");

			//ViewBag.p_primo = "pasta";
			//ViewBag.p_secondo = "carne";
			//ViewBag.p_contorno = "pomodori";
			//ViewBag.p_dolce = "frutta";

			//ViewBag.c_primo = "minestra";
			//ViewBag.c_secondo = "pesce";
			//ViewBag.c_contorno = "fagiolini";
			//ViewBag.c_dolce = "budino";

			DomainModel dm = new DomainModel();
			//dm.Giornata(DateTime.Today);
			List<DTMenu> li_menu = dm.ListaDeiMenu(dateTime);
			ViewBag.ListeMenu = li_menu;
			return View("Dettaglio?data=dateTime");
		}
	}
}