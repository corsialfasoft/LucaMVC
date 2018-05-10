using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LucaMVC.Models;

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

		public ActionResult Pasto() {
			ViewBag.Message = "Inserisci il menù pranzo/cena";
			return View("Pasto");
		}

		[HttpPost]
		public ActionResult Pasto(DateTime date, string pasto, string primo, string secondo, string contorno, string dolce) {
			ViewBag.Message = $"Inserisci il {pasto}";
			ViewBag.data = date;
			ViewBag.pasto = pasto;
			ViewBag.primo = primo ;
			ViewBag.secondo = secondo;
			ViewBag.contorno = contorno;
			ViewBag.dolce = dolce;
			DomainModel dm = new DomainModel();
			dm.AddPasto(date, pasto, primo, secondo, contorno, dolce);
			return View("Pasto");
		}
				
		public ActionResult Giorno() {
			ViewBag.Message = $"Inserisci {DateTime.Today.ToString("dd/MM/yyyy")}";			
			ViewBag.data = DateTime.Today.ToString("dd/MM/yyyy");

			ViewBag.p_primo = "pasta";
			ViewBag.p_secondo = "carne";
			ViewBag.p_contorno = "pomodori";
			ViewBag.p_dolce = "frutta";

			ViewBag.c_primo = "minestra";
			ViewBag.c_secondo = "pesce";
			ViewBag.c_contorno = "fagiolini";
			ViewBag.c_dolce = "budino";

			DomainModel dm = new DomainModel();
			dm.Giornata(DateTime.Today);
			return View("Giorno");
		}
	}
}