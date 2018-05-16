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

		public List<DTMenu> ListaDeiMenu(DateTime date) {
			DTMenu ris = new DTMenu();
			List< DTMenu > listMen = new List<DTMenu>();
			using(var db = new RistoranteEntities1()){
				var queryM = from m in db.Menu
							join p in db.Primo
								on m.primo equals p.id  
							join s in db.Secondo
								on m.secondo equals s.id  
							join c in db.Contorno
								on m.contorno equals c.id
							join d in db.Dolce
								on m.dolce equals d.id
							where m.dataMenu == date
							select m;

				var queryP = from m in db.Menu
							 join p in db.Primo
								 on m.primo equals p.id
							 join s in db.Secondo
								 on m.secondo equals s.id
							 join c in db.Contorno
								 on m.contorno equals c.id
							 join d in db.Dolce
								 on m.dolce equals d.id
							 where m.dataMenu == date
							 select p;

				var queryS = from m in db.Menu
							 join p in db.Primo
								 on m.primo equals p.id
							 join s in db.Secondo
								 on m.secondo equals s.id
							 join c in db.Contorno
								 on m.contorno equals c.id
							 join d in db.Dolce
								 on m.dolce equals d.id
							 where m.dataMenu == date
							 select s;

				var queryC = from m in db.Menu
							 join p in db.Primo
								 on m.primo equals p.id
							 join s in db.Secondo
								 on m.secondo equals s.id
							 join c in db.Contorno
								 on m.contorno equals c.id
							 join d in db.Dolce
								 on m.dolce equals d.id
							 where m.dataMenu == date
							 select c;

				var queryD = from m in db.Menu
							 join p in db.Primo
								 on m.primo equals p.id
							 join s in db.Secondo
								 on m.secondo equals s.id
							 join c in db.Contorno
								 on m.contorno equals c.id
							 join d in db.Dolce
								 on m.dolce equals d.id
							 where m.dataMenu == date
							 select d;

				List<DTPrimo> listaPrimi = new List<DTPrimo>();
				foreach (var dato in queryP) {
					listaPrimi.Add(new DTPrimo(dato.nome));
				}

				List<DTSecondo> listaSecondi = new List<DTSecondo>();
				foreach (var dato in queryS) {
					listaSecondi.Add(new DTSecondo(dato.nome));
				}
				
				List<DTContorno> listaContorni = new List<DTContorno>();
				foreach (var dato in queryC) {
					listaContorni.Add(new DTContorno(dato.nome));
				}

				List<DTDolce> listaDolci = new List<DTDolce>();
				foreach (var dato in queryC) {
					listaDolci.Add(new DTDolce(dato.nome));
				}

				foreach (var dato in queryM) {
					if (dato.tipoMenu == "pranzo") {
						ris = new DTMenu(date, 0, listaPrimi, listaSecondi, listaContorni, listaDolci);
					} else if (dato.tipoMenu == "cena") {
						ris = new DTMenu(date, 1, listaPrimi, listaSecondi, listaContorni, listaDolci);
					} else {
						throw new Exception("Tipologia del menù (pranzo / cena) errata nel DB!");
					}
					listMen.Add(ris);
				}
			}
			return listMen;
		}
	}
}