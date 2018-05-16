using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessObject;
using DataTransferObjects;

namespace LucaMVC.Models {
	public class DomainModel {
		public void AddMenu(DTMenu menu) {
			using(var db = new RistoranteEntities1()){
				var pri = new Primo {
					nome = menu.Primo[0].NomePrimo,
				};
				db.Primo.Add(pri);
				db.SaveChanges();

				var sec = new Secondo {
					nome = menu.Secondo[0].NomeSecondo,
				};
				db.Secondo.Add(sec);
				db.SaveChanges();

				var cont = new Contorno {
					nome = menu.Contorno[0].NomeContorno,
				};
				db.Contorno.Add(cont);
				db.SaveChanges();

				var dol = new Dolce {
					nome = menu.Dolce[0].NomeDolce,
				};
				db.Dolce.Add(dol);
				db.SaveChanges();

				var men = new Menu {
					dataMenu = menu.DataMenu,
					tipoMenu = $"{menu.Tipologia_Pasto}",
					primo = pri.id,
					secondo = sec.id,
					contorno = cont.id,
					dolce = dol.id,
				};
				db.Menu.Add(men);
				db.SaveChanges();
			}
		}

		public void Giornata(DateTime date) {

		}
	}
}