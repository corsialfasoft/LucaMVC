using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessObject {

	public enum Giornata { lunedì = 1, martedì, mercoledì, giovedì, venerdì, sabato, domenica };

	public enum TipoPasto { pranzo, cena };

	public class Primo {
		private string _nomePrimo;

		public string NomePrimo {
			get { return _nomePrimo; }
		}

		public Primo(string nome) {
			_nomePrimo = nome;
		}   //Costruttore
	}

	public class Secondo {
		private string _nomeSecondo;

		public string NomeSecondo {
			get { return _nomeSecondo; }
		}

		public Secondo(string nome) {
			_nomeSecondo = nome;
		}   //Costruttore
	}

	public class Contorno {
		private string _nomeContorno;

		public string NomeContorno {
			get { return _nomeContorno; }
		}

		public Contorno(string nome) {
			_nomeContorno = nome;
		}   //Costruttore
	}

	public class Dolce {
		private string _nomeDolce;

		public string NomeDolce {
			get { return _nomeDolce; }
		}

		public Dolce(string nome) {
			_nomeDolce = nome;
		}   //Costruttore
	}

	public class Menu {
		private int _id;
		private DateTime _dataMenu;
		private TipoPasto _tipoPasto;	//Pranzo o cena
		private List<Primo> _primo = new List<Primo>();
		private List<Secondo> _secondo = new List<Secondo>();
		private List<Contorno> _contorno = new List<Contorno>();
		private List<Dolce> _dolce = new List<Dolce>();

		public int Id {
			get { return _id; }
		}

		public DateTime DataMenu {
			get { return _dataMenu; }
		}


		public TipoPasto Tipologia_Pasto {
			get { return _tipoPasto; }
		}

		public List<Primo> Primo {
			get { return _primo; }
		}

		public List<Secondo> Secondo {
			get { return _secondo; }
		}

		public List<Contorno> Contorno {
			get { return _contorno; }
		}

		public List<Dolce> Dolce {
			get { return _dolce; }
		}


		public Menu (DateTime d, int tipoPasto, List<Primo> primo, List<Secondo> secondo, List<Contorno> contorno, List<Dolce> dolce) {
			try{
				if ( tipoPasto == 0 || tipoPasto == 1 ) {
					_tipoPasto = ( TipoPasto ) tipoPasto;
				} else {
					throw new Exception("Tipologia del pasto non valida! (deve essere 0 e 1)");
				}

				if ( primo != null && secondo != null && contorno != null && dolce != null ) {
					InserisciLista<Primo> ( _primo , primo ) ;
					InserisciLista<Secondo> ( _secondo , secondo ) ;
					InserisciLista<Contorno> ( _contorno , contorno ) ;
					InserisciLista<Dolce> ( _dolce , dolce ) ;
				} else {
					throw new Exception("Inserimento del Piatto errata! (è null)");
				}
				_dataMenu = d;
			} catch (Exception e) {
				throw e;
			}
		}   //Costruttore

		private void InserisciLista<T> (List<T> lista1, List<T> lista2) {
			foreach ( T p1 in lista2 ) {
				lista1.Add(p1);
			}
		}
	}

	public class Giorno {
		private int _id;
		private DateTime _dataG;
		private Giornata _tGiorno;
		private Menu _pranzo;
		private Menu _cena;

		public int Id {
			get { return _id; }
		}

		public DateTime DataG{
			get { return _dataG; }
		}

		public Giornata TGiorno {
			get { return _tGiorno; }
		}

		public Menu Pranzo {
			get { return _pranzo; }
		}

		public Menu Cena {
			get { return _cena; }
		}

		public Giorno ( DateTime d, int tGiorno , Menu pranzo , Menu cena ) {
			try{
				if ( tGiorno >= 1 && tGiorno <= 7) {
					_tGiorno = (Giornata) tGiorno ;
				} else {
					throw new Exception("Tipologia giorno errata!! ( deve avere un valore compreso tra 1 e 7 )");
				}

				if (pranzo != null && cena != null ) {
					if ( pranzo.Tipologia_Pasto == (TipoPasto) 0 && cena.Tipologia_Pasto == (TipoPasto) 1 ) {
						_pranzo = pranzo;
						_cena = cena;
					} else {
						throw new Exception ("Tipologia pasti errata nella creazione del giorno");
					}
				} else {
					throw new Exception("Inserimento di pasto/i 'NULL' nella creazione del giorno");
				}
				_dataG = d;
			} catch ( Exception e ) {
				throw e;
			}
		}
	}

	//public class Settimana{
	//	private DateTime _dataInizio;
	//	private DateTime _dataFine;
	//	private Giorno _lunedi;
	//	private Giorno _martedi;
	//	private Giorno _mercoledi;
	//	private Giorno _giovedi;
	//	private Giorno _venerdi;
	//	private Giorno _sabato;
	//	private Giorno _domenica;

	//	public DateTime DataInizio{
	//		get { return _dataInizio; }
	//	}

	//	public DateTime DataFine {
	//		get { return _dataFine; }
	//	}

	//	public Giorno Lunedi{
	//		get { return _lunedi; }
	//	}

	//	public Giorno Martedi {
	//		get { return _martedi; }
	//	}

	//	public Giorno Mercoledi {
	//		get { return _mercoledi; }
	//	}

	//	public Giorno Giovedi {
	//		get { return _giovedi; }
	//	}

	//	public Giorno Venerdi {
	//		get { return _venerdi; }
	//	}

	//	public Giorno Sabato {
	//		get { return _sabato; }
	//	}

	//	public Giorno Domenica {
	//		get { return _domenica; }
	//	}

	//	public Settimana ( DateTime i, DateTime f, Giorno lunedi, Giorno martedi, Giorno mercoledi, Giorno giovedi, Giorno _venerdi, Giorno sabato, Giorno domenica) {
	//		bool l, ma, me, g, v, s, d;
	//		l = CheckData (lunedi, i, f);
	//		ma = CheckData(martedi, i, f);
	//		me = CheckData(mercoledi, i, f);
			

	//	}

	//	private bool CheckData (Giorno g, DateTime i, DateTime f) {
	//		return (g.Data.Date >= i.Date && g.Data.Date <= f.Date);
	//	}
	//}
}