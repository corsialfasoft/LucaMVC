using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

		public ActionResult Pranzo() {
			ViewBag.Message = "Inserisci il pranzo";
			return View("Pranzo");
		}

		[HttpPost]
		public ActionResult Pranzo(DateTime date, string primo, string secondo, string contorno, string dolce) {
			ViewBag.Message = "Inserisci il pranzo";
			@ViewBag.p_data = date;
			ViewBag.p_primo = primo ;
			ViewBag.p_secondo = secondo;
			ViewBag.p_contorno = contorno;
			ViewBag.p_dolce = dolce;
			return View("Pranzo");
		}

		public ActionResult Cena() {
			ViewBag.Message = "Inserisci il pranzo";
			return View("Cena");
		}

		[HttpPost]
		public ActionResult Cena(DateTime date, string primo, string secondo, string contorno, string dolce) {
			ViewBag.Message = "Inserisci la cena";
			@ViewBag.c_data = date;
			ViewBag.c_primo = primo;
			ViewBag.c_secondo = secondo;
			ViewBag.c_contorno = contorno;
			ViewBag.c_dolce = dolce;
			return View("Cena");
		}

	}
}