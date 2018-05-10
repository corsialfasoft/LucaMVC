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
			return View("Pasto");
		}
	}
}